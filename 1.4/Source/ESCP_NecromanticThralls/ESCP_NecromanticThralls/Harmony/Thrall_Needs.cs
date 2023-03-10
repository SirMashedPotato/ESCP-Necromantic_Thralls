using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{
    /// <summary>
    /// Works, unless something forcefully changes the level of the need
    /// Other patches should cover that though
    /// </summary>
    [HarmonyPatch(typeof(Need))]
    class Need_IsFrozen_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("IsFrozen", MethodType.Getter)]
        public static bool IsFrozen_ThrallPatch(ref Need __instance, ref Pawn ___pawn, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                if (__instance.def.defName != "TM_Mana" && __instance.def.defName != "TM_Stamina")
                {
                    __result = true;
                    return false;
                }
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Need))]
    class Need_ShowOnNeedList_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("ShowOnNeedList", MethodType.Getter)]
        public static bool ShowOnNeedList_ThrallPatch(ref Need __instance, ref Pawn ___pawn, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                if (__instance.def.defName != "TM_Mana" && __instance.def.defName != "TM_Stamina")
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
                if (__instance.def.defName != "TM_Mana" && __instance.def.defName != "TM_Stamina")
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
                if (__instance.def.defName != "TM_Mana" && __instance.def.defName != "TM_Stamina")
                {
                    __result = __instance.MaxLevel;
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// Because Chemical just has to be special
    /// </summary>

    [HarmonyPatch(typeof(Need_Chemical_Any))]
    class NeedChemicalAny_Disabled_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Disabled", MethodType.Getter)]
        public static void Disabled_ThrallPatch(ref Pawn ___pawn, ref bool __result)
        {
            if (!__result && ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                __result = true;
            }
        }
    }

    /// <summary>
    /// Because Indoors just has to be special
    /// </summary>
    [HarmonyPatch(typeof(Need_Indoors))]
    class NeedIndoors_Disabled_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Disabled", MethodType.Getter)]
        public static void Disabled_ThrallPatch(ref Pawn ___pawn, ref bool __result)
        {
            if (!__result && ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                __result = true;
            }
        }
    }

    /// <summary>
    /// Because Outdoors just has to be special
    /// </summary>
    [HarmonyPatch(typeof(Need_Outdoors))]
    class NeedOutdoors_Disabled_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Disabled", MethodType.Getter)]
        public static void Disabled_ThrallPatch(ref Pawn ___pawn, ref bool __result)
        {
            if (!__result && ESCP_NecromanticThralls_ModSettings.ThrallDisableNeeds && ThrallUtility.PawnIsThrall(___pawn))
            {
                __result = true;
            }
        }
    }
}