using HarmonyLib;
using Verse;
using System.Reflection;

namespace ESCP_NecromanticThralls
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_NecromanticThralls");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
