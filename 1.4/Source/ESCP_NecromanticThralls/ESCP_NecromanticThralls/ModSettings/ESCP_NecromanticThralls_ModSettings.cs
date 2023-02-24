using Verse;

namespace ESCP_NecromanticThralls
{
    public class ESCP_NecromanticThralls_ModSettings : ModSettings
    {
        private static ESCP_NecromanticThralls_ModSettings _instance;

        /* ==========[GETTERS]========== */
        public static bool ThrallNamesArePurple => _instance.ESCP_NecromanticThralls_ThrallNamesArePurple;
        public static bool ThrallNamesColourTranspilerA => _instance.ESCP_NecromanticThralls_ThrallNamesColourTranspilerA;
        public static bool ThrallNamesColourTranspilerB => _instance.ESCP_NecromanticThralls_ThrallNamesColourTranspilerB;

        public static bool ThrallCanDryad => _instance.ESCP_NecromanticThralls_ThrallCanDryad;
        public static bool ThrallResSkillDecay => _instance.ESCP_NecromanticThralls_ThrallResSkillDecay;
        public static bool ThrallSkillLimit => _instance.ESCP_NecromanticThralls_ThrallSkillLimit;

        public static bool ThrallDisableNeeds => _instance.ESCP_NecromanticThralls_ThrallDisableNeeds;
        public static bool ThrallDisableMoods => _instance.ESCP_NecromanticThralls_ThrallDisableMoods;
        public static bool ThrallDisableIdeoCertainty => _instance.ESCP_NecromanticThralls_ThrallIdeoCertainty;
        public static bool ThrallDisableSkillLearning => _instance.ESCP_NecromanticThralls_ThrallSkillLearning;
        public static bool ThrallDisableSkillDecay => _instance.ESCP_NecromanticThralls_ThrallSkillDecay;
        public static bool ThrallDisableAgeing => _instance.ESCP_NecromanticThralls_ThrallAgeing;

        public static bool ThrallDisableBloodloss => _instance.ESCP_NecromanticThralls_ThrallDisableBloodloss;
        public static bool ThrallDisableHeatstroke => _instance.ESCP_NecromanticThralls_ThrallDisableHeatstroke;
        public static bool ThrallDisableHypothermia => _instance.ESCP_NecromanticThralls_ThrallDisableHypothermia;

        public static bool ThrallDisableInspirations => _instance.ESCP_NecromanticThralls_ThrallInspirations;
        public static bool ThrallDisableMentalBreaks => _instance.ESCP_NecromanticThralls_ThrallMentalBreaks;
        public static bool ThrallDisableSocialInteractions => _instance.ESCP_NecromanticThralls_ThrallSocialInteractions;


        public static bool ThrallDisableMilkable => _instance.ESCP_NecromanticThralls_ThrallMilkable;
        public static bool ThrallDisableShearable => _instance.ESCP_NecromanticThralls_ThrallShearable;
        public static bool ThrallDisableEggLaying => _instance.ESCP_NecromanticThralls_ThrallEggLaying;
        public static bool ThrallDisableTrainable => _instance.ESCP_NecromanticThralls_ThrallTrainable;
        public static bool ThrallDisableTrainableDecay => _instance.ESCP_NecromanticThralls_ThrallTrainableDecay;
        public static bool ThrallDisableMating => _instance.ESCP_NecromanticThralls_ThrallMating;

        public static bool ThrallVEF_DisableAnimalProducts => _instance.ESCP_NecromanticThralls_ThrallVEF_AnimalProducts;
        public static bool ThrallVEF_DisableAsexualReproduction => _instance.ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction;

        /* ==========[VARIABLES]========== */
        public bool ESCP_NecromanticThralls_ThrallNamesArePurple = ESCP_NecromanticThralls_ThrallNamesArePurple_def;
        public bool ESCP_NecromanticThralls_ThrallNamesColourTranspilerA = ESCP_NecromanticThralls_ThrallNamesColourTranspilerA_def;
        public bool ESCP_NecromanticThralls_ThrallNamesColourTranspilerB = ESCP_NecromanticThralls_ThrallNamesColourTranspilerB_def;

        public bool ESCP_NecromanticThralls_ThrallCanDryad = ESCP_NecromanticThralls_ThrallCanDryad_def;
        public bool ESCP_NecromanticThralls_ThrallResSkillDecay = ESCP_NecromanticThralls_ThrallResSkillDecay_def;
        public bool ESCP_NecromanticThralls_ThrallSkillLimit = ESCP_NecromanticThralls_ThrallSkillLimit_def;

        public bool ESCP_NecromanticThralls_ThrallDisableNeeds = ESCP_NecromanticThralls_ThrallDisableNeeds_def;
        public bool ESCP_NecromanticThralls_ThrallDisableMoods = ESCP_NecromanticThralls_ThrallDisableMoods_def;
        public bool ESCP_NecromanticThralls_ThrallIdeoCertainty = ESCP_NecromanticThralls_ThrallIdeoCertainty_def;
        public bool ESCP_NecromanticThralls_ThrallSkillLearning = ESCP_NecromanticThralls_ThrallSkillLearning_def;
        public bool ESCP_NecromanticThralls_ThrallSkillDecay = ESCP_NecromanticThralls_ThrallSkillDecay_def;
        public bool ESCP_NecromanticThralls_ThrallAgeing = ESCP_NecromanticThralls_ThrallAgeing_def;

        public bool ESCP_NecromanticThralls_ThrallDisableBloodloss = ESCP_NecromanticThralls_ThrallDisableBloodloss_def;
        public bool ESCP_NecromanticThralls_ThrallDisableHeatstroke = ESCP_NecromanticThralls_ThrallDisableHeatstroke_def;
        public bool ESCP_NecromanticThralls_ThrallDisableHypothermia = ESCP_NecromanticThralls_ThrallDisableHypothermia_def;

        public bool ESCP_NecromanticThralls_ThrallInspirations = ESCP_NecromanticThralls_ThrallInspirations_def;
        public bool ESCP_NecromanticThralls_ThrallMentalBreaks = ESCP_NecromanticThralls_ThrallMentalBreaks_def;
        public bool ESCP_NecromanticThralls_ThrallSocialInteractions = ESCP_NecromanticThralls_ThrallSocialInteractions_def;

        public bool ESCP_NecromanticThralls_ThrallMilkable = ESCP_NecromanticThralls_ThrallMilkable_def;
        public bool ESCP_NecromanticThralls_ThrallShearable = ESCP_NecromanticThralls_ThrallShearable_def;
        public bool ESCP_NecromanticThralls_ThrallEggLaying = ESCP_NecromanticThralls_ThrallEggLaying_def;
        public bool ESCP_NecromanticThralls_ThrallTrainable = ESCP_NecromanticThralls_ThrallTrainable_def;
        public bool ESCP_NecromanticThralls_ThrallTrainableDecay = ESCP_NecromanticThralls_ThrallTrainableDecay_def;
        public bool ESCP_NecromanticThralls_ThrallMating = ESCP_NecromanticThralls_ThrallMating_def;

        public bool ESCP_NecromanticThralls_ThrallVEF_AnimalProducts = ESCP_NecromanticThralls_ThrallVEF_AnimalProducts_def;
        public bool ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction = ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction_def;

        /* ==========[DEFAULTS]========== */
        private static readonly bool ESCP_NecromanticThralls_ThrallNamesArePurple_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallNamesColourTranspilerA_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallNamesColourTranspilerB_def = true;

        private static readonly bool ESCP_NecromanticThralls_ThrallCanDryad_def = false;
        private static readonly bool ESCP_NecromanticThralls_ThrallResSkillDecay_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallSkillLimit_def = false;

        private static readonly bool ESCP_NecromanticThralls_ThrallDisableNeeds_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallDisableMoods_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallIdeoCertainty_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallSkillLearning_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallSkillDecay_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallAgeing_def = true;

        private static readonly bool ESCP_NecromanticThralls_ThrallDisableBloodloss_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallDisableHeatstroke_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallDisableHypothermia_def = true;

        private static readonly bool ESCP_NecromanticThralls_ThrallInspirations_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallMentalBreaks_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallSocialInteractions_def = true;

        private static readonly bool ESCP_NecromanticThralls_ThrallMilkable_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallShearable_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallEggLaying_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallTrainable_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallTrainableDecay_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallMating_def = true;

        private static readonly bool ESCP_NecromanticThralls_ThrallVEF_AnimalProducts_def = true;
        private static readonly bool ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction_def = true;

        public ESCP_NecromanticThralls_ModSettings()
        {
            _instance = this;
        }

        /* ==========[SAVING]========== */
        public override void ExposeData()
        {
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallNamesArePurple, "ESCP_NecromanticThralls_ThrallNamesArePurple", ESCP_NecromanticThralls_ThrallNamesArePurple_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallNamesColourTranspilerA, "ESCP_NecromanticThralls_ThrallNamesColourTranspilerA", ESCP_NecromanticThralls_ThrallNamesColourTranspilerA_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallNamesColourTranspilerB, "ESCP_NecromanticThralls_ThrallNamesColourTranspilerB", ESCP_NecromanticThralls_ThrallNamesColourTranspilerB_def);

            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallCanDryad, "ESCP_NecromanticThralls_ThrallCanDryad", ESCP_NecromanticThralls_ThrallCanDryad_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallResSkillDecay, "ESCP_NecromanticThralls_ThrallResSkillDecay", ESCP_NecromanticThralls_ThrallResSkillDecay_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallSkillLimit, "ESCP_NecromanticThralls_ThrallSkillLimit", ESCP_NecromanticThralls_ThrallSkillLimit_def);

            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallDisableNeeds, "ESCP_NecromanticThralls_ThrallDisableNeeds", ESCP_NecromanticThralls_ThrallDisableNeeds_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallDisableMoods, "ESCP_NecromanticThralls_ThrallDisableMoods", ESCP_NecromanticThralls_ThrallDisableMoods_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallIdeoCertainty, "ESCP_NecromanticThralls_ThrallIdeoCertainty", ESCP_NecromanticThralls_ThrallIdeoCertainty_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallSkillLearning, "ESCP_NecromanticThralls_ThrallSkillLearning", ESCP_NecromanticThralls_ThrallSkillLearning_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallSkillDecay, "ESCP_NecromanticThralls_ThrallSkillDecay", ESCP_NecromanticThralls_ThrallSkillDecay_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallAgeing, "ESCP_NecromanticThralls_ThrallAgeing", ESCP_NecromanticThralls_ThrallAgeing_def);

            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallDisableBloodloss, "ESCP_NecromanticThralls_ThrallDisableBloodloss", ESCP_NecromanticThralls_ThrallDisableBloodloss_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallDisableHeatstroke, "ESCP_NecromanticThralls_ThrallDisableHeatstroke", ESCP_NecromanticThralls_ThrallDisableHeatstroke_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallDisableHypothermia, "ESCP_NecromanticThralls_ThrallDisableHypothermia", ESCP_NecromanticThralls_ThrallDisableHypothermia_def);

            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallInspirations, "ESCP_NecromanticThralls_ThrallInspirations", ESCP_NecromanticThralls_ThrallInspirations_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallMentalBreaks, "ESCP_NecromanticThralls_ThrallMentalBreaks", ESCP_NecromanticThralls_ThrallMentalBreaks_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallSocialInteractions, "ESCP_NecromanticThralls_ThrallSocialInteractions", ESCP_NecromanticThralls_ThrallSocialInteractions_def);

            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallMilkable, "ESCP_NecromanticThralls_ThrallMilkable", ESCP_NecromanticThralls_ThrallMilkable_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallShearable, "ESCP_NecromanticThralls_ThrallShearable", ESCP_NecromanticThralls_ThrallShearable_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallEggLaying, "ESCP_NecromanticThralls_ThrallEggLaying", ESCP_NecromanticThralls_ThrallEggLaying_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallTrainable, "ESCP_NecromanticThralls_ThrallTrainable", ESCP_NecromanticThralls_ThrallTrainable_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallTrainableDecay, "ESCP_NecromanticThralls_ThrallTrainableDecay", ESCP_NecromanticThralls_ThrallTrainableDecay_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallMating, "ESCP_NecromanticThralls_ThrallMating", ESCP_NecromanticThralls_ThrallMating_def);

            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallVEF_AnimalProducts, "ESCP_NecromanticThralls_ThrallVEF_AnimalProducts", ESCP_NecromanticThralls_ThrallVEF_AnimalProducts_def);
            Scribe_Values.Look(ref ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction, "ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction", ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction_def);
            base.ExposeData();
        }

        /* ==========[RESETTING]========== */
        public static void ResetSettings()
        {
            _instance.ESCP_NecromanticThralls_ThrallNamesArePurple = ESCP_NecromanticThralls_ThrallNamesArePurple_def;
            _instance.ESCP_NecromanticThralls_ThrallNamesColourTranspilerA = ESCP_NecromanticThralls_ThrallNamesColourTranspilerA_def;
            _instance.ESCP_NecromanticThralls_ThrallNamesColourTranspilerB = ESCP_NecromanticThralls_ThrallNamesColourTranspilerB_def;

            _instance.ESCP_NecromanticThralls_ThrallCanDryad = ESCP_NecromanticThralls_ThrallCanDryad_def;
            _instance.ESCP_NecromanticThralls_ThrallResSkillDecay = ESCP_NecromanticThralls_ThrallResSkillDecay_def;
            _instance.ESCP_NecromanticThralls_ThrallSkillLimit = ESCP_NecromanticThralls_ThrallSkillLimit_def;

            _instance.ESCP_NecromanticThralls_ThrallDisableNeeds = ESCP_NecromanticThralls_ThrallDisableNeeds_def;
            _instance.ESCP_NecromanticThralls_ThrallDisableMoods = ESCP_NecromanticThralls_ThrallDisableMoods_def;
            _instance.ESCP_NecromanticThralls_ThrallIdeoCertainty = ESCP_NecromanticThralls_ThrallIdeoCertainty_def;
            _instance.ESCP_NecromanticThralls_ThrallSkillLearning = ESCP_NecromanticThralls_ThrallSkillLearning_def;
            _instance.ESCP_NecromanticThralls_ThrallSkillDecay = ESCP_NecromanticThralls_ThrallSkillDecay_def;
            _instance.ESCP_NecromanticThralls_ThrallAgeing = ESCP_NecromanticThralls_ThrallAgeing_def;

            _instance.ESCP_NecromanticThralls_ThrallDisableBloodloss = ESCP_NecromanticThralls_ThrallDisableBloodloss_def;
            _instance.ESCP_NecromanticThralls_ThrallDisableHeatstroke = ESCP_NecromanticThralls_ThrallDisableHeatstroke_def;
            _instance.ESCP_NecromanticThralls_ThrallDisableHypothermia = ESCP_NecromanticThralls_ThrallDisableHypothermia_def;

            _instance.ESCP_NecromanticThralls_ThrallInspirations = ESCP_NecromanticThralls_ThrallInspirations_def;
            _instance.ESCP_NecromanticThralls_ThrallMentalBreaks = ESCP_NecromanticThralls_ThrallMentalBreaks_def;
            _instance.ESCP_NecromanticThralls_ThrallSocialInteractions = ESCP_NecromanticThralls_ThrallSocialInteractions_def;

            _instance.ESCP_NecromanticThralls_ThrallMilkable = ESCP_NecromanticThralls_ThrallMilkable_def;
            _instance.ESCP_NecromanticThralls_ThrallShearable = ESCP_NecromanticThralls_ThrallShearable_def;
            _instance.ESCP_NecromanticThralls_ThrallEggLaying = ESCP_NecromanticThralls_ThrallEggLaying_def;
            _instance.ESCP_NecromanticThralls_ThrallTrainable = ESCP_NecromanticThralls_ThrallTrainable_def;
            _instance.ESCP_NecromanticThralls_ThrallTrainableDecay = ESCP_NecromanticThralls_ThrallTrainableDecay_def;
            _instance.ESCP_NecromanticThralls_ThrallMating = ESCP_NecromanticThralls_ThrallMating_def;

            _instance.ESCP_NecromanticThralls_ThrallVEF_AnimalProducts = ESCP_NecromanticThralls_ThrallVEF_AnimalProducts_def;
            _instance.ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction = ESCP_NecromanticThralls_ThrallVEF_AsexualReproduction_def;
        }
    }
}
