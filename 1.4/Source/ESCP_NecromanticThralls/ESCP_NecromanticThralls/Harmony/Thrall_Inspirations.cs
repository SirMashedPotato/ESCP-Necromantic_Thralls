using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{
    [HarmonyPatch(typeof(InspirationWorker))]
    [HarmonyPatch("InspirationCanOccur")]
    public static class InspirationWorker_InspirationCanOccur_Patch
    {
        [HarmonyPrefix]
        public static bool InspirationCanOccur_ThrallPatch(Pawn pawn, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableInspirations && ThrallUtility.PawnIsThrall(pawn))
            {
                __result = false;
                return false;
            }
            return true;
        }
    }
}
