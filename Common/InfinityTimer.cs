using HarmonyLib;
using MU3;

namespace Mu3Assist.Common
{
    public class InfinityTimer
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(SystemUI.Timer),"get_show")]
        public static bool GetShow(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(SystemUI.Timer),"set_show")]
        public static bool SetShow(bool value)
        {
            return false;
        }

        // Patch for the `execute` method
        [HarmonyPrefix]
        [HarmonyPatch(typeof(SystemUI.Timer),"execute")]
        public static bool SystemUIExecute()
        {
            return false; 
        }
    }
}