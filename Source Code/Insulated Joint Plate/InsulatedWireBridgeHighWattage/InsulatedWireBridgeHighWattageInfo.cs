using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace InsulatedWireBridgeHighWattageInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class InsulatedWireBridgeHighWattageInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDWIREBRIDGEHIGHWATTAGE.NAME",
             UI.FormatAsLink ("Insulated Heavi-Watt Joint Plate", "INSULATEDWIREBRIDGEHIGHWATTAGE")
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDWIREBRIDGEHIGHWATTAGE.DESC",
             "Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid."
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDWIREBRIDGEHIGHWATTAGE.EFFECT",
             "Insulated version. Allows " + UI.FormatAsLink("Heavi-Watt Wire", "HIGHWATTAGEWIRE") + " to be run through wall and floor tile.\n\nFunctions as regular tile."
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
                    if (str.Equals("WireBridgeHighWattage"))
                        num = data.IndexOf(str);
                }
                if (num == -1)
                    return;
                else
                    data.Insert(num + 1, "InsulatedWireBridgeHighWattage");
            }
        }
    }
}
