using System;
using System.IO;
using MelonLoader;

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
        public override void OnInitializeMelon()
        {
            PrintLogo();
            
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

    }
}