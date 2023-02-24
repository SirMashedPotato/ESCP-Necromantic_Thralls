using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{
    /* Works, unless something forcefully changes the level of the need
     * 
    [HarmonyPatch(typeof(Need))]
    class Need_CurLevel_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("IsFrozen", MethodType.Getter)]
        public static bool IsFrozen_ThrallPatch(ref Need __instance, ref Pawn ___pawn, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                if (__instance.def.defName != "TM_Mana" && __instance.def.defName != "TM_Stamina"
                    && !__instance.def.onlyIfCausedByGene && !__instance.def.onlyIfCausedByHediff)
                {
                    __result = true;
                    return false;
                }
            }
            return true;
        }
    }
    */

    [HarmonyPatch(typeof(Need))]
    class Need_ShowOnNeedList_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("ShowOnNeedList", MethodType.Getter)]
        public static bool ShowOnNeedList_ThrallPatch(ref Need __instance, ref Pawn ___pawn, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                if (__instance.def.defName != "TM_Mana" && __instance.def.defName != "TM_Stamina"
                    && !__instance.def.onlyIfCausedByGene && !__instance.def.onlyIfCausedByHediff)
                {
                    __result = false;
                    return false;
                }
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Need))]
    class Need_CurLevel_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("CurLevel", MethodType.Getter)]
        public static bool CurLevel_ThrallPatch(ref Need __instance, ref Pawn ___pawn, ref float __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                if (__instance.def.defName != "TM_Mana" && __instance.def.defName != "TM_Stamina"
                    && !__instance.def.onlyIfCausedByGene && !__instance.def.onlyIfCausedByHediff)
                {
                    __result = __instance.MaxLevel;
                    return false;
                }
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Need))]
    class Need_CurInstantLevel_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("CurInstantLevel", MethodType.Getter)]
        public static bool CurInstantLevel_ThrallPatch(ref Need __instance, ref Pawn ___pawn, ref float __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                if (__instance.def.defName != "TM_Mana" && __instance.def.defName != "TM_Stamina"
                    && !__instance.def.onlyIfCausedByGene && !__instance.def.onlyIfCausedByHediff)
                {
                    __result = __instance.MaxLevel;
                    return false;
                }
            }
            return true;
        }
    }
}