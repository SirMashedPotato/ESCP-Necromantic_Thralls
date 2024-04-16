using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    public class CompUseEffect_UseEffectThrallBook : CompUseEffect
	{
		public CompProperties_UseEffectThrallBook Props
		{
			get
			{
				return (CompProperties_UseEffectThrallBook)props;
			}
		}

		public override void DoEffect(Pawn usedBy)
		{
			base.DoEffect(usedBy);
			if (Props.abilityDef != null)
			{
				usedBy.abilities.GainAbility(Props.abilityDef);
			}
			if (Props.hediffDef != null)
			{
				usedBy.health.AddHediff(Props.hediffDef);
			}
			Messages.Message("ESCP_NecromanticThralls_KnowledgeGained".Translate(usedBy.Name, parent.Label), usedBy, MessageTypeDefOf.PositiveEvent);
			FleckMaker.ThrowDustPuff(parent.Position, parent.Map, 1f);
			parent.Destroy();
		}

        public override AcceptanceReport CanBeUsedBy(Pawn p)
        {
			if (Props.abilityDef != null && p.abilities.GetAbility(Props.abilityDef) != null)
			{
				return "ESCP_NecromanticThralls_BookAlreadyRead".Translate(p.Name);
			}
			if (Props.hediffDef != null && p.health.hediffSet.HasHediff(Props.hediffDef))
			{
				return "ESCP_NecromanticThralls_BookAlreadyRead".Translate(p.Name);
			}
            return true;
        }
	}
}
