﻿using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    public class CompUseEffect_UseEffectThrallLimitBook : CompUseEffect
	{
		public CompProperties_UseEffectThrallLimitBook Props
		{
			get
			{
				return (CompProperties_UseEffectThrallLimitBook)props;
			}
		}

		public override void DoEffect(Pawn usedBy)
		{
			base.DoEffect(usedBy);
			Hediff hediffStorage = usedBy.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_ThrallStorage);
			HediffComp_ThrallStorage compStorage = hediffStorage.TryGetComp<HediffComp_ThrallStorage>();
			compStorage.IncreaseThrallLimit(Props.limitIncrease);
			Messages.Message("ESCP_NecromanticThralls_KnowledgeGained".Translate(usedBy.Name, parent.Label), usedBy, MessageTypeDefOf.PositiveEvent);
			FleckMaker.ThrowDustPuff(parent.Position, parent.Map, 1f);
			parent.Destroy();
		}

        public override AcceptanceReport CanBeUsedBy(Pawn p)
        {
			Hediff hediffStorage = p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_ThrallStorage);
			if (hediffStorage == null)
			{
                return "ESCP_NecromanticThralls_BookRequiresKnowledge".Translate(p.Name);
			}
			HediffComp_ThrallStorage compStorage = hediffStorage.TryGetComp<HediffComp_ThrallStorage>();
			if (!compStorage.CanIncreaseThrallLimit())
			{
                return "ESCP_NecromanticThralls_BookAlreadyRead".Translate(p.Name);
			}
            return true;
        }
	}
}
