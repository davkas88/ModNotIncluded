
using Database;
using Harmony;
using System.Collections.Generic;

namespace InsulatedManualPressureDoorPatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class TinyInsulatedManualPressureDoor
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["TemperatureModulation"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["TemperatureModulation"])
            {
              "TinyInsulatedManualPressureDoor"
            }.ToArray();
        }
    }
}
