using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    public class CompProperties_ThrallCreate : CompProperties_AbilityEffect
    {
        public CompProperties_ThrallCreate()
        {
            compClass = typeof(CompAbilityEffect_ThrallCreate);
        }

        public HediffDef hediff = null;
        public PreceptDef disablerPrecept;
    }
}
