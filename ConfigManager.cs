using MelonLoader;

namespace Mu3Assist
{
    public class ConfigManager
    {
        // [Common]
        
        
        // [Cheat]
        public bool UnlockMaster { get; private set; }

        // [Fix]
        public bool DisableEncryption { get; private set; }
        
        public void initialize()
        {
            var iniFile = new IniFile($"{BuildInfo.Name}/Config.ini");
            
            // [Cheat]
            UnlockMaster = iniFile.GetBool("Cheat", "UnlockMaster", false);
            
            // [Fix]
            DisableEncryption = iniFile.GetBool("Fix", "DisableEncryption", false);
        }
    }
}