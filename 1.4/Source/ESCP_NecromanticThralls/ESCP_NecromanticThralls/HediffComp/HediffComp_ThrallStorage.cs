using System;
using Verse;
using RimWorld;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace ESCP_NecromanticThralls
{
    public class HediffComp_ThrallStorage : HediffComp
    {
        public HediffCompProperties_ThrallStorage Props
        {
            get
            {
                return (HediffCompProperties_ThrallStorage)props;
            }
        }

        public List<Pawn> thrallsList = new List<Pawn>();

        private Gizmo_ThrallLimit thrallLimitGizmo;

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Collections.Look(ref thrallsList, "ESCP_NecromanticThralls", LookMode.Reference);
        }

        public int ThrallCount()
        {
            return thrallsList.NullOrEmpty() ? 0 : thrallsList.Count();
        }

        public int ThrallLimit()
        {
            Pawn p = parent.pawn;
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

        public void AddThrall(Pawn pawn)
        {
            thrallsList.Add(pawn);
        }

        public void RemoveThrall(Pawn pawn)
        {
            thrallsList.Remove(pawn);
        }

        public void KillThralls()
        {
            while (thrallsList.Count() > 0)
            {
                thrallsList[0].Kill(null);
            }
        }

        /// <summary>
        /// Dev mode function, used to clear out missing references
        /// </summary>
        public int CleanThrallList()
        {
            int count = 0;
            int num = ThrallCount();
            List<Pawn> temp = new List<Pawn>();

            for (int i = 0; i < num; i++)
            {
                try
                {
                    if (thrallsList[i].Name != null)
                    {
                        temp.Add(thrallsList[i]);
                    }
                    else
                    {
                        count++;
                    }
                }
                catch (NullReferenceException)
                {
                    count++;
                }
            }
            thrallsList.Clear();
            thrallsList = temp;
            return count;
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (parent.pawn.Downed)
            {
                KillThralls();
            }
        }
        public override void Notify_PawnKilled()
        {
            KillThralls();
            base.Notify_PawnKilled();
        }

        public override IEnumerable<Gizmo> CompGetGizmos()
        {
            if (thrallLimitGizmo == null)
            {
                thrallLimitGizmo = new Gizmo_ThrallLimit(this);
            }
            yield return thrallLimitGizmo;
            yield return new Command_Action
            {
                defaultLabel = "ESCP_NecromanticThralls_SelectAllThralls".Translate(),
                defaultDesc = "ESCP_NecromanticThralls_SelectAllThralls_Tooltip".Translate(GetThrallList()),
                icon = ContentFinder<Texture2D>.Get("UI/Gizmos/ESCP_NecromanticThralls_SelectAllThralls", true),
                disabled = thrallsList.Count <= 0,
                onHover = delegate ()
                {
                    ShowThralls();
                },
                action = delegate ()
                {
                    Find.Selector.ClearSelection();
                    foreach(Pawn p in thrallsList)
                    {
                        Find.Selector.Select(p, true, true);
                    }
                }
            };
        }

        public StringBuilder GetThrallList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (ThrallCount() == 0)
            {
                stringBuilder.Append("  - None");
            }
            for (int i = 0; i < ThrallCount(); i++)
            {
                if (stringBuilder.Length != 0)
                {
                    stringBuilder.AppendLine();
                }
                stringBuilder.Append("  - " + thrallsList[i].LabelNoCountColored.Resolve() + " (" + thrallsList[i].def.label + ")");
            }
            return stringBuilder;
        }

        public void ShowThralls()
        {
            LookTargets targets = new LookTargets(thrallsList);
            if (targets != null)
            {
                targets.Highlight(true, true, false);
            }
        }
    }
}
