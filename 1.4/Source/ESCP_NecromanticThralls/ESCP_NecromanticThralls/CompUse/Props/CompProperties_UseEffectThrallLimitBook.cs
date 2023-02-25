using RimWorld;

namespace ESCP_NecromanticThralls
{
    public class CompProperties_UseEffectThrallLimitBook : CompProperties_UseEffect
    {
        public CompProperties_UseEffectThrallLimitBook()
        {
            compClass = typeof(CompUseEffect_UseEffectThrallLimitBook);
        }
        public int limitIncrease;
    }
}
