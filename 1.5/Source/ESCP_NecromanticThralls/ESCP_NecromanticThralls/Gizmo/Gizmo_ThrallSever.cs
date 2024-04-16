using Verse;
using System.Collections.Generic;

namespace ESCP_NecromanticThralls
{
    [StaticConstructorOnStartup]
    public class Gizmo_SeverThrall : Command_Action
    {
        public Gizmo_SeverThrall(HediffComp_ThrallStorage compStorage)
        {
            thrallStorage = compStorage;
        }


        public override IEnumerable<FloatMenuOption> RightClickFloatMenuOptions
        {
            get
            {
                foreach (Pawn thrall in thrallStorage.thrallsList)
                {
                    yield return new FloatMenuOption(thrall.NameFullColored, delegate ()
                    {
                        thrall.Kill(null);
                    });
                }
            }
        }

        public HediffComp_ThrallStorage thrallStorage;
    }
}
