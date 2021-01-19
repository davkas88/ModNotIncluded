using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace InsulatedWireRefinedBridgeHighWattageInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class InsulatedWireRefinedBridgeHighWattageInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDWIREREFINEDBRIDGEHIGHWATTAGE.NAME",
             UI.FormatAsLink ("Insulated Heavi-Watt Conductive Joint Plate", "INSULATEDWIREREFINEDBRIDGEHIGHWATTAGE")
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDWIREREFINEDBRIDGEHIGHWATTAGE.DESC",
             "Insulated Version. Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid."
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDWIREREFINEDBRIDGEHIGHWATTAGE.EFFECT",
             "Insulated Version. Carries more than a regular Insulate Heavi-Watt Joint Plate without overloading."
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
                    data.Insert(num + 1, "InsulatedWireRefinedBridgeHighWattage");
            }
        }
    }
}
