using System;
using HarmonyLib;
using MU3;
using MU3.Util;

namespace Mu3_Assist.Common
{
    public class SkipInformationScreen
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(Scene_30_NoticeReward), "Start")]
        public static void SkipScreen(Scene_30_NoticeReward __instance)
        {
            var method = __instance.GetType().GetMethod(
                "onFinishNotice",
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance
            );
            method?.Invoke(__instance, null);
            //SingletonMonoBehaviour<SystemUI>.instance.Panel.pushState(0, true);
        }
    }
}