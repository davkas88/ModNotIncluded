
using Database;
using Harmony;
using System.Collections.Generic;

namespace InsulatedWireBridgeHighWattagePatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class InsulatedWireBridgeHighWattageTech
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["AdvancedPowerRegulation"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["AdvancedPowerRegulation"])
            {
              "InsulatedWireBridgeHighWattage"
            }.ToArray();
        }
    }
}
