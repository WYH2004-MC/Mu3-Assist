using HarmonyLib;
using MU3;
using MU3.TestMode;
using UnityEngine;

namespace Mu3_Assist.Fix
{
    public class FixTestMode
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(TestModeObject),"initializeParamater")]
        public static void TestModeObject(ref TestModeObject __instance)
        {
            Canvas canvas = Utility.findParentRecursive<Canvas>(__instance.transform);
            canvas.transform.localScale = new Vector2(1, 1);
            canvas.transform.localPosition = new Vector2(540, 960);
        }
        
        [HarmonyPostfix]
        [HarmonyPatch(typeof(TestModePage),"initializeParamater")]
        public static void TestModePage(ref TestModePage __instance)
        {
            var cursorOffsetField  = typeof(TestModePage).GetField(
                "_cursorOffset", 
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance
            );
            Vector3 cursorOffset = new Vector3(-48f * Screen.height / 1920f, 0f, 0f);
            if (cursorOffsetField != null) cursorOffsetField.SetValue(__instance, cursorOffset);
        }
        
    }
}