using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;
using RimWorld.Planet;

namespace ESCP_NecromanticThralls
{
    //Works for trade caravans (at player map) and trade ships
    [HarmonyPatch(typeof(TradeUtility))]
    [HarmonyPatch("AllSellableColonyPawns")]
    public static class TradeUtility_AllSellableColonyPawns_Patch
    {
        [HarmonyPostfix]
        public static void AllSellableColonyPawns_ThrallPatch(ref IEnumerable<Pawn> __result)
        {
            List<Pawn> toRemove = new List<Pawn> { };
            foreach (Pawn p in __result)
            {
                if (ThrallUtility.PawnIsThrall(p))
                {
                    toRemove.Add(p);
                }
            }

            if (!toRemove.NullOrEmpty())
            {
                List<Pawn> editedList = __result.ToList();
                foreach (Pawn p in toRemove)
                {

                    editedList.Remove(p);
                }
                __result = editedList;
                toRemove.Clear();
            }

        }
    }

    //For trading directly with settlements
    [HarmonyPatch(typeof(Settlement_TraderTracker))]
    [HarmonyPatch("ColonyThingsWillingToBuy")]
    public static class Settlement_TraderTracker_ColonyThingsWillingToBuy_Patch
    {
        [HarmonyPostfix]
        public static void ColonyThingsWillingToBuy_ThrallPatch(ref IEnumerable<Thing> __result)
        {
            List<Thing> toRemove = new List<Thing> { };
            foreach (Thing t in __result)
            {
                if (ThrallUtility.ThingIsThrall(t))
                {
                    toRemove.Add(t);
                }
            }

            if (!toRemove.NullOrEmpty())
            {
                List<Thing> editedList = __result.ToList();
                foreach (Thing t in toRemove)
                {
                    editedList.Remove(t);
                }
                __result = editedList;
                toRemove.Clear();
            }

        }
    }

    //Not sure what this one is for, but keeping it in in case it is necessary
    [HarmonyPatch(typeof(Caravan_TraderTracker))]
    [HarmonyPatch("ColonyThingsWillingToBuy")]
    public static class Caravan_TraderTracker_ColonyThingsWillingToBuy_Patch
    {
        [HarmonyPostfix]
        public static void ColonyThingsWillingToBuy_ThrallPatch(ref IEnumerable<Thing> __result)
        {
            List<Thing> toRemove = new List<Thing> { };
            foreach (Thing t in __result)
            {
                if (ThrallUtility.ThingIsThrall(t))
                {
                    toRemove.Add(t);
                }
            }

            if (!toRemove.NullOrEmpty())
            {
                List<Thing> editedList = __result.ToList();
                foreach (Thing t in toRemove)
                {
                    editedList.Remove(t);
                }
                __result = editedList;
                toRemove.Clear();
            }

        }
    }
}
