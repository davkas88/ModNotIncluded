
using Database;
using Harmony;
using System.Collections.Generic;

namespace LongInsulatedRefinedWireBridgeHighWattagePatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class LongInsulatedWireRefinedBridgeHighWattageTech
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["PrettyGoodConductors"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["PrettyGoodConductors"])
            {
              "LongInsulatedRefinedWireBridgeHighWattage"
            }.ToArray();
        }
    }
}
