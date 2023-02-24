using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

namespace ESCP_NecromanticThralls
{
    public static class ThrallTextColour
    {
        public static Color thrallTextColor = new Color(0.8f, 0.6f, 1.0f);

        public static string ThrallColourChanger(string str, Pawn p)
        {
            if (ThrallUtility.PawnIsThrall(p))
            {
                str = str.Colorize(PawnNameColorUtility.PawnNameColorOf(p));
            }
            return str;
        }


        public static Color GetThrallColour(Color other, Pawn p)
        {
            return p != null && ThrallUtility.PawnIsThrall(p) ? thrallTextColor : other;
        }
    }

    //colonist bar, pawn labels etc
    [HarmonyPatch(typeof(PawnNameColorUtility))]
    [HarmonyPatch("PawnNameColorOf")]
    public static class PawnNameColorUtility_PawnNameColorOf_Patch
    {
        [HarmonyPrefix]
        public static bool PawnNameColorOf_ThrallPatch(ref Pawn pawn, ref Color __result)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallNamesArePurple && ThrallUtility.PawnIsThrall(pawn))
            {
                __result = ThrallTextColour.thrallTextColor;
                return false;
            }
            return true;
        }
    }

    //tabs, work, assign etc
    [HarmonyPatch(typeof(PawnColumnWorker_Label))]
    [HarmonyPatch("DoCell")]
    public static class PawnColumnWorker_Label_DoCell_Patch
    {
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallNamesColourTranspilerA)
            {
                var codes = new List<CodeInstruction>(instructions);
                //used for checking for the right function call
                var target = AccessTools.Method(typeof(Widgets), nameof(Widgets.Label), new Type[] { typeof(Rect), typeof(string) });
                //function that is called
                var isThrall = AccessTools.Method(typeof(ThrallTextColour), nameof(ThrallTextColour.ThrallColourChanger));

                //find the right position in the stack
                for (int i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Call && codes[i].operand == target)
                    {
                        var original = codes[i];    //store original method, return after
                        //loc 2 = rectangle
                        //loc 1 = string
                        yield return new CodeInstruction(OpCodes.Ldarg_2); //load pawn
                        yield return new CodeInstruction(OpCodes.Call, isThrall);   //add in custom check
                        yield return original;  //return original after

                    }
                    else
                    {
                        yield return codes[i];
                    }
                }
            }
        }
    }

    //caravan dialogue
    [HarmonyPatch(typeof(TransferableOneWayWidget))]
    [HarmonyPatch("DoRow")]
    public static class TransferableOneWayWidget_DoRow_Patch
    {
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            if (ESCP_NecromanticThralls_ModSettings.ThrallNamesColourTranspilerB)
            {
                var codes = new List<CodeInstruction>(instructions);
                //used for checking for the right function call
                var target = AccessTools.Method(typeof(TransferableUIUtility), nameof(TransferableUIUtility.DrawTransferableInfo), new Type[] { typeof(TransferableOneWay), typeof(Rect), typeof(Color) });
                //function that is called
                var isThrall = AccessTools.Method(typeof(ThrallTextColour), nameof(ThrallTextColour.GetThrallColour));
                //find the right position in the stack
                for (int i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Call && codes[i].operand == target)
                    {
                        var original = codes[i];    //store original method, return after
                        //label string already loaded
                        yield return new CodeInstruction(OpCodes.Ldloc_2);  //load pawn
                        yield return new CodeInstruction(OpCodes.Call, isThrall);   //add in custom check
                        yield return original;  //return original after
                    }
                    else
                    {
                        yield return codes[i];
                    }
                }
            }
        }
    }
}