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
				Messages.Message("ESCP_NecromanticThralls_KnowledgeGained".Translate(usedBy.Name, parent.Label), usedBy, MessageTypeDefOf.PositiveEvent);
			}
			if (Props.hediffDef != null)
			{
				usedBy.health.AddHediff(Props.hediffDef);
				Messages.Message("ESCP_NecromanticThralls_KnowledgeGained".Translate(usedBy.Name, parent.Label), usedBy, MessageTypeDefOf.PositiveEvent);
			}
			parent.Destroy();
		}

		public override bool CanBeUsedBy(Pawn p, out string failReason)
		{
			if (Props.abilityDef != null && p.abilities.GetAbility(Props.abilityDef) != null)
			{
				failReason = "ESCP_NecromanticThralls_BookAlreadyRead".Translate(p.Name);
				return false;
			}
			if (Props.hediffDef != null && p.health.hediffSet.HasHediff(Props.hediffDef))
			{
				failReason = "ESCP_NecromanticThralls_BookAlreadyRead".Translate(p.Name);
				return false;
			}
			return base.CanBeUsedBy(p, out failReason);
		}
	}
}
