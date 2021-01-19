using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace TinyDoorInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class TinyDoorInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYDOOR.NAME",
             UI.FormatAsLink ("Tiny Pneumatic Door", "TINYDOOR")
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYDOOR.DESC",
             "Tiny Door, fitted for very tiny duplicant."
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYDOOR.EFFECT",
             "Encloses areas without blocking " + UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID") + " or " + UI.FormatAsLink("Gas", "ELEMENTS_GAS") + " flow.\n\nWild " + UI.FormatAsLink("Critters", "CRITTERS") + " cannot pass through doors."
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
                    if (str.Equals("Door"))
                        num = data.IndexOf(str);
                }
                if (num == -1)
                    return;
                else
                    data.Insert(num + 1, "TinyDoor");
            }
        }
    }
}
