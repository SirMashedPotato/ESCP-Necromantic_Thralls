using Verse;
using RimWorld;
using System.Collections.Generic;
using System.Linq;

namespace ESCP_NecromanticThralls
{
    public class CompUseEffects_UseEffectCorpseCasket : CompUseEffect
	{
		public CompProperties_UseEffectCorpseCasket Props
		{
			get
			{
				return (CompProperties_UseEffectCorpseCasket)props;
			}
		}

		private IEnumerable<FactionDef> PossibleFactions()
		{
			return from td in DefDatabase<FactionDef>.AllDefs
				   where !td.isPlayer && td.humanlikeFaction && !td.pawnGroupMakers.NullOrEmpty()
				   select td;
		}


		private FactionDef RandomFaction()
		{
			return PossibleFactions().RandomElement();
		}


		public override void DoEffect(Pawn usedBy)
		{
			base.DoEffect(usedBy);

            if (Props.extraADef != null)
            {
				Thing thing = ThingMaker.MakeThing(Props.extraADef);
				thing.stackCount = Props.extraAAmount.RandomInRange;
				GenPlace.TryPlaceThing(thing, parent.Position, parent.Map, ThingPlaceMode.Near, null, null, default);
			}

			if (Props.extraBDef != null)
			{
				Thing thing = ThingMaker.MakeThing(Props.extraBDef);
				thing.stackCount = Props.extraBAmount.RandomInRange;
				GenPlace.TryPlaceThing(thing, parent.Position, parent.Map, ThingPlaceMode.Near, null, null, default);
			}

			PawnKindDef kindDef;
			FactionDef faction = RandomFaction();
			kindDef = faction.pawnGroupMakers.Where(x => !x.options.NullOrEmpty()).RandomElementByWeightWithFallback(x => x.commonality, faction.pawnGroupMakers.First()).options.RandomElementByWeightWithDefault(x => x.selectionWeight, 1).kind;
			Pawn pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(kindDef, FactionUtility.DefaultFactionFrom(faction) ?? null, PawnGenerationContext.NonPlayer, -1, true, false, false, true, false, 20f, false, true, false, true, true, false, false, false, false, 0f, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null, false, false, false, false, null, null, null, null, null, 0f, DevelopmentalStage.Adult, null, null, null, false));
			if (!pawn.Dead)
			{
				pawn.Kill(null, null);
			}
			GenPlace.TryPlaceThing(pawn, parent.Position, parent.Map, ThingPlaceMode.Near, null, null, default);

			parent.Destroy();
		}
	}
}
