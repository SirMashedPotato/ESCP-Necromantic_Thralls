using RimWorld;

namespace ESCP_NecromanticThralls
{
	[DefOf]
	public static class ThoughtDefOf
	{

		static ThoughtDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(ThoughtDefOf));
		}

		public static ThoughtDef ESCP_NecromanticThralls_ThrallThought;
	}
}
