using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{

    [HarmonyPatch(typeof(Pawn_TrainingTracker))]
    [HarmonyPatch("CanBeTrained")]
    public static class Pawn_TrainingTracker_CanBeTrained_Patch
    {
        [HarmonyPrefix]
        public static bool CanBeTrained_ThrallPatch(ref Pawn ___pawn, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableTrainable && ThrallUtility.PawnIsThrall(___pawn))
            {
                __result = false;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Pawn_TrainingTracker))]
    [HarmonyPatch("TrainingTrackerTickRare")]
    public static class Pawn_TrainingTrackerTickRare_Patch
    {
        [HarmonyPrefix]
        public static bool TrainingTrackerTickRare_ThrallPatch(ref Pawn ___pawn)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableTrainableDecay && ThrallUtility.PawnIsThrall(___pawn))
            {
                return false;
            }
            return true;
        }
    }

}
