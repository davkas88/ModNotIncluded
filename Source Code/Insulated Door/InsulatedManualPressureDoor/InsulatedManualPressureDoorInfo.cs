using STRINGS;
using Harmony;
using System.Collections.Generic;

namespace InsulatedManualPressureDoorInfo
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class InsulatedManualPressureDoorInfo
    {
        private static void Prefix()
        {
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDMANUALPRESSUREDOOR.NAME",
             UI.FormatAsLink ("Insulated Manual Airlock","INSULATEDMANUALPRESSUREDOOR")
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDMANUALPRESSUREDOOR.DESC",
             "The lowered thermal conductivity of insulated door slows any heat passing through them."
            });
            Strings.Add(new string[2]
            {
             "STRINGS.BUILDINGS.PREFABS.INSULATEDMANUALPRESSUREDOOR.EFFECT",
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
                    if (str.Equals("ManualPressureDoor"))
                        num = data.IndexOf(str);
                }
                if (num == -1)
                    return;
                else
                    data.Insert(num + 1, "InsulatedManualPressureDoor");
            }
        }
    }
}
