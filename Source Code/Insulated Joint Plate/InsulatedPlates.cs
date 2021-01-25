using Harmony;
using static STRINGS.UI;
using Database;
using System.Collections.Generic;

namespace InsulatedPlatesMod
{
    [HarmonyPatch(typeof(Db))]
    [HarmonyPatch("Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
#if VANILLA
            // Vanilla prefers prefix() for adding buildings
            bridgeHelpers.bridgeBuildMenu(InsulatedWireBridgeHighWattageConfig.ID, InsulatedWireBridgeHighWattageConfig.menu, InsulatedWireBridgeHighWattageConfig.pred);
            bridgeHelpers.bridgeBuildMenu(InsulatedWireRefinedBridgeHighWattageConfig.ID, InsulatedWireRefinedBridgeHighWattageConfig.menu, InsulatedWireRefinedBridgeHighWattageConfig.pred);
            bridgeHelpers.bridgeBuildMenu(LongInsulatedWireBridgeHighWattageConfig.ID, LongInsulatedWireBridgeHighWattageConfig.menu, LongInsulatedWireBridgeHighWattageConfig.pred);
            bridgeHelpers.bridgeBuildMenu(LongInsulatedRefinedWireBridgeHighWattageConfig.ID, LongInsulatedRefinedWireBridgeHighWattageConfig.menu, LongInsulatedRefinedWireBridgeHighWattageConfig.pred);
#endif
        }

        public static void Postfix()
        {
#if SPACED_OUT
            // DLC prefers postfix() for adding buildings
            bridgeHelpers.bridgeBuildMenu(InsulatedWireBridgeHighWattageConfig.ID, InsulatedWireBridgeHighWattageConfig.menu, InsulatedWireBridgeHighWattageConfig.pred);
            bridgeHelpers.bridgeBuildMenu(InsulatedWireRefinedBridgeHighWattageConfig.ID, InsulatedWireRefinedBridgeHighWattageConfig.menu,InsulatedWireRefinedBridgeHighWattageConfig.pred);
            bridgeHelpers.bridgeBuildMenu(LongInsulatedWireBridgeHighWattageConfig.ID, LongInsulatedWireBridgeHighWattageConfig.menu, LongInsulatedWireBridgeHighWattageConfig.pred);
            bridgeHelpers.bridgeBuildMenu(LongInsulatedRefinedWireBridgeHighWattageConfig.ID, LongInsulatedRefinedWireBridgeHighWattageConfig.menu, LongInsulatedRefinedWireBridgeHighWattageConfig.pred);
#endif
            // Both prefer postfix() for adding tech tree entries
            bridgeHelpers.bridgeTechTree(InsulatedWireBridgeHighWattageConfig.ID, InsulatedWireBridgeHighWattageConfig.tech);
            bridgeHelpers.bridgeTechTree(InsulatedWireRefinedBridgeHighWattageConfig.ID, InsulatedWireRefinedBridgeHighWattageConfig.tech);
            bridgeHelpers.bridgeTechTree(LongInsulatedWireBridgeHighWattageConfig.ID, LongInsulatedWireBridgeHighWattageConfig.tech);
            bridgeHelpers.bridgeTechTree(LongInsulatedRefinedWireBridgeHighWattageConfig.ID, LongInsulatedRefinedWireBridgeHighWattageConfig.tech);
        }
    }

    [HarmonyPatch(typeof(BuildingComplete), "OnSpawn")]
    public class InsulatedBridge_BuildingComplete_OnSpawn
    {
        public static void Postfix(ref BuildingComplete __instance)
        {

            if (string.Compare(__instance.name, "LongInsulatedRefinedWireBridgeHighWattageComplete") == 0)
            {
                __instance.gameObject.AddOrGet<InsulatingPlate>();
            }
            if (string.Compare(__instance.name, "LongInsulatedWireBridgeHighWattageComplete") == 0)
            {
                __instance.gameObject.AddOrGet<InsulatingPlate>();
            }
            InsulatingPlate insulatingPlate = __instance.gameObject.GetComponent<InsulatingPlate>();

            if (insulatingPlate != null)
            {
                insulatingPlate.SetInsulation(__instance.gameObject, insulatingPlate.building.Def.ThermalConductivity);
            }
        }
    }

    public class bridgeHelpers
    {
        public static void bridgeBuildMenu(string door, string menu, string pred)
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

        public static void bridgeTechTree(string door, string group)
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
                public class INSULATEDWIREBRIDGEHIGHWATTAGE
                {
                    public static LocString NAME = FormatAsLink("Insulated Heavi-Watt Joint Plate", InsulatedWireBridgeHighWattageConfig.ID);
                    public static LocString DESC = "Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid.";
                    public static LocString EFFECT = "Insulated version. Allows " + FormatAsLink("Heavi-Watt Wire", "HIGHWATTAGEWIRE") + " to be run through wall and floor tile.\n\nFunctions as regular tile.";
                }
                public class INSULATEDWIREREFINEDBRIDGEHIGHWATTAGE
                {
                    public static LocString NAME = FormatAsLink("Insulated Heavi-Watt Conductive Joint Plate", InsulatedWireRefinedBridgeHighWattageConfig.ID);
                    public static LocString DESC = "Insulated Version. Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid.";
                    public static LocString EFFECT = "Insulated Version. Carries more than a regular Insulate Heavi-Watt Joint Plate without overloading.";
                }
                public class LONGINSULATEDWIREBRIDGEHIGHWATTAGE
                {
                    public static LocString NAME = FormatAsLink("Long Insulated Heavi-Watt Joint Plate", LongInsulatedWireBridgeHighWattageConfig.ID);
                    public static LocString DESC = "Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid.";
                    public static LocString EFFECT = "Insulated Long version. Allows " + FormatAsLink("Heavi-Watt Wire", "HIGHWATTAGEWIRE") + " to be run through wall and floor tile.\n\nFunctions as regular tile.";
                }
                public class LONGINSULATEDREFINEDWIREBRIDGEHIGHWATTAGE
                {
                    public static LocString NAME = FormatAsLink("Long Insulated Conductive Joint Plate", LongInsulatedRefinedWireBridgeHighWattageConfig.ID);
                    public static LocString DESC = "Insulated Long Version. Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid.";
                    public static LocString EFFECT = "Insulated Long Version. Carries more than a regular Insulate Heavi-Watt Joint Plate without overloading.";
                }
            }
        }
    }
}
