using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    public class CompProperties_UseEffectThrallBook : CompProperties_UseEffect
    {
        public CompProperties_UseEffectThrallBook()
        {
            compClass = typeof(CompUseEffect_UseEffectThrallBook);
        }
        public AbilityDef abilityDef;
        public HediffDef hediffDef;
    }
}
