using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace TinyPressureDoorInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class TinyPressureDoorInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYPRESSUREDOOR.NAME",
             UI.FormatAsLink ("Tiny Mechanized Airlock", "TINYPRESSUREDOOR")  
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYPRESSUREDOOR.DESC",
             "Tiny Mechanized Airlocks fitted for very tiny duplicant."
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYPRESSUREDOOR.EFFECT",
             "Blocks " + UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID") + " and " + UI.FormatAsLink("Gas", "ELEMENTS_GAS") + " flow, maintaining pressure between areas.\n\nFunctions as a " + UI.FormatAsLink("Manual Airlock", "TINYMANUALPRESSUREDOOR") + " when no " + UI.FormatAsLink("Power", "POWER") + " is available.\n\nWild " + UI.FormatAsLink("Critters", "CRITTERS") + " cannot pass through doors."
            });
            
            int index = TUNING.BUILDINGS.PLANORDER.FindIndex(x => x.category == "Base");
            if (index < 0)
                return;
            else
            {
                IList<string> data = TUNING.BUILDINGS.PLANORDER[index].data as IList<string>;
                int num = -1;
                foreach (string str in (IEnumerable<string>)data)
                {
                    if (str.Equals("PressureDoor"))
                        num = data.IndexOf(str);
                }
                if (num == -1)
                    return;
                else
                    data.Insert(num + 1, "TinyPressureDoor");
            }
        }
    }
}
