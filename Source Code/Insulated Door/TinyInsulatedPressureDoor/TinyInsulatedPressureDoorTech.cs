
using Database;
using Harmony;
using System.Collections.Generic;

namespace TinyInsulatedPressureDoorPatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class TinyInsulatedPressureDoor
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["HVAC"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["HVAC"])
            {
              "TinyInsulatedPressureDoor"
            }.ToArray();
        }
    }
}
