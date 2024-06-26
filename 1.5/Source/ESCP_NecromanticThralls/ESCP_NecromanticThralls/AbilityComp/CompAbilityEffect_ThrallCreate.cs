﻿using Verse;
using RimWorld;
using System.Linq;

namespace ESCP_NecromanticThralls
{
    public class CompAbilityEffect_ThrallCreate : CompAbilityEffect
    {
        public new CompProperties_ThrallCreate Props
        {
            get
            {
                return (CompProperties_ThrallCreate)props;
            }
        }

        public HediffComp_ThrallStorage CompStorage()
        {
            if (compStorage == null)
            {
                Hediff hediffStorage = parent.pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_ThrallStorage);
                if (hediffStorage == null)
                {
                    Log.Error("ESCP_NecromanticThralls_ThrallStorage hediff not found, removing the create thrall ability");
                    parent.pawn.abilities.RemoveAbility(parent.def);
                }
                compStorage = hediffStorage.TryGetComp<HediffComp_ThrallStorage>();
                if (compStorage == null)
                {
                    Log.Error("HediffComp_ThrallStorage hediff comp not found, removing the create thrall ability");
                    parent.pawn.abilities.RemoveAbility(parent.def);
                }
            }
            return compStorage;
        }

        HediffComp_ThrallStorage compStorage = null;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Thing t = target.Thing;
            if (t != null && t is Corpse c)
            {
                Pawn p = c.InnerPawn;
                ///VE Psycasts, possibly a framework problem, errors when ressurecting a pawn
                ///Not normaly an issue, but it makes this ability shit the bed
                ///I'm being lazy, but this works
                try
                {
                    ResurrectionUtility.TryResurrect(c.InnerPawn);
                }
                catch
                {
                    
                }
                finally
                {
                    if (p != null)
                    {
                        if (p.guest != null)
                        {
                            p.guest = null;
                        }
                        RecruitUtility.Recruit(p, parent.pawn.Faction, parent.pawn);
                        if (p.Faction != parent.pawn.Faction)
                        {
                            p.SetFaction(parent.pawn.Faction, parent.pawn);
                        }
                        if (ModsConfig.IdeologyActive && p.RaceProps.Humanlike)
                        {
                            p.ideo.SetIdeo(parent.pawn.Ideo);
                        }
                        if (ESCP_NecromanticThralls_ModSettings.ThrallLimitedLifespan)
                        {
                            Hediff limitedLifeHediff = HediffMaker.MakeHediff(HediffDefOf.ESCP_NecromanticThralls_ThrallLifespan, p);
                            HediffComp_Disappears hediffComp_Disappears = limitedLifeHediff.TryGetComp<HediffComp_Disappears>();
                            hediffComp_Disappears.ticksToDisappear = ESCP_NecromanticThralls_ModSettings.ThrallLimitedLifespanDays * 60000;
                            p.health.AddHediff(limitedLifeHediff, null, null, null);
                        }
                        if (Props.hediff != null)
                        {
                            p.health.AddHediff(Props.hediff);
                            p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_Enthralled).TryGetComp<HediffComp_Enthralled>().SetMaster(parent.pawn);
                        }
                        if (ESCP_NecromanticThralls_ModSettings.ThrallResSkillDecay && p.RaceProps.Humanlike)
                        {
                            foreach (SkillRecord sr in p.skills.skills)
                            {
                                if (!sr.TotallyDisabled && sr.Level > 3 && Rand.Chance(0.75f))
                                {
                                    sr.Level -= sr.Level / 4;
                                }
                            }
                        }
                        CompStorage().AddThrall(p);
                    }
                }
            }
        }

        public override bool GizmoDisabled(out string reason)
        {
            if (Props.disablerPrecept != null && ModsConfig.IdeologyActive)
            {
                if (parent.pawn.ideo.Ideo.HasPrecept(Props.disablerPrecept))
                {
                    reason = "ESCP_NecromanticThralls_PreceptDisabled".Translate();
                    return true;
                }
            }
            if (parent.pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_NecromanticThralls_Enthralled) != null)
            {
                reason = "ESCP_NecromanticThralls_EntralledDisabled".Translate();
                return true;
            }

            int limit = CompStorage().ThrallLimit();
            int count = CompStorage().ThrallCount();
            if (limit <= count)
            {
                reason = "ESCP_NecromanticThralls_LimitReached".Translate(limit);
                return true;
            }
            return base.GizmoDisabled(out reason);
        }
    }
}
