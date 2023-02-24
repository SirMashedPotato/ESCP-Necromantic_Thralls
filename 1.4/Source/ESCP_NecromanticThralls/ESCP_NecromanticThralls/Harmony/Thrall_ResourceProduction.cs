using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{
    [HarmonyPatch(typeof(CompMilkable))]
    class CompMilkable_Active_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Active", MethodType.Getter)]
        public static bool CompMilkable_Active_ThrallPatch(ref CompMilkable __instance, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableMilkable && ThrallUtility.PawnIsThrall(__instance.parent as Pawn))
            {
                __result = false;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(CompShearable))]
    class CompShearable_Active_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Active", MethodType.Getter)]
        public static bool CompShearable_Active_ThrallPatch(ref CompShearable __instance, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableShearable && ThrallUtility.PawnIsThrall(__instance.parent as Pawn))
            {
                __result = false;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(CompEggLayer))]
    class CompEggLayer_Active_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Active", MethodType.Getter)]
        public static bool CompEggLayer_Active_ThrallPatch(ref CompEggLayer __instance, ref bool __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallDisableEggLaying && ThrallUtility.PawnIsThrall(__instance.parent as Pawn))
            {
                __result = false;
                return false;
            }
            return true;
        }
    }

}
