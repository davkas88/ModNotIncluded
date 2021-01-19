using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace InsulatedPressureDoorInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class InsulatedPressureDoorInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDPRESSUREDOOR.NAME",
             UI.FormatAsLink ("Insulated Mechanized Airlock", "INSULATEDPRESSUREDOOR")
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDPRESSUREDOOR.DESC",
             "The lowered thermal conductivity of insulated door slows any heat passing through them."
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDPRESSUREDOOR.EFFECT",
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
                    data.Insert(num + 1, "InsulatedPressureDoor");
            }
        }
    }
}
