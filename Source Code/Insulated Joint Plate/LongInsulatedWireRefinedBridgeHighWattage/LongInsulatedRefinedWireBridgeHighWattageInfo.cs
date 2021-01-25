using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace LongInsulatedRefinedWireBridgeHighWattageInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class LongInsulatedRefinedWireBridgeHighWattageInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.LONGINSULATEDREFINEDWIREBRIDGEHIGHWATTAGE.NAME",
             UI.FormatAsLink ("Long Insulated Conductive Joint Platee", "LONGINSULATEDREFINEDWIREBRIDGEHIGHWATTAGE")
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.LONGINSULATEDREFINEDWIREBRIDGEHIGHWATTAGE.DESC",
             "Insulated Long Version. Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid."
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.LONGINSULATEDREFINEDWIREBRIDGEHIGHWATTAGE.EFFECT",
             "Insulated Long Version. Carries more than a regular Insulate Heavi-Watt Joint Plate without overloading."
            });
            
            int index = TUNING.BUILDINGS.PLANORDER.FindIndex(x => x.category == "Power");
            if (index < 0)
                return;
            else
            {
                IList<string> data = TUNING.BUILDINGS.PLANORDER[index].data as IList<string>;
                int num = -1;
                foreach (string str in (IEnumerable<string>)data)
                {
                    if (str.Equals("WireRefinedBridgeHighWattage"))
                        num = data.IndexOf(str);
                }
                if (num == -1)
                    return;
                else
                    data.Insert(num + 1, "LongInsulatedRefinedWireBridgeHighWattage");
            }
        }
    }
}
