using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{

    [HarmonyPatch(typeof(SkillRecord))]
    [HarmonyPatch("Learn")]
    public static class Interval_Learn_Patch
    {
        [HarmonyPrefix]
        public static bool SkillRecord_Learn_ThrallPatch(ref Pawn ___pawn)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableSkillLearning && ThrallUtility.PawnIsThrall(___pawn))
            {
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(SkillRecord))]
    [HarmonyPatch("Interval")]
    public static class Interval_Interval_Patch
    {
        [HarmonyPrefix]
        public static bool SkillRecord_Interval_ThrallPatch(ref Pawn ___pawn)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableSkillDecay && ThrallUtility.PawnIsThrall(___pawn))
            {
                return false;
            }
            return true;
        }
    }

}
