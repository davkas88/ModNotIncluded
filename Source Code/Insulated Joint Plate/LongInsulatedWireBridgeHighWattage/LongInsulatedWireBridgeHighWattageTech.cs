
using Database;
using Harmony;
using System.Collections.Generic;

namespace LongInsulatedWireBridgeHighWattagePatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class LongInsulatedWireBridgeHighWattageTech
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["AdvancedPowerRegulation"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["AdvancedPowerRegulation"])
            {
              "LongInsulatedWireBridgeHighWattage"
            }.ToArray();
        }
    }
}
