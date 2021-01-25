using Harmony;
using static STRINGS.UI;
using Database;
using System.Collections.Generic;

namespace TinyDoorsMod
{
    [HarmonyPatch(typeof(Db))]
    [HarmonyPatch("Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
#if VANILLA
            // Valilla prefers prefix() for adding buildings
            doorHelpers.doorBuildMenu(TinyDoorConfig.ID, TinyDoorConfig.menu, TinyDoorConfig.pred);
            doorHelpers.doorBuildMenu(TinyPressureDoorConfig.ID, TinyPressureDoorConfig.menu,TinyPressureDoorConfig.pred);
            doorHelpers.doorBuildMenu(TinyManualPressureDoorConfig.ID, TinyManualPressureDoorConfig.menu, TinyManualPressureDoorConfig.pred);
#endif
        }

        public static void Postfix()
        {
#if SPACED_OUT
            // DLC prefers postfix() for adding buildings
            doorHelpers.doorBuildMenu(TinyDoorConfig.ID, TinyDoorConfig.menu, TinyDoorConfig.pred);
            doorHelpers.doorBuildMenu(TinyPressureDoorConfig.ID, TinyPressureDoorConfig.menu,TinyPressureDoorConfig.pred);
            doorHelpers.doorBuildMenu(TinyManualPressureDoorConfig.ID, TinyManualPressureDoorConfig.menu, TinyManualPressureDoorConfig.pred);
#endif
            // Both prefer postfix() for adding tech tree entries
            doorHelpers.doorTechTree(TinyDoorConfig.ID, TinyDoorConfig.tech);
            doorHelpers.doorTechTree(TinyPressureDoorConfig.ID, TinyPressureDoorConfig.tech);
            doorHelpers.doorTechTree(TinyManualPressureDoorConfig.ID, TinyManualPressureDoorConfig.tech);
        }
    }



    public class doorHelpers
    {
        public static void doorBuildMenu(string door, string menu, string pred)
        {
            int index = TUNING.BUILDINGS.PLANORDER.FindIndex(x => x.category == menu);
            if (index < 0)
                return;
            else
            {
                IList<string> data = TUNING.BUILDINGS.PLANORDER[index].data as IList<string>;
                int num = -1;
                foreach (string str in (IEnumerable<string>)data)
                {
                    if (str.Equals(pred))
                        num = data.IndexOf(str);
                }
                if (num == -1)
                    return;
                else
                    data.Insert(num + 1, door);
            }
        }

        public static void doorTechTree(string door, string group)
        {
            if (group == "none") return;
#if VANILLA
            Techs.TECH_GROUPING[group] = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING[group])
            {
                door
            }.ToArray();
#endif

#if SPACED_OUT
            var tech = Db.Get().Techs.TryGet(group);
		    if (tech != null)
		    {
			    tech.unlockedItemIDs.Add(door);
		    }
#endif
        }
    }

    public class STRINGS
    {
        public class BUILDINGS
        {
            public class PREFABS
            {
                public class TINYDOOR
                {
                    public static LocString NAME = FormatAsLink("Tiny Pneumatic Door", TinyDoorConfig.ID);
                    public static LocString DESC = "Tiny Door, fitted for very tiny duplicant.";
                    public static LocString EFFECT = "Encloses areas without blocking " + FormatAsLink("Liquid", "ELEMENTS_LIQUID") + " or " + FormatAsLink("Gas", "ELEMENTS_GAS") + " flow.\n\nWild " + FormatAsLink("Critters", "CRITTERS") + " cannot pass through doors.";
                }
                public class TINYPRESSUREDOOR
                {
                    public static LocString NAME = FormatAsLink("Tiny Mechanized Airlock", "TINYPRESSUREDOOR");
                    public static LocString DESC = "Tiny Mechanized Airlocks fitted for very tiny duplicant.";
                    public static LocString EFFECT = "Blocks " + FormatAsLink("Liquid", "ELEMENTS_LIQUID") + " and " + FormatAsLink("Gas", "ELEMENTS_GAS") + " flow, maintaining pressure between areas.\n\nFunctions as a " + FormatAsLink("Manual Airlock", "TINYMANUALPRESSUREDOOR") + " when no " + FormatAsLink("Power", "POWER") + " is available.\n\nWild " + FormatAsLink("Critters", "CRITTERS") + " cannot pass through doors.";
                }
                public class TINYMANUALPRESSUREDOOR
                {
                    public static LocString NAME = FormatAsLink("Tiny Manual Airlock", "TINYMANUALPRESSUREDOOR");
                    public static LocString DESC = "Tiny Manual Airlocks fitted for very tiny duplicant.";
                    public static LocString EFFECT = "Blocks " + FormatAsLink("Liquid", "ELEMENTS_LIQUID") + " and " + FormatAsLink("Gas", "ELEMENTS_GAS") + " flow, maintaining pressure between areas.\n\nWild " + FormatAsLink("Critters", "CRITTERS") + " cannot pass through doors.";
                }
            }
        }
    }
}
