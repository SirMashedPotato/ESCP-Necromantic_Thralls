using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{
    [HarmonyPatch(typeof(Pawn_IdeoTracker))]
    class Pawn_IdeoTracker_CertaintyChangePerDay_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("CertaintyChangePerDay", MethodType.Getter)]
        public static bool CertaintyChangePerDay_ThrallPatch(ref Pawn ___pawn, ref float __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableIdeoCertainty && ThrallUtility.PawnIsThrall(___pawn))
            {
                __result = 1f;
                return false;
            }
            return true;
        }
    }
}
