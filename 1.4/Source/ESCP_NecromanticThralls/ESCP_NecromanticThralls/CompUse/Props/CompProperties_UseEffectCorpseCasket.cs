using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    public class CompProperties_UseEffectCorpseCasket : CompProperties_UseEffect
    {
        public CompProperties_UseEffectCorpseCasket()
        {
            compClass = typeof(CompUseEffects_UseEffectCorpseCasket);
        }
        public ThingDef extraADef;
        public IntRange extraAAmount;
        public ThingDef extraBDef;
        public IntRange extraBAmount;
    }
}
