using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    [DefOf]
    public static class HediffDefOf
	{
		static HediffDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
		}

		public static HediffDef ESCP_NecromanticThralls_Enthralled;
	}
}
