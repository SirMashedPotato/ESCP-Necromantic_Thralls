using Verse;

namespace ESCP_NecromanticThralls
{
    public class Gene_Necromancer : Gene
    {
		public override void PostAdd()
		{
			base.PostAdd();
			pawn.health.AddHediff(HediffDefOf.ESCP_NecromanticThralls_ThrallStorage);
		}
	}
}
