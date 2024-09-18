using HarmonyLib;
using MU3.ViewData;

namespace Mu3Assist.Cheat
{
    public class UnlockMaster
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MusicViewData), "get_isMasterLock")]
        public static bool GetMasterLock(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}