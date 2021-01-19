
using Database;
using Harmony;
using System.Collections.Generic;

namespace InsulatedPressureDoorPatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class InsulatedPressureDoor
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["HVAC"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["HVAC"])
            {
              "InsulatedPressureDoor"
            }.ToArray();
        }
    }
}
