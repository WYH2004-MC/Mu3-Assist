using System;
using System.Reflection;
using HarmonyLib;
using MelonLoader;
using MU3;
using MU3.Battle;
using MU3.Game;
using MU3.Notes;
using MU3.Sequence;
using MU3.Util;

namespace Mu3Assist.Cheat
{
    public class FastRestart
    {
        private static bool RestartFlag = false;
        private static float TotalRollingFrame;
        private static DateTime StartTime;
        private static TimeSpan TotalRollingTime;
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlayMusic), "Execute_Play")]
        public static bool Execute_Play(PlayMusic __instance)
        {
            try
            {
                var ntMgrProperty = typeof(PlayMusic).GetProperty("ntMgr", BindingFlags.NonPublic | BindingFlags.Instance);
                var ntMgr = (NotesManager)ntMgrProperty.GetValue(__instance, null);
                var gameEngine = (GameEngine) AccessTools.Field(typeof(PlayMusic), "_gameEngine").GetValue(__instance);
                var sessionInfo = (SessionInfo)AccessTools.Field(typeof(PlayMusic), "_sessionInfo").GetValue(__instance);
                if (RestartFlag)
                {
                    TimeSpan timeSpan = CustomDateTime.Now - StartTime;
                    if (timeSpan <= TotalRollingTime)
                    {
                        var fadeOut = FadeOut(timeSpan.TotalMilliseconds / TotalRollingTime.TotalMilliseconds, 0.0, 1.0);
                        var fadeIn = FadeIn(timeSpan.TotalMilliseconds / TotalRollingTime.TotalMilliseconds, 0.0, 1.0);
                        ntMgr.setFrameForce(TotalRollingFrame * (float) (1.0 - fadeOut));
                    }
                    else
                    {
                        RestartFlag = false;
                        ntMgr.stopPlay();
                        ntMgr.reset();
                        ntMgr.reloadScore(gameEngine.IsStageDazzling);
                        gameEngine.counters.reset();
                        gameEngine.battleReward.initialize(sessionInfo);
                        gameEngine.enemyManager.destroy();
                        gameEngine.enemyManager.initialize();
                        gameEngine.reset();
                        Singleton<GameSound>.instance.gameBGM.playMusic(sessionInfo.musicData, 0);
                        ntMgr.startPlay(0.0f);
                        ntMgr.led.setGameColor(true);
                    }
                }
                else if (!sessionInfo.isTutorial && Singleton<UIInput>.instance.getStateOn(UIInput.Key.MenuLeft))
                {
                    RestartFlag = true;
                    TotalRollingTime = TimeSpan.FromSeconds(1.0);
                    TotalRollingFrame = ntMgr.getCurrentFrame();
                    StartTime = CustomDateTime.Now;
                    ntMgr.forceRecover((Recover) 1, 100);
                    Singleton<GameSound>.instance.gameBGM.stop();
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MelonLogger.Error(e);
            }
            return true;
        }
        
        private static double FadeOut(double progress, double min, double max)
        {
            return min + (max - min) * (1.0 - Math.Pow(1.0 - progress, 2.0));
        }

        private static double FadeIn(double progress, double min, double max)
        {
            return min + (max - min) * Math.Pow(progress, 2.0);
        }
    }
}