using Verse;
using RimWorld;
using System.Collections.Generic;

namespace ESCP_NecromanticThralls
{
    public class HediffCompProperties_ThrallStorage : HediffCompProperties
    {
        public HediffCompProperties_ThrallStorage()
        {
            compClass = typeof(HediffComp_ThrallStorage);
        }

        public SkillDef skill;
        public List<int> thrallLimit;
        public List<int> levelRequirement;
        public int maxExtraLimit = 10;

        public override IEnumerable<string> ConfigErrors(HediffDef parentDef)
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
