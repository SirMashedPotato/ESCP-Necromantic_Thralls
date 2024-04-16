using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace ESCP_NecromanticThralls
{

    [HarmonyPatch(typeof(JobGiver_Mate))]
    [HarmonyPatch("TryGiveJob")]
    public static class JobGiver_Mate_TryGiveJob_Patch
    {
        [HarmonyPrefix]
        public static bool JobGiver_Mate_TryGiveJob_ThrallPatch(Pawn pawn, ref Job __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableMating && ThrallUtility.PawnIsThrall(pawn))
            {
                __result = null;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(PawnUtility))]
    [HarmonyPatch("FertileMateTarget")]
    public static class PawnUtility_FertileMateTarget_Patch
    {
        [HarmonyPrefix]
        public static bool FertileMateTarget_ThrallPatch(Pawn male, Pawn female, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableMating && (ThrallUtility.PawnIsThrall(male) || ThrallUtility.PawnIsThrall(female)))
            {
                __result = false;
                return false;
            }
            return true;
        }
    }

}
