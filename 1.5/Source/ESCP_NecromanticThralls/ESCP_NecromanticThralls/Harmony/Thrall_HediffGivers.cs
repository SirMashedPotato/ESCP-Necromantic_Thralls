using HarmonyLib;
using Verse;

namespace ESCP_NecromanticThralls
{
    [HarmonyPatch(typeof(HediffGiver_Bleeding))]
    [HarmonyPatch("OnIntervalPassed")]
    class HediffGiver_Bleeding_OnIntervalPassed_Patch
    {
        [HarmonyPrefix]
        public static bool OnIntervalPassed_ThrallPatch(Pawn pawn)
        {
            return !(ESCP_NecromanticThralls_ModSettings.ThrallDisableBloodloss && ThrallUtility.PawnIsThrall(pawn));
        }
    }

    [HarmonyPatch(typeof(HediffGiver_Hypothermia))]
    [HarmonyPatch("OnIntervalPassed")]
    class HediffGiver_Hypothermia_OnIntervalPassed_Patch
    {
        [HarmonyPrefix]
        public static bool OnIntervalPassed_ThrallPatch(Pawn pawn)
        {
            return !(ESCP_NecromanticThralls_ModSettings.ThrallDisableHypothermia && ThrallUtility.PawnIsThrall(pawn));
        }
    }

    [HarmonyPatch(typeof(HediffGiver_Heat))]
    [HarmonyPatch("OnIntervalPassed")]
    class HediffGiver_Heat_OnIntervalPassed_Patch
    {
        [HarmonyPrefix]
        public static bool OnIntervalPassed_ThrallPatch(Pawn pawn)
        {
            return !(ESCP_NecromanticThralls_ModSettings.ThrallDisableHeatstroke && ThrallUtility.PawnIsThrall(pawn));
        }
    }
}
