using System;
using System.Linq;
using HarmonyLib;
using MelonLoader;
using MU3;
using MU3.Client;
using MU3.Data;
using MU3.Operation;
using MU3.Util;

namespace Mu3Assist.Cheat
{
    public class UnlockEvent
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(PacketGetGameEvent), "proc")]
        public static void Unlock(PacketGetGameEvent __instance, ref Packet.State __result)
        {
            if (__result != Packet.State.Done) return;
            //var GameEventField = typeof(PacketGetGameEvent).GetField("_gameEvent", BindingFlags.NonPublic | BindingFlags.Instance);
            //MU3.Operation.GameEvent gameEvent = (GameEvent)GameEventField.GetValue(__instance);
            try
            {
                DateTime dateTime = DateTime.Parse("2077-07-21 11:45:14.0");
            
                foreach (var eventData in SingletonStateMachine<DataManager, DataManager.EState>.instance.allEventData)
                {
                    var idPeriod = __instance.gameEvent.list.FirstOrDefault(e => e.id == eventData.id);
                    
                    if (idPeriod != null)
                    {
                        if (idPeriod.period.endDate < CustomDateTime.Now)
                            idPeriod.period.endDate = dateTime;
                    }
                    else
                    {
                        __instance.gameEvent.list.Add(new IdPeriod
                        {
                            id = eventData.id,
                            period = new Period(DateTime.MinValue.Date, dateTime)
                        });
                        __instance.gameEvent.lastUpdate = CustomDateTime.Now;
                    }
                }
            }
            catch (Exception e)
            {
                MelonLogger.Error(e);
            }
        }
    }
}