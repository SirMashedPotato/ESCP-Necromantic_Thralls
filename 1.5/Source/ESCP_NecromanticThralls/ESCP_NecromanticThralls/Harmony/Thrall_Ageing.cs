using HarmonyLib;
using Verse;

namespace ESCP_NecromanticThralls
{
    [HarmonyPatch(typeof(Pawn_AgeTracker))]
    class Pawn_AgeTracker_BiologicalTicksPerTick_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("BiologicalTicksPerTick", MethodType.Getter)]
        public static bool BiologicalTicksPerTick_ThrallPatch(ref Pawn ___pawn, ref float __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableAgeing && ThrallUtility.PawnIsThrall(___pawn))
            {
                __result = 0f;
                return false;
            }
            return true;
        }
    }
}
