using RimWorld;

namespace ESCP_NecromanticThralls
{
    [DefOf]
	public static class InteractionDefOf
	{

		static InteractionDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(InteractionDefOf));
		}

		public static InteractionDef Slight;
		public static InteractionDef KindWords;
	}
}
