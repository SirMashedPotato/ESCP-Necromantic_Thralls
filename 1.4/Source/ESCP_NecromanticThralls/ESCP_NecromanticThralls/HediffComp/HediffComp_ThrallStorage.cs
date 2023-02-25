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
        public List<Pawn> thrallsList = new List<Pawn>();

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Collections.Look(ref thrallsList, "ESCP_NecromanticThralls", LookMode.Reference);
        }

        public int ThrallCount()
        {
            return thrallsList.NullOrEmpty() ? 0 : thrallsList.Count();
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

        public override void Notify_PawnDied()
        {
            KillThralls();
            base.Notify_PawnDied();
        }

        public override void Notify_PawnKilled()
        {
            KillThralls();
            base.Notify_PawnKilled();
        }

        public override IEnumerable<Gizmo> CompGetGizmos()
        {
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
