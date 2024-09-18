using HarmonyLib;
using MU3.DataStudio;

namespace Mu3Assist.Cheat
{
    public class UnlockMusic
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MusicData), "get_CostToUnlock")]
        public static bool GetCostToUnlock(ref int __result)
        {
            __result = 0;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MusicData), "get_PossessingFromTheBeginning")]
        public static bool GetPossessingFromTheBeginning(ref bool __result)
        {
            __result = true;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MusicData), "get_IsLockedAtTheBeginning")]
        public static bool GetIsLockedAtTheBeginning(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}