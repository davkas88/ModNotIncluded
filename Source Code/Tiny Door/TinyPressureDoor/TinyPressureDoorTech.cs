
using Database;
using Harmony;
using System.Collections.Generic;

namespace TinyPressureDoorPatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class TinyPressureDoorTech
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["DirectedAirStreams"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["DirectedAirStreams"])
            {
              "TinyPressureDoor"
            }.ToArray();
        }
    }
}
