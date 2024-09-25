using System;
using System.IO;
using MelonLoader;
using Mu3Assist.Cheat;
using Mu3Assist.Common;
using Mu3Assist.Fix;

namespace Mu3Assist
{
    public static class BuildInfo
    {
        public const string Name = "Mu3-Assist";
        public const string Description = "Melonloader Mod For O.N.G.E.K.I";
        public const string Author = "WYH2004(Slim)";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = null;
    }

    public class Mu3Assist : MelonMod
    {
        public readonly ConfigManager Config = new ConfigManager();
        public override void OnInitializeMelon()
        {
            PrintLogo();
            
            MelonLogger.Msg("Load Mod Config.");
            var configPath = $"{BuildInfo.Name}/config.ini";
            if (!File.Exists(configPath))
            {
                MelonLogger.Error($"Path: \"{configPath}\" Not Found.");
                return;
            }

            try
            {
                Config.Initialize();
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Error initializing mod config: \n{e}");
            }
            
            //Patch
            // [Common]
            if (Config.InfinityTimer) Patch(typeof(InfinityTimer));
            
            // [Cheat]
            if (Config.FastSkip) Patch(typeof(FastSkip));
            if (Config.FastRestart) Patch(typeof(FastRestart));
            if (Config.UnlockMaster) Patch(typeof(UnlockMaster));
            if (Config.UnlockEvent) Patch(typeof(UnlockEvent));
            if (Config.UnlockMusic) Patch(typeof(UnlockMusic));
            
            // [Fix]
            if (Config.DisableEncryption) Patch(typeof(DisableEncryption));
            
            
            MelonLogger.Msg("Loading completed");
        }

        public override void OnGUI()
        {
            if(Config.ShowFPS) ShowFPS.OnGUI();
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
    }
}