using TUNING;
using UnityEngine;

public class LongInsulatedRefinedWireBridgeHighWattageConfig : IBuildingConfig
{
    public const string ID = "LongInsulatedRefinedWireBridgeHighWattage";

    protected virtual string GetID()
    {
        return "LongInsulatedRefinedWireBridgeHighWattage";
    }

    public override BuildingDef CreateBuildingDef()
    {
        string id = this.GetID();
        string[] strArray = new string[2]
        {
          "BuildableRaw",
          "RefinedMetal"
        };
        float[] construction_mass = new float[2]
        {
          BUILDINGS.CONSTRUCTION_MASS_KG.TIER5[0],
          BUILDINGS.CONSTRUCTION_MASS_KG.TIER3[0]
        };
        string[] construction_materials = strArray;
        EffectorValues none = NOISE_POLLUTION.NONE;
        EffectorValues tieR5 = BUILDINGS.DECOR.PENALTY.TIER5;
        EffectorValues noise = none;
        BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, 2, 1, "LongInsulatedheavywatttile_conductive_kanim", 100, 3f, construction_mass, construction_materials, 1600f, BuildLocationRule.HighWattBridgeTile, tieR5, noise, 0.2f);
        BuildingTemplates.CreateFoundationTileDef(buildingDef);
        buildingDef.ThermalConductivity = 0.01f;
        buildingDef.Overheatable = false;
        buildingDef.Floodable = false;
        buildingDef.Entombable = false;
        buildingDef.UseStructureTemperature = false;
        buildingDef.ViewMode = OverlayModes.Power.ID;
        buildingDef.AudioCategory = "Metal";
        buildingDef.AudioSize = "small";
        buildingDef.BaseTimeUntilRepair = -1f;
        buildingDef.PermittedRotations = PermittedRotations.R360;
        buildingDef.UtilityInputOffset = new CellOffset(0, 0);
        buildingDef.UtilityOutputOffset = new CellOffset(0, 2);
        buildingDef.ObjectLayer = ObjectLayer.Building;
        buildingDef.SceneLayer = Grid.SceneLayer.WireBridgesFront;
        buildingDef.ForegroundLayer = Grid.SceneLayer.TileMain;
        GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, "LongInsulatedRefinedWireBridgeHighWattage");
        return buildingDef;
    }

    public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
    {
        BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
        GeneratedBuildings.MakeBuildingAlwaysOperational(go);
        SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
        simCellOccupier.doReplaceElement = true;
        simCellOccupier.movementSpeedMultiplier = DUPLICANTSTATS.MOVEMENT.PENALTY_3;
        go.AddOrGet<BuildingHP>().destroyOnDamaged = true;
        go.AddOrGet<Insulator>();
        go.AddOrGet<TileTemperature>();

    }

    public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
    {
        base.DoPostConfigurePreview(def, go);
        this.AddNetworkLink(go).visualizeOnly = true;
        go.AddOrGet<BuildingCellVisualizer>();
    }

    public override void DoPostConfigureUnderConstruction(GameObject go)
    {
        base.DoPostConfigureUnderConstruction(go);
        this.AddNetworkLink(go).visualizeOnly = true;
        go.AddOrGet<BuildingCellVisualizer>();
        go.GetComponent<Constructable>().requiredSkillPerk = (string)Db.Get().SkillPerks.CanPowerTinker.Id;
    }

    public override void DoPostConfigureComplete(GameObject go)
    {
        this.AddNetworkLink(go).visualizeOnly = false;
        go.GetComponent<KPrefabID>().AddTag(GameTags.WireBridges, false);
        go.AddOrGet<BuildingCellVisualizer>();
    }

    protected virtual WireUtilityNetworkLink AddNetworkLink(GameObject go)
    {
        WireUtilityNetworkLink utilityNetworkLink = go.AddOrGet<WireUtilityNetworkLink>();
        utilityNetworkLink.maxWattageRating = Wire.WattageRating.Max50000;
        utilityNetworkLink.link1 = new CellOffset(-1, 0);
        utilityNetworkLink.link2 = new CellOffset(2, 0);
        return utilityNetworkLink;
    }
}
