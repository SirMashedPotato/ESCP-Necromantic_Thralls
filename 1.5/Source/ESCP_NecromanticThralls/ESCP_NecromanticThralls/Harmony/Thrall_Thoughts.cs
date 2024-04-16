using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

namespace ESCP_NecromanticThralls
{
    [HarmonyPatch(typeof(ThoughtHandler))]
    [HarmonyPatch("GetSocialThoughts")]
    [HarmonyPatch(new Type[] { typeof(Pawn), typeof(ISocialThought), typeof(List<ISocialThought>) })]
    public static class ThoughtHandler_GetSocialThoughts_Patch
    {
        [HarmonyPrefix]
        public static bool GetSocialThoughts_ThrallPatch(ref Pawn ___pawn, List<ISocialThought> outThoughts)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableMoods && ThrallUtility.PawnIsThrall(___pawn))
            {
                outThoughts.Clear();
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(SituationalThoughtHandler))]
    [HarmonyPatch("AppendMoodThoughts")]
    public static class SituationalThoughtHandler_AppendMoodThoughts_Patch
    {
        [HarmonyPostfix]
        public static void AppendMoodThoughts_ThrallPatch(List<Thought> outThoughts)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableMoods && outThoughts.Find(x => x.def == ThoughtDefOf.ESCP_NecromanticThralls_ThrallThought) != null)
            {
                Thought temp = outThoughts.Find(x => x.def == ThoughtDefOf.ESCP_NecromanticThralls_ThrallThought);
                outThoughts.Clear();
                outThoughts.Add(temp);
            }
        }
    }
}
