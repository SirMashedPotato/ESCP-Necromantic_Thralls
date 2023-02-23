using Verse;

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
                if (p.health != null && p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_Enthralled) != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
