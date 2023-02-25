using UnityEngine;
using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    [StaticConstructorOnStartup]
    public class Gizmo_ThrallLimit : Gizmo
    {
        public override float GetWidth(float maxWidth)
        {
            return 140f;
        }

        public Gizmo_ThrallLimit(HediffComp_ThrallStorage compStorage)
        {
            thrallStorage = compStorage;
        }

        public override bool Visible => thrallStorage.ThrallLimit() > 0;

        public override GizmoResult GizmoOnGUI(Vector2 topLeft, float maxWidth, GizmoRenderParms parms)
        {
            Rect rect = new Rect(topLeft.x, topLeft.y, GetWidth(maxWidth), 75f);
            Rect rect2 = rect.ContractedBy(6f);
            Widgets.DrawWindowBackground(rect);
            Rect rect3 = rect2;
            rect3.height = rect.height / 2f;
            Text.Font = GameFont.Tiny;
            Widgets.Label(rect3, "ESCP_NecromanticThralls_ThrallLimitGizmo_Label".Translate());
            Rect rect4 = rect2;
            rect4.yMin = rect2.y + rect2.height / 2f;
            float fillPercent = thrallStorage.ThrallCount() / Mathf.Max(1f, thrallStorage.ThrallLimit());
            Widgets.FillableBar(rect4, fillPercent, FullBarTex, EmptyBarTex, false);
            Text.Font = GameFont.Small;
            Text.Anchor = TextAnchor.MiddleCenter;
            Widgets.Label(rect4, thrallStorage.ThrallCount() + "/" + thrallStorage.ThrallLimit());
            Text.Anchor = TextAnchor.UpperLeft;
            TooltipHandler.TipRegion(rect2, ExtraTooltipPart());
            return new GizmoResult(GizmoState.Clear);
        }

        public string ExtraTooltipPart()
        {
            string extra = "";
            Pawn p = thrallStorage.parent.pawn;
            SkillRecord skill = p.skills.GetSkill(thrallStorage.Props.skill ?? SkillDefOf.Intellectual);
            int skillLevel = skill.Level;
            extra += "ESCP_NecromanticThralls_ThrallLimitGizmo_BaseDesc".Translate(p.NameFullColored, skill.def.label);
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

            for (int i = 0; i < thrallStorage.Props.levelRequirement.Count; i++)
            {
                if (thrallStorage.Props.levelRequirement[i] <= curLevel)
                {
                    index = i + 1;
                }
            }
            if (index + 1 != thrallStorage.Props.levelRequirement.Count)
            {
                return "ESCP_NecromanticThralls_ExtraTooltip_Limit".Translate(thrallStorage.Props.thrallLimit[index] - thrallStorage.Props.thrallLimit[index - 1], thrallStorage.Props.levelRequirement[index], thrallStorage.Props.skill != null ? thrallStorage.Props.skill.label : SkillDefOf.Intellectual.label);
            }
            return "";
        }

        public HediffComp_ThrallStorage thrallStorage;
        private static readonly Texture2D FullBarTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.5f, 0.3f, 0.7f));
        private static readonly Texture2D EmptyBarTex = SolidColorMaterials.NewSolidColorTexture(Color.clear);
    }
}
