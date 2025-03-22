using System;
using HarmonyLib;
using MelonLoader;
using Mu3_Assist.Cheat;
using Mu3_Assist.Common;
using Mu3_Assist.Fix;
using Mu3_Assist.Config;
using MU3.AM;
using MU3.Sys;
using MU3.Util;

namespace Mu3_Assist
{
    public static class BuildInfo
    {
        public const string Name = "Mu3-Assist";
        public const string Description = "Melonloader Mod For O.N.G.E.K.I";
        public const string Author = "WYH2004";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = null;
    }
    
    public class Mu3Assist : MelonMod
    {
        public AssistConfig Config;
        public static VersionNo VersionNo;

        private static readonly HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony("Mu3Assist");
            
        public override void OnInitializeMelon()
        {
            PrintLogo();
            harmonyInstance.PatchAll();
            // ConfigManager Initialize
            var configManager = new ConfigManager<AssistConfig>($"./{BuildInfo.Name}/config.yml");
            Config = configManager.GetConfig();
            
            // Future patch
            // Cheat future
            if (Config.Cheat.UnlockEvent) Patch(typeof(UnlockEvent));
            if (Config.Cheat.UnlockMusic) Patch(typeof(UnlockMusic));
            if (Config.Cheat.UnlockMaster) Patch(typeof(UnlockMaster));
            if (Config.Cheat.FastSkip) Patch(typeof(FastSkip));
            if (Config.Cheat.FastRestart) Patch(typeof(FastRestart));
            // Common future
            if (Config.Common.InfinityTimer) Patch(typeof(InfinityTimer));
            if (Config.Common.SkipWarningScreen) Patch(typeof(SkipWarningScreen));
            if (Config.Common.SkipInformationScreen) Patch(typeof(SkipInformationScreen));
            // Fix future
            if (Config.Fix.DisableEncryption) Patch(typeof(DisableEncryption));
            
            MelonLogger.Msg("Loading completed");
        }

        public override void OnGUI()
        {

        }
        
        private static bool Patch(Type type)
        {
            try
            {
                MelonLogger.Msg($"- Patch: {type}");
                HarmonyLib.Harmony.CreateAndPatchAll(type);
                return true;
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Patch {type} failed.");
                MelonLogger.Error(e);
                return false;
            }
        }
        
        private static void PrintLogo()
        {
            MelonLogger.Msg("\n" +
                            "\r\n  __  __       ____                       _     _   " +
                            "\r\n |  \\/  |     |___ \\        /\\           (_)   | |  " +
                            "\r\n | \\  / |_   _  __) |_____ /  \\   ___ ___ _ ___| |_ " +
                            "\r\n | |\\/| | | | ||__ <______/ /\\ \\ / __/ __| / __| __|" +
                            "\r\n | |  | | |_| |___) |    / ____ \\\\__ \\__ \\ \\__ \\ |_ " +
                            "\r\n |_|  |_|\\__,_|____/    /_/    \\_\\___/___/_|___/\\__|" +
                            "\r\n                                                    " +
                            "\r\n=====================================================" +
                            $"\r\n Version: {BuildInfo.Version}     Author: {BuildInfo.Author}");
        }
        
        [HarmonyPatch(typeof(AMManager),"Execute_WaitAMDaemonReady")]
        private class AMDaemonReady
        {
            private static bool _amDaemonReady = false;
            private static void Postfix()
            {
                if (!_amDaemonReady && AMManager.instance.isReady)
                {
                    VersionNo = SingletonStateMachine<AMManager, AMManager.EState>.instance.versionNo;
                    MelonLogger.Msg($"AMDaemon Initialize finished");
                    MelonLogger.Msg($"AMDaemon Get Version: {VersionNo.majorNo}.{VersionNo.minorNo}.{VersionNo.releaseNo} ({VersionNo.versionString})");
                    _amDaemonReady = true;
                }
            }
        }
    }
}