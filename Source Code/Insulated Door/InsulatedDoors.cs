using Harmony;
using static STRINGS.UI;
using Database;
using System.Collections.Generic;

namespace InsulatedDoorsMod
{
    [HarmonyPatch(typeof(Db))]
    [HarmonyPatch("Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
#if VANILLA
            // Valilla prefers prefix() for adding buildings
            doorHelpers.doorBuildMenu(InsulatedManualPressureDoorConfig.ID, InsulatedManualPressureDoorConfig.menu, InsulatedManualPressureDoorConfig.pred);
            doorHelpers.doorBuildMenu(InsulatedPressureDoorConfig.ID, InsulatedPressureDoorConfig.menu, InsulatedPressureDoorConfig.pred);
            doorHelpers.doorBuildMenu(TinyInsulatedManualPressureDoorConfig.ID, TinyInsulatedManualPressureDoorConfig.menu, TinyInsulatedManualPressureDoorConfig.pred);
            doorHelpers.doorBuildMenu(TinyInsulatedPressureDoorConfig.ID, TinyInsulatedPressureDoorConfig.menu, TinyInsulatedPressureDoorConfig.pred);
#endif
        }

        public static void Postfix()
        {
#if SPACED_OUT
            // DLC prefers postfix() for adding buildings
            doorHelpers.doorBuildMenu(InsulatedManualPressureDoorConfig.ID, InsulatedManualPressureDoorConfig.menu, InsulatedManualPressureDoorConfig.pred);
            doorHelpers.doorBuildMenu(InsulatedPressureDoorConfig.ID, InsulatedPressureDoorConfig.menu,InsulatedPressureDoorConfig.pred);
            doorHelpers.doorBuildMenu(TinyInsulatedManualPressureDoorConfig.ID, TinyInsulatedManualPressureDoorConfig.menu, TinyInsulatedManualPressureDoorConfig.pred);
            doorHelpers.doorBuildMenu(TinyInsulatedPressureDoorConfig.ID, TinyInsulatedPressureDoorConfig.menu, TinyInsulatedPressureDoorConfig.pred);
#endif
            // Both prefer postfix() for adding tech tree entries
            doorHelpers.doorTechTree(InsulatedManualPressureDoorConfig.ID, InsulatedManualPressureDoorConfig.tech);
            doorHelpers.doorTechTree(InsulatedPressureDoorConfig.ID, InsulatedPressureDoorConfig.tech);
            doorHelpers.doorTechTree(TinyInsulatedManualPressureDoorConfig.ID, TinyInsulatedManualPressureDoorConfig.tech);
            doorHelpers.doorTechTree(TinyInsulatedPressureDoorConfig.ID, TinyInsulatedPressureDoorConfig.tech);
        }
    }

    [HarmonyPatch(typeof(BuildingComplete), "OnSpawn")]
    public class InsulatedDoor_BuildingComplete_OnSpawn
    {
        public static void Postfix(ref BuildingComplete __instance)
        {

            if (string.Compare(__instance.name, "InsulatedManualPressureDoorComplete") == 0)
            {
                __instance.gameObject.AddOrGet<InsulatingDoor>();
            }
            if (string.Compare(__instance.name, "InsulatedPressureDoorComplete") == 0)
            {
                __instance.gameObject.AddOrGet<InsulatingDoor>();
            }
            if (string.Compare(__instance.name, "TinyInsulatedManualPressureDoorComplete") == 0)
            {
                __instance.gameObject.AddOrGet<InsulatingDoor>();
            }
            if (string.Compare(__instance.name, "TinyInsulatedPressureDoorComplete") == 0)
            {
                __instance.gameObject.AddOrGet<InsulatingDoor>();
            }

            InsulatingDoor insulatingDoor = __instance.gameObject.GetComponent<InsulatingDoor>();

            if (insulatingDoor != null)
            {
                insulatingDoor.SetInsulation(__instance.gameObject, insulatingDoor.door.building.Def.ThermalConductivity);
            }
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
                public class INSULATEDMANUALPRESSUREDOOR
                {
                    public static LocString NAME = FormatAsLink("Insulated Manual Airlock", InsulatedManualPressureDoorConfig.ID);
                    public static LocString DESC = "The lowered thermal conductivity of insulated door slows any heat passing through them.";
                    public static LocString EFFECT = "Mantain temperature between two rooms";
                }
                public class INSULATEDPRESSUREDOOR
                {
                    public static LocString NAME = FormatAsLink("Insulated Mechanized Airlock", InsulatedPressureDoorConfig.ID);
                    public static LocString DESC = "Tiny Mechanized Airlocks fitted for very tiny duplicant.";
                    public static LocString EFFECT = "Mantain temperature between two rooms";
                }
                public class TINYINSULATEDMANUALPRESSUREDOOR
                {
                    public static LocString NAME = FormatAsLink("`Tiny Insulated Manual Airlock", TinyInsulatedManualPressureDoorConfig.ID);
                    public static LocString DESC = "The lowered thermal conductivity of insulated door slows any heat passing through them.";
                    public static LocString EFFECT = "Mantain temperature between two rooms";
                }
                public class TINYINSULATEDPRESSUREDOOR
                {
                    public static LocString NAME = FormatAsLink("Tiny Insulated Mechanized Airlock", TinyInsulatedPressureDoorConfig.ID);
                    public static LocString DESC = "Tiny Mechanized Airlocks fitted for very tiny duplicant.";
                    public static LocString EFFECT = "Mantain temperature between two rooms";
                }
            }
        }
    }
}
