
using Database;
using Harmony;
using System.Collections.Generic;

namespace TinyPressureDoorPatch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class TinyManualPressureDoorTech
    {
        private static void Prefix(Db __instance)
        {
            Techs.TECH_GROUPING["PressureManagement"] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["PressureManagement"])
            {
              "TinyManualPressureDoor"
            }.ToArray();
        }
    }
}
