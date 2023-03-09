using UnityEngine;
using Verse;

namespace ESCP_NecromanticThralls
{
    public class ESCP_NecromanticThralls_Mod : Mod
    {
        ESCP_NecromanticThralls_ModSettings settings;
        public ESCP_NecromanticThralls_Mod(ModContentPack contentPack) : base(contentPack)
        {
            settings = GetSettings<ESCP_NecromanticThralls_ModSettings>();
        }

        public override string SettingsCategory() => "ESCP_NecromanticThralls_ModName".Translate();


        private static Vector2 scrollPosition = Vector2.zero;

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Rect outerRect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
            Rect innerRect = new Rect(0f, 0f, inRect.width - 30, inRect.height * 2);
            Widgets.BeginScrollView(outerRect, ref scrollPosition, innerRect, true);

            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            listing_Standard = SettingsPage_General(listing_Standard);

            listing_Standard.End();
            Widgets.EndScrollView();
            base.DoSettingsWindowContents(inRect);
        }


        private Listing_Standard SettingsPage_General(Listing_Standard listing_Standard)
        {
            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "ESCP_Reset".Translate());
            if (Widgets.ButtonText(rectDefault, "ESCP_Reset".Translate(), true, true, true))
            {
                ESCP_NecromanticThralls_ModSettings.ResetSettings();
            }
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            ///Name colours
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallNamesArePurple".Translate(), ref settings.ESCP_NecromanticThralls_ThrallNamesArePurple);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallNamesColourTranspilerA".Translate(), ref settings.ESCP_NecromanticThralls_ThrallNamesColourTranspilerA, "ESCP_NecromanticThralls_ThrallNamesColourTranspilerTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallNamesColourTranspilerB".Translate(), ref settings.ESCP_NecromanticThralls_ThrallNamesColourTranspilerB, "ESCP_NecromanticThralls_ThrallNamesColourTranspilerTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            ///Extras, default to disabled
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallCanDryad".Translate(), ref settings.ESCP_NecromanticThralls_ThrallCanDryad);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallDeathOnDown".Translate(), ref settings.ESCP_NecromanticThralls_ThrallDeathOnDown);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallResSkillDecay".Translate(), ref settings.ESCP_NecromanticThralls_ThrallResSkillDecay, "ESCP_NecromanticThralls_ThrallResSkillDecayTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallRotOnDeath".Translate(), ref settings.ESCP_NecromanticThralls_ThrallRotOnDeath, "ESCP_NecromanticThralls_ThrallRotOnDeath_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            ///Misc disabling
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallDisableNeeds".Translate(), ref settings.ESCP_NecromanticThralls_ThrallDisableNeeds);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallDisableMoods".Translate(), ref settings.ESCP_NecromanticThralls_ThrallDisableMoods);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallSkillLearning".Translate(), ref settings.ESCP_NecromanticThralls_ThrallSkillLearning);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallSkillDecay".Translate(), ref settings.ESCP_NecromanticThralls_ThrallSkillDecay);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallIdeoCertainty".Translate(), ref settings.ESCP_NecromanticThralls_ThrallIdeoCertainty);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallAgeing".Translate(), ref settings.ESCP_NecromanticThralls_ThrallAgeing);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            ///Health related disabling
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallDisableBloodloss".Translate(), ref settings.ESCP_NecromanticThralls_ThrallDisableBloodloss);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallDisableHeatstroke".Translate(), ref settings.ESCP_NecromanticThralls_ThrallDisableHeatstroke);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallDisableHypothermia".Translate(), ref settings.ESCP_NecromanticThralls_ThrallDisableHypothermia);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            ///Social related disabling
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallInspirations".Translate(), ref settings.ESCP_NecromanticThralls_ThrallInspirations);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallMentalBreaks".Translate(), ref settings.ESCP_NecromanticThralls_ThrallMentalBreaks);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallSocialInteractions".Translate(), ref settings.ESCP_NecromanticThralls_ThrallSocialInteractions);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            ///Animal related disabling
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallMilkable".Translate(), ref settings.ESCP_NecromanticThralls_ThrallMilkable);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallShearable".Translate(), ref settings.ESCP_NecromanticThralls_ThrallShearable);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallEggLaying".Translate(), ref settings.ESCP_NecromanticThralls_ThrallEggLaying);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallTrainable".Translate(), ref settings.ESCP_NecromanticThralls_ThrallTrainable);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallTrainableDecay".Translate(), ref settings.ESCP_NecromanticThralls_ThrallTrainableDecay);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallMating".Translate(), ref settings.ESCP_NecromanticThralls_ThrallMating);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            ///VFE Animal behaviours related disabling
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallVEF_AnimalProducts".Translate(), ref settings.ESCP_NecromanticThralls_ThrallVEF_AnimalProducts);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction".Translate(), ref settings.ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }
    }
}
