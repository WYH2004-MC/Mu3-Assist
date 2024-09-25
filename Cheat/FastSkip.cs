using System;
using System.Reflection;
using HarmonyLib;
using MelonLoader;
using MU3;
using MU3.Game;
using MU3.Notes;
using MU3.Sequence;
using MU3.Util;

namespace Mu3Assist.Cheat
{
    public class FastSkip
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlayMusic), "Execute_Play")]
        public static bool Execute_Play(PlayMusic __instance)
        {
            try
            {
                var ntMgrProperty =
                    typeof(PlayMusic).GetProperty("ntMgr", BindingFlags.NonPublic | BindingFlags.Instance);
                var ntMgr = (NotesManager)ntMgrProperty.GetValue(__instance, null);
                var sessionInfo =
                    (SessionInfo)AccessTools.Field(typeof(PlayMusic), "_sessionInfo").GetValue(__instance);
                if (!sessionInfo.isTutorial && Singleton<UIInput>.instance.getStateOn(UIInput.Key.MenuRight))
                {
                    ntMgr.forceDamage(Damage.Skill, 100);
                }
            }
            catch (Exception e)
            {
                MelonLogger.Error(e);
            }
            return true;
        }
    }
}