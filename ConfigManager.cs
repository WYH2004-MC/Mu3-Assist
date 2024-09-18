using MelonLoader;

namespace Mu3Assist
{
    public class ConfigManager
    {
        // [Fix]
        public bool DisableEncryption { get; private set; }
        
        public void initialize()
        {
            var iniFile = new IniFile($"{BuildInfo.Name}/Config.ini");
            
            // [Fix]
            DisableEncryption = iniFile.GetBool("Fix", "DisableEncryption", false);
        }
    }
}