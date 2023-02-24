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
            if (__result && ESCP_NecromanticThralls_ModSettings.ThrallDisableSocialInteractions && ThrallUtility.PawnIsThrall(pawn))
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
            }
        }
    }
}
