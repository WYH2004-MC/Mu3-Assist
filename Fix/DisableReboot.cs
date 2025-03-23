using System;
using HarmonyLib;
using MU3.Operation;

namespace Mu3_Assist.Fix
{
    public class DisableReboot
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "isUnderServerMaintenance")]
        public static bool MaintenanceTimerIsUnderServerMaintenance(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "isAutoRebootNeeded")]
        public static bool MaintenanceTimerIsAutoRebootNeeded(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "getServerMaintenanceSec")]
        public static bool MaintenanceTimerGetServerMaintenanceSec(ref int __result)
        {
            __result = Int32.MaxValue;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "getAutoRebootSec")]
        public static bool MaintenanceTimerGetAutoRebootSec(ref int __result)
        {
            __result = Int32.MaxValue;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "getRemainingMinutes")]
        public static bool MaintenanceTimerGetRemainingMinutes(ref int __result)
        {
            __result = Int32.MaxValue;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "getClosedRemainingMinutes")]
        public static bool MaintenanceTimerGetClosedRemainingMinutes(ref int __result)
        {
            __result = Int32.MaxValue;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "isShowRemainingMinutes")]
        public static bool MaintenanceTimerIsShowRemainingMinutes(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "isClosed")]
        public static bool MaintenanceTimerIsClosed(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "isForceLogout")]
        public static bool MaintenanceTimerIsForceLogout(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "getCreditUseRestriction")]
        public static bool MaintenanceTimerGetCreditUseRestriction(ref ClosingManager.CreditUseRestriction  __result)
        {
            __result = ClosingManager.CreditUseRestriction.None;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaintenanceTimer), "isCoinAcceptable")]
        public static bool MaintenanceTimerIsCoinAcceptable(ref bool  __result)
        {
            __result = true;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ClosingManager), "getRemainingMinutes")]
        public static bool ClosingManagerGetRemainingMinutes(ref int __result)
        {
            __result = Int32.MaxValue;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ClosingManager), "getClosedRemainingMinutes")]
        public static bool ClosingManagerGetClosedRemainingMinutes(ref int __result)
        {
            __result = Int32.MaxValue;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ClosingManager), "isShowRemainingMinutes")]
        public static bool ClosingManagerIsShowRemainingMinutes(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ClosingManager), "isReceptionClosed")]
        public static bool ClosingManagerIsReceptionClosed(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ClosingManager), "isForceLogout")]
        public static bool ClosingManagerIsForceLogout(ref bool __result)
        {
            __result = false;
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ClosingManager), "getCreditUseRestriction")]
        public static bool ClosingManagerGetCreditUseRestriction(ref ClosingManager.CreditUseRestriction __result)
        {
            __result = ClosingManager.CreditUseRestriction.None;
            return false;
        }
        
    }
}