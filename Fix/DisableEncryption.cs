using HarmonyLib;
using MU3;

namespace Mu3Assist.Fix
{
    public class DisableEncryption
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(NetConfig), "get_EncryptVersion")]
        public static bool GetEncryptVersion(ref int __result)
        {
            __result = 0;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(NetConfig), "set_EncryptVersion")]
        public static bool SetEncryptVersion(ref int value)
        {
            value = 0;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(NetConfig), "get_UseTLS")]
        public static bool GetUseTLS(ref bool __result)
        {
            __result = false;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(NetConfig), "set_UseTLS")]
        public static bool SetUseTLS(ref bool value)
        {
            value = false;
            return false;
        }
    }
}