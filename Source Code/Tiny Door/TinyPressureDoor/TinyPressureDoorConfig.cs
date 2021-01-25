using TUNING;
using UnityEngine;


public class TinyPressureDoorConfig : IBuildingConfig
{
    public const string ID = "TinyPressureDoor";
    // Which build menu to add to
    public const string menu = "Base";
    // Which item in build menu to add after
    public const string pred = "PressureDoor";
    // Which tech tree entry to add to, "none" if no research is requried.
    public const string tech = "DirectedAirStreams";

public override BuildingDef CreateBuildingDef()
    {
        float[] tieR4                           = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
        string[] allMetals                      = MATERIALS.ALL_METALS;
        EffectorValues none                     = NOISE_POLLUTION.NONE;
        EffectorValues tieR1                    = BUILDINGS.DECOR.PENALTY.TIER1;
        EffectorValues noise                    = none;
        BuildingDef buildingDef                 = BuildingTemplates.CreateBuildingDef("TinyPressureDoor", 1, 1, "Tiny_door_external_kanim", 30, 30f, tieR4, allMetals, 1600f, BuildLocationRule.Tile, tieR1, noise, 1f);
        buildingDef.Overheatable                = false;
        buildingDef.RequiresPowerInput          = true;
        buildingDef.EnergyConsumptionWhenActive = 60f;
        buildingDef.Floodable                   = false;
        buildingDef.Entombable                  = false;
        buildingDef.IsFoundation                = true;
        buildingDef.ViewMode                    = OverlayModes.Power.ID;
        buildingDef.TileLayer                   = ObjectLayer.FoundationTile;
        buildingDef.AudioCategory               = "Metal";
        buildingDef.PermittedRotations          = PermittedRotations.R90;
        buildingDef.SceneLayer                  = Grid.SceneLayer.TileMain;
        buildingDef.ForegroundLayer             = Grid.SceneLayer.InteriorWall;
        buildingDef.LogicInputPorts             = DoorConfig.CreateSingleInputPortList(new CellOffset(0, 0));
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

