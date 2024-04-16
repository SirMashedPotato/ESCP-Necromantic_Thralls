using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ESCP_NecromanticThralls
{
    public class HediffComp_Enthralled : HediffComp
    {
		public Pawn Master
		{
			get
			{
				return master;
			}
		}

		public void SetMaster(Pawn p)
		{
			if (p != null)
			{
				master = p;
			}
		}

		public override void CompExposeData()
		{
			base.CompExposeData();
			Scribe_References.Look(ref master, "master", false);
		}

		public override IEnumerable<Gizmo> CompGetGizmos()
		{
			yield return new Command_Action
			{
				defaultLabel = "ESCP_NecromanticThralls_SelectMaster".Translate(),
				defaultDesc = "ESCP_NecromanticThralls_SelectMaster_Tooltip".Translate(master.Name),
				icon = ContentFinder<Texture2D>.Get("UI/Gizmos/ESCP_NecromanticThralls_SelectMaster", true),
				onHover = delegate ()
				{
					ShowMaster();
				},
				action = delegate ()
				{
					Find.Selector.ClearSelection();
					Find.Selector.Select(master, true, true);
				}
			};
			yield return new Command_Action
			{
				defaultLabel = "ESCP_NecromanticThralls_KillThrall".Translate(),
				defaultDesc = "ESCP_NecromanticThralls_Kill_Tooltip".Translate(master.Name),
				icon = ContentFinder<Texture2D>.Get("UI/Gizmos/ESCP_NecromanticThralls_DisbandThrall", true),
				onHover = delegate ()
				{
					ShowMaster();
				},
				action = delegate ()
				{
					Pawn.Kill(null);
				}
			};
		}

		public void ShowMaster()
		{
			LookTargets target = new LookTargets(Master);
			if (target != null)
			{
				target.Highlight(true, true, false);
			}
		}

		int ticks = 0;

		public override void CompPostTick(ref float severityAdjustment)
		{
			base.CompPostTick(ref severityAdjustment);
			ticks++;
			if (ticks >= 1000)
			{
				if (Pawn.Faction == null || Pawn.Faction != Faction.OfPlayer || Master.Destroyed || Master.Dead || master.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_ThrallStorage) == null)
				{
					Pawn.Kill(null);
				}
				ticks = 0;
			}
		}

		public override void CompPostPostRemoved()
		{
			if (master != null)
			{
				master.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_ThrallStorage).TryGetComp<HediffComp_ThrallStorage>().RemoveThrall(Pawn);
			}
			base.CompPostPostRemoved();
		}

		public override void Notify_PawnDied()
		{
            if (ESCP_NecromanticThralls_ModSettings.ThrallRotOnDeath)
            {
				Corpse corpse = parent.pawn.Corpse;
				if (corpse != null && corpse.Map != null)
				{
					var rot = corpse.GetComp<CompRottable>();
					if (rot != null)
					{
						rot.RotProgress = rot.PropsRot.TicksToRotStart;
					}
				}
			}
			base.Notify_PawnDied();
		}

		public override string CompLabelInBracketsExtra => master?.Name.ToString();

		private Pawn master = null;
	}
}
