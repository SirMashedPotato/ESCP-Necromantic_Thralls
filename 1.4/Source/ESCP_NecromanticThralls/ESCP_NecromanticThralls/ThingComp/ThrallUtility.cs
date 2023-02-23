using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    public static class ThrallUtility
    {
        public static bool ThingIsThrall(Thing t)
        {
            return t is Pawn p && PawnIsThrall(p);
        }

        public static bool PawnIsThrall(Pawn p)
        {
            if (p != null && !p.Dead)
            {
                if (p.Faction == null || Faction.OfPlayerSilentFail == null || p.Faction != Faction.OfPlayerSilentFail)
                {
                    return false;
                }
                /*
                if (p.def is AlienRace.ThingDef_AlienRace a && !a.alienRace.compatibility.IsFlesh)
                {
                    return false;
                }
                */
                if (!p.RaceProps.IsFlesh)
                {
                    return false;
                }
                if (p.health == null || p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_Enthralled) == null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
