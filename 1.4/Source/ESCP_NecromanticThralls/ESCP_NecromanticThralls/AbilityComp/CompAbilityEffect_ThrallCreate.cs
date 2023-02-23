using Verse;
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

                p.SetFaction(parent.pawn.Faction, parent.pawn);
                if (ModsConfig.IdeologyActive && p.RaceProps.Humanlike)
                {
                    p.ideo.SetIdeo(parent.pawn.Ideo);
                }

                if (Props.hediff != null)
                {
                    p.health.AddHediff(Props.hediff).TryGetComp<HediffComp_Enthralled>().SetMaster(parent.pawn);
                }

                ResurrectionUtility.Resurrect(c.InnerPawn);
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

        public int CurrentLimit(Pawn p)
        {
            int curLevel = p.skills.GetSkill(Props.skill ?? SkillDefOf.Intellectual).Level;
            int index = 0;
            for (int i = 0; i < Props.levelRequirement.Count; i++)
            {
                if (Props.levelRequirement[i] <= curLevel)
                {
                    index = i;
                }
            }

            int limit = Props.thrallLimit[index];

            if (curLevel > 20)
            {
                int temp = curLevel - 20;
                limit += temp / 10;
            }
            /*
            if (p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_SloadThrassianElixir_Thrall) != null)
            {
                limit += 5;
            }
            */
            return limit;
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

            int limit = CurrentLimit(parent.pawn);
            int count = CompStorage().ThrallCount();
            if (limit <= count)
            {
                reason = "ESCP_NecromanticThralls_LimitReached".Translate(limit);
                return true;
            }
            return base.GizmoDisabled(out reason);
        }

        public override string ExtraTooltipPart()
        {
            string extra = "";
            Pawn p = parent.pawn;
            int limit = CurrentLimit(p);
            int count = CompStorage().ThrallCount();
            int skillLevel = p.skills.GetSkill(Props.skill ?? SkillDefOf.Intellectual).Level;
            extra += "ESCP_NecromanticThralls_ExtraTooltip_Count".Translate(count, limit);
            if (skillLevel < 20)
            {
                extra += GetTooltipExtra_Limit(p, skillLevel);
            }
            else
            {
                if (skillLevel > 20)
                {
                    extra += "ESCP_NecromanticThralls_ExtraTooltip_LimitUncapped".Translate();
                }
            }

            return extra;
        }

        public string GetTooltipExtra_Limit(Pawn p, int curLevel)
        {
            int index = 0;

            for (int i = 0; i < Props.levelRequirement.Count; i++)
            {
                if (Props.levelRequirement[i] <= curLevel)
                {
                    index = i + 1;
                }
            }
            if (index + 1 != Props.levelRequirement.Count())
            {
                return "ESCP_NecromanticThralls_ExtraTooltip_Limit".Translate(Props.thrallLimit[index] - Props.thrallLimit[index - 1], Props.levelRequirement[index], Props.skill != null ? Props.skill.label : SkillDefOf.Intellectual.label);
            }
            return "";
        }
    }
}
