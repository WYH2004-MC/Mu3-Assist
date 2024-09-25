using MelonLoader;

namespace Mu3Assist
{
    public class ConfigManager
    {
        // [Common]
        public bool InfinityTimer {get; private set; }
        public bool ShowFPS {get; private set; }
        
        // [Cheat]
        public bool FastSkip {get; private set; }
        public bool UnlockMaster { get; private set; }
        public bool UnlockEvent { get; private set; }
        public bool UnlockMusic { get; private set; }

        // [Fix]
        public bool DisableEncryption { get; private set; }
        
        public void initialize()
        {
            var iniFile = new IniFile($"{BuildInfo.Name}/Config.ini");
            
            // [Common]
            InfinityTimer = iniFile.GetBool("Common", "InfinityTimer", false);
            ShowFPS = iniFile.GetBool("Common", "ShowFPS", false);
            
            // [Cheat]
            FastSkip = iniFile.GetBool("Cheat", "FastSkip", false);
            UnlockMaster = iniFile.GetBool("Cheat", "UnlockMaster", false);
            UnlockEvent = iniFile.GetBool("Cheat", "UnlockEvent", false);
            UnlockMusic = iniFile.GetBool("Cheat", "UnlockMusic", false);
            
            // [Fix]
            DisableEncryption = iniFile.GetBool("Fix", "DisableEncryption", false);
        }
    }
}