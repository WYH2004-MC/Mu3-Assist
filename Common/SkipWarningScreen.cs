using System.Reflection;
using HarmonyLib;
using MU3;
using MU3.Sequence;

namespace Mu3Assist.Common
{
    public class SkipWarningScreen
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Initialize), "Enter_Warning")]
        public static bool SkipWarningEnter(Initialize __instance)
        {
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Initialize), "Execute_Warning")]
        public static bool SkipWarningExecute(Initialize __instance)
        {
            __instance.GetType().GetMethod("setNextStateAfterWarning", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(__instance, null);
            return false;
        }
    }
}