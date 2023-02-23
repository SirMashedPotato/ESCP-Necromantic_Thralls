using Verse;
using RimWorld;
using System.Collections.Generic;

namespace ESCP_NecromanticThralls
{
    public class CompProperties_ThrallCreate : CompProperties_AbilityEffect
    {
        public CompProperties_ThrallCreate()
        {
            compClass = typeof(CompAbilityEffect_ThrallCreate);
        }

        public SkillDef skill;
        public HediffDef hediff = null;
        public PreceptDef disablerPrecept;

        public List<int> thrallLimit;
        public List<int> levelRequirement;

        public override IEnumerable<string> ConfigErrors(AbilityDef parentDef)
        {
            foreach (string text in base.ConfigErrors(parentDef))
            {
                yield return text;
            }

            if (thrallLimit.Count != levelRequirement.Count)
            {
                yield return "the number of items in thrallLimit needs to match the number of items in levelRequirement";
            }
        }
    }
}
