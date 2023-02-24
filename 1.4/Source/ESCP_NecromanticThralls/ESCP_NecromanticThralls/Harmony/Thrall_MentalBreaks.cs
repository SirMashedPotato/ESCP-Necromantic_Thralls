using HarmonyLib;
using Verse;
using Verse.AI;

namespace ESCP_NecromanticThralls
{
    [HarmonyPatch(typeof(MentalStateWorker))]
    [HarmonyPatch("StateCanOccur")]
    public static class MentalStateWorker_StateCanOccur_Patch
    {
        [HarmonyPrefix]
        public static bool StateCanOccur_ThrallPatch(Pawn pawn, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableMentalBreaks && ThrallUtility.PawnIsThrall(pawn))
            {
                __result = false;
                return false;
            }
            return true;
        }
    }
}
