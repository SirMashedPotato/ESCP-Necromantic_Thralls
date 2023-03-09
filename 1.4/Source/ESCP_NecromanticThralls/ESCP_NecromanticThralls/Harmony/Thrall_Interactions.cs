using HarmonyLib;
using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    [HarmonyPatch(typeof(InteractionUtility))]
    [HarmonyPatch("CanInitiateInteraction")]
    public static class InteractionUtility_CanInitiateInteraction_Patch
    {
        [HarmonyPostfix]
        public static void CanInitiateInteraction_ThrallPatch(ref bool __result, Pawn pawn, InteractionDef interactionDef = null)
        {
            if (interactionDef != null && __result && ESCP_NecromanticThralls_ModSettings.ThrallDisableSocialInteractions && ThrallUtility.PawnIsThrall(pawn))
            {
                if (interactionDef == RimWorld.InteractionDefOf.Insult 
                    || interactionDef == RimWorld.InteractionDefOf.RomanceAttempt
                    || interactionDef == RimWorld.InteractionDefOf.Chitchat 
                    || interactionDef == RimWorld.InteractionDefOf.DeepTalk
                    || interactionDef == InteractionDefOf.KindWords 
                    || interactionDef == InteractionDefOf.Slight)
                {
                    __result = false;
                }

                if (interactionDef.modContentPack?.PackageId == "jpt.speakup")
                {
                    __result = false;
                }
            }
        }
    }

    [HarmonyPatch(typeof(PawnUtility))]
    [HarmonyPatch("IsInteractionBlocked")]
    public static class PawnUtility_IsInteractionBlocked_Patch
    {
        [HarmonyPostfix]
        public static void IsInteractionBlocked_ThrallPatch(Pawn pawn, InteractionDef interaction, ref bool __result)
        {
            if (!__result && ESCP_NecromanticThralls_ModSettings.ThrallSocialInteractionsEntirely && ThrallUtility.PawnIsThrall(pawn))
            {
                __result = true;
            }
        }
    }

    /// <summary>
    /// Biotech Hemogen related
    /// </summary>

    [HarmonyPatch(typeof(JobGiver_GetHemogen))]
    [HarmonyPatch("CanFeedOnPrisoner")]
    public static class JobGiver_GetHemogen_CanFeedOnPrisoner_Patch
    {
        [HarmonyPostfix]
        public static void CanFeedOnPrisoner_ThrallPatch(Pawn prisoner, ref AcceptanceReport __result)
        {
            if (__result && ThrallUtility.PawnIsThrall(prisoner))
            {
                __result = false;
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
            if (__result && ThrallUtility.PawnIsThrall(surgeryTarget))
            {
                __result = false;
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
            if (ThrallUtility.PawnIsThrall(medPawn))
            {
                Messages.Message("MessageCannotStartHemogenExtraction".Translate(medPawn.Named("PAWN")), medPawn, MessageTypeDefOf.NeutralEvent, false);
            }
        }
    }
}
