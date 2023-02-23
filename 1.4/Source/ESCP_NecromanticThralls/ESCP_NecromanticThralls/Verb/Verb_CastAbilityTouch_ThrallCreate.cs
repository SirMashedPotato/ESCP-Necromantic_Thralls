using Verse;
using RimWorld;

namespace ESCP_NecromanticThralls
{
    public class Verb_CastAbilityTouch_ThrallCreate : Verb_CastAbilityTouch
    {
        public override bool ValidateTarget(LocalTargetInfo target, bool showMessages = true)
        {
            return base.ValidateTarget(target, showMessages) && IsValidCorpse(target.Thing);
        }
       
        public override bool IsUsableOn(Thing target)
        {
            return base.IsUsableOn(target) && IsValidCorpse(target);
        }

        public bool IsValidCorpse(Thing t)
        {
            if (t is Corpse c)
            {
                /*
                if (c.InnerPawn.def is ThingDef_AlienRace a && !a.alienRace.compatibility.IsFlesh)
                {
                    return false;
                }
                */
                /*
                if (!ESCP_Sload_ModSettings.SloadThrallCanDryad && c.InnerPawn.RaceProps.Dryad)
                {
                    return false;
                }
                */
                if (ThrallImmune.Get(c.InnerPawn.def) != null)
                {
                    return false;
                }
                if (c.InnerPawn.RaceProps.IsFlesh && c.GetRotStage() == RotStage.Fresh)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
