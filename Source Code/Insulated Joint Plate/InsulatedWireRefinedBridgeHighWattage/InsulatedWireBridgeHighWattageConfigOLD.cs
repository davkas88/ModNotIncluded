using TUNING;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InsulatedWireRefinedBridgeHighWattageConfig : InsulatetWireBridgeHighWattageConfig
{
    public new const string ID = "InsulatedWireRefinedBridgeHighWattage";

    protected override string GetID()
    {
        return "InsulatedWireRefinedBridgeHighWattage";
    }
   
    public override BuildingDef CreateBuildingDef()
    {
        string[] strArray = new string[2]
        {
          "BuildableRaw",
          "RefinedMetal"
        };
        float[] construction_mass = new float[2]
        {
          BUILDINGS.CONSTRUCTION_MASS_KG.TIER4[0],
          BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0]
        };
        string[] construction_materials = strArray;

        BuildingDef buildingDef = base.CreateBuildingDef();
        buildingDef.AnimFiles = new KAnimFile[1]
        {
         Assets.GetAnim("Insulatedheavywatttile_conductive_kanim")
        };

        buildingDef.ThermalConductivity = 0.01f;
        buildingDef.UseStructureTemperature = false;
        buildingDef.SceneLayer = Grid.SceneLayer.WireBridges;
        buildingDef.ForegroundLayer = Grid.SceneLayer.TileMain;
        GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, "InsulatedWireRefinedBridgeHighWattage");
        return buildingDef;
    }

    protected override WireUtilityNetworkLink AddNetworkLink(GameObject go)
    {
        WireUtilityNetworkLink utilityNetworkLink = base.AddNetworkLink(go);
        utilityNetworkLink.maxWattageRating = Wire.WattageRating.Max50000;
        return utilityNetworkLink;
    }

    public override void DoPostConfigureUnderConstruction(GameObject go)
    {
        base.DoPostConfigureUnderConstruction(go);
        ((Workable)go.GetComponent<Constructable>()).requiredSkillPerk = (string)Db.Get().SkillPerks.CanPowerTinker.Id;
    }
}
