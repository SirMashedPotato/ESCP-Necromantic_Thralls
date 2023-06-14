using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{
    /// <summary>
    /// Ability related
    /// </summary>

    [HarmonyPatch(typeof(CompAbilityEffect_BloodfeederBite))]
    [HarmonyPatch("Valid")]
    public static class CompAbilityEffect_BloodfeederBite_Valid_Patch
    {
        [HarmonyPostfix]
        public static void BloodfeederBite_Valid_ThrallPatch(LocalTargetInfo target, ref bool __result)
        {
            Pawn pawn = target.Pawn;
            if (__result && pawn != null)
            {
                if (ESCP_NecromanticThralls_ModSettings.ThrallBloodfeedTarget && ThrallUtility.PawnIsThrall(pawn))
                {
                    __result = false;
                }
            }
        }
    }

    /// <summary>
    /// Interaction related
    /// </summary>

    [HarmonyPatch(typeof(JobGiver_GetHemogen))]
    [HarmonyPatch("CanFeedOnPrisoner")]
    public static class JobGiver_GetHemogen_CanFeedOnPrisoner_Patch
    {
        [HarmonyPostfix]
        public static void CanFeedOnPrisoner_ThrallPatch(Pawn prisoner, ref AcceptanceReport __result)
        {
            if (__result)
            {
                if (ESCP_NecromanticThralls_ModSettings.ThrallBloodfeedTarget && ThrallUtility.PawnIsThrall(prisoner))
                {
                    __result = false;
                }
            }
        }
    }

    [HarmonyPatch(typeof(Recipe_ExtractHemogen))]
    [HarmonyPatch("CompletableEver")]
    public static class Recipe_ExtractHemogen_CompletableEver_Patch
    {
        [HarmonyPostfix]
        public static void CompletableEver_ThrallPatch(Pawn surgeryTarget, ref bool __result)
        {
            if (__result)
            {
                if (ESCP_NecromanticThralls_ModSettings.ThrallBloodfeedTarget && ThrallUtility.PawnIsThrall(surgeryTarget))
                {
                    __result = false;
                }
            }
        }
    }

    [HarmonyPatch(typeof(Recipe_ExtractHemogen))]
    [HarmonyPatch("CheckForWarnings")]
    public static class Recipe_ExtractHemogen_CheckForWarnings_Patch
    {
        [HarmonyPostfix]
        public static void CheckForWarnings_ThrallPatch(Pawn medPawn)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallBloodfeedTarget && ThrallUtility.PawnIsThrall(medPawn))
            {
                Messages.Message("MessageCannotStartHemogenExtraction".Translate(medPawn.Named("PAWN")), medPawn, MessageTypeDefOf.NeutralEvent, false);
            }
        }
    }
}
