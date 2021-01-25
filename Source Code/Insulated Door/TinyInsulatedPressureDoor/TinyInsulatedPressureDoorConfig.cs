using TUNING;
using UnityEngine;

public class TinyInsulatedPressureDoorConfig : IBuildingConfig
{
    public const string ID                                                           = "TinyInsulatedPressureDoor";
    // Which build menu to add to
    public const string menu = "Base";
    // Which item in build menu to add after
    public const string pred = "InsulatedPressureDoor";
    // Which tech tree entry to add to, "none" if no research is requried.
    public const string tech = "HVAC";

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
        string[] construction_materials                                              = strArray;
        EffectorValues none                                                          = NOISE_POLLUTION.NONE;
        EffectorValues tieR1                                                         = BUILDINGS.DECOR.PENALTY.TIER1;
        EffectorValues noise                                                         = none;
        BuildingDef buildingDef                                                      = BuildingTemplates.CreateBuildingDef("TinyInsulatedPressureDoor", 1, 1, "Tiny_Insulated_door_external_kanim", 30, 30f, construction_mass, construction_materials, 1600f, BuildLocationRule.Tile, tieR1, noise, 1f);
        buildingDef.ThermalConductivity                                              = 0.01f;
        buildingDef.Overheatable                                                     = false;
        buildingDef.RequiresPowerInput                                               = true;
        buildingDef.EnergyConsumptionWhenActive                                      = 90f;
        buildingDef.Floodable                                                        = false;
        buildingDef.Entombable                                                       = false;
        buildingDef.IsFoundation                                                     = true;
        buildingDef.ViewMode                                                         = OverlayModes.Power.ID;
        buildingDef.TileLayer                                                        = ObjectLayer.FoundationTile;
        buildingDef.AudioCategory                                                    = "Metal";
        buildingDef.PermittedRotations                                               = PermittedRotations.R90;
        buildingDef.SceneLayer                                                       = Grid.SceneLayer.TileMain;
        buildingDef.ForegroundLayer                                                  = Grid.SceneLayer.InteriorWall;
        buildingDef.LogicInputPorts                                                  = DoorConfig.CreateSingleInputPortList(new CellOffset(0, 0));
        SoundEventVolumeCache.instance.AddVolume("door_external_kanim", "Open_DoorPressure", NOISE_POLLUTION.NOISY.TIER2);
        SoundEventVolumeCache.instance.AddVolume("door_external_kanim", "Close_DoorPressure", NOISE_POLLUTION.NOISY.TIER2);
        return buildingDef;
    }

    public override void DoPostConfigureComplete(GameObject go)
    {
        Door door                                                                    = go.AddOrGet<Door>();
        door.hasComplexUserControls                                                  = true;
        door.unpoweredAnimSpeed                                                      = 0.65f;
        door.poweredAnimSpeed                                                        = 5f;
        door.doorClosingSoundEventName                                               = "MechanizedAirlock_closing";
        door.doorOpeningSoundEventName                                               = "MechanizedAirlock_opening";
        go.AddOrGet<Insulator>();
        go.AddOrGet<ZoneTile>();
        go.AddOrGet<AccessControl>();
        go.AddOrGet<KBoxCollider2D>();
        Prioritizable.AddRef(go);
        go.AddOrGet<CopyBuildingSettings>().copyGroupTag                             = GameTags.Door;
        go.AddOrGet<Workable>().workTime                                             = 5f;
        Object.DestroyImmediate((Object)go.GetComponent<BuildingEnabledButton>());
        ((AccessControl)go.GetComponent<AccessControl>()).controlEnabled             = true;
        ((KAnimControllerBase)go.GetComponent<KBatchedAnimController>()).initialAnim = "closed";
    }
}
