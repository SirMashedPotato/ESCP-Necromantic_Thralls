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

        public int extraThrallLimit = 0;

        private Gizmo_ThrallLimit thrallLimitGizmo;
        private Gizmo_SeverThrall thrallSeverGizmo;

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Values.Look(ref extraThrallLimit, "ESCP_NecromanticThralls_ExtraLimit");
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
            
            return limit + extraThrallLimit;
        }

        public bool CanIncreaseThrallLimit()
        {
            return extraThrallLimit < Props.maxExtraLimit;
        }

        public void IncreaseThrallLimit(int increase)
        {
            extraThrallLimit += increase;
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

            if (parent.pawn.Downed && ESCP_NecromanticThralls_ModSettings.ThrallDeathOnDown)
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

            if (thrallSeverGizmo == null)
            {
                thrallSeverGizmo = new Gizmo_SeverThrall(this)
                {
                    defaultLabel = "ESCP_NecromanticThralls_SelectAllThralls".Translate(),
                    icon = ContentFinder<Texture2D>.Get("UI/Gizmos/ESCP_NecromanticThralls_SelectAllThralls", true),
                    disabled = thrallsList.Count <= 0,
                    onHover = delegate ()
                    {
                        ShowThralls();
                    },
                    action = delegate ()
                    {
                        Find.Selector.ClearSelection();
                        foreach (Pawn p in thrallsList)
                        {
                            if (p.Spawned)
                            {
                                Find.Selector.Select(p, true, true);
                            }
                        }
                    }
                };
            }
            thrallSeverGizmo.defaultDesc = "ESCP_NecromanticThralls_SelectAllThralls_Tooltip".Translate(GetThrallList());
            yield return thrallSeverGizmo;
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
