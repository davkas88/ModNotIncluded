using Database;
using Harmony;
using System.Collections.Generic;

namespace InsulatedManualPressureDoorPatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class InsulatedManualPressureDoor
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["TemperatureModulation"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["TemperatureModulation"])
            {
              "InsulatedManualPressureDoor"
            }.ToArray();
        }
    }
}
