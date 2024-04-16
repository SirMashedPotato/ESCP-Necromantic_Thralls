using RimWorld;
using Verse;

namespace ESCP_NecromanticThralls
{
    public class ThoughtWorker_ThrallThought : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            return ThrallUtility.PawnIsThrall(p);
        }
    }
}
