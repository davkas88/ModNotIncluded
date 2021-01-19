using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace TinyManualPressureDoorInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class TinyManualPressureDoorInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYMANUALPRESSUREDOOR.NAME",
             UI.FormatAsLink ("Tiny Pressure Door", "TINYMANUALPRESSUREDOOR")
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYMANUALPRESSUREDOOR.DESC",
             "Tiny Manual Airlocks fitted for very tiny duplicant."
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYMANUALPRESSUREDOOR.EFFECT",
             "Blocks " + UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID") + " and " + UI.FormatAsLink("Gas", "ELEMENTS_GAS") + " flow, maintaining pressure between areas.\n\nWild " + UI.FormatAsLink("Critters", "CRITTERS") + " cannot pass through doors."
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
                    if (str.Equals("ManualPressureDoor"))
                        num = data.IndexOf(str);
                }
                if (num == -1)
                    return;
                else
                    data.Insert(num + 1, "TinyManualPressureDoor");
            }
        }
    }
}
