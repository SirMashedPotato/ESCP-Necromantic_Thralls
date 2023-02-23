using Verse;

namespace ESCP_NecromanticThralls
{
    public class ThrallImmune : DefModExtension
    {
        public static ThrallImmune Get(Def def)
        {
            return def.GetModExtension<ThrallImmune>();
        }
    }
}
