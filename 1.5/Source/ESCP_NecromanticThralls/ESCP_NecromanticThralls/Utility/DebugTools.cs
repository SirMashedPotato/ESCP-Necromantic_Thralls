using Verse;
using RimWorld;
using LudeonTK;

namespace ESCP_NecromanticThralls
{
    public static class DebugTools
    {
        [DebugAction("ESCP - Necromantic Thralls", "Clean Missing necromantic Thralls", false, false, actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void Sload_CleanThrallList(Pawn p)
        {
            if (p.health != null)
            {
                Hediff hediff = p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_ThrallStorage);
                if (hediff != null)
                {
                    int num = hediff.TryGetComp<HediffComp_ThrallStorage>().CleanThrallList();
                    Messages.Message("ESCP_NecromanticThralls_CleanThrallList_Message".Translate(p.NameFullColored, num), MessageTypeDefOf.NeutralEvent, false);
                }
            }
        }
    }
}
