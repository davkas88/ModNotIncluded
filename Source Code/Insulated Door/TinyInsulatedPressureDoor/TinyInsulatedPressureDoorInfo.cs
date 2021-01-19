using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace TinyInsulatedPressureDoorInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class TinyInsulatedPressureDoorInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYINSULATEDPRESSUREDOOR.NAME",
             UI.FormatAsLink ("Tiny Insulated Mechanized Airlock", "TINYINSULATEDPRESSUREDOOR")
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYINSULATEDPRESSUREDOOR.DESC",
             "The lowered thermal conductivity of insulated door slows any heat passing through them. Tiny version with extra cuteness"
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.TINYINSULATEDPRESSUREDOOR.EFFECT",
             "Mantain temperature between two rooms"
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
                    data.Insert(num + 1, "TinyInsulatedPressureDoor");
            }
        }
    }
}
