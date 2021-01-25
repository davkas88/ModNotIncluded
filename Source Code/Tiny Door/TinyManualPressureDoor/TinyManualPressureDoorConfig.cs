using TUNING;
using UnityEngine;

   
  public class TinyManualPressureDoorConfig : IBuildingConfig
  {
    public const string ID                                                           = "TinyManualPressureDoor";
    // Which build menu to add to
    public const string menu = "Base";
    // Which item in build menu to add after
    public const string pred = "ManualPressureDoor";
    // Which tech tree entry to add to, "none" if no research is requried.
    public const string tech = "PressureManagement";

    public override BuildingDef CreateBuildingDef()
    {
        BuildingDef buildingDef                                                          = BuildingTemplates.CreateBuildingDef("TinyManualPressureDoor", 1, 1, "tiny_door_manual_kanim", 30, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER2, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Tile, BUILDINGS.DECOR.PENALTY.TIER2, NOISE_POLLUTION.NONE, 1f);
        buildingDef.Overheatable                                                         = false;
        buildingDef.Floodable                                                            = false;
        buildingDef.Entombable                                                           = false;
        buildingDef.IsFoundation                                                         = true;
        buildingDef.TileLayer                                                            = ObjectLayer.FoundationTile;
        buildingDef.AudioCategory                                                        = "Metal";
        buildingDef.PermittedRotations                                                   = PermittedRotations.R90;
        buildingDef.SceneLayer                                                           = Grid.SceneLayer.TileMain;
        buildingDef.ForegroundLayer                                                      = Grid.SceneLayer.InteriorWall;
        SoundEventVolumeCache.instance.AddVolume("door_manual_kanim", "ManualPressureDoor_gear_LP", NOISE_POLLUTION.NOISY.TIER1);
        SoundEventVolumeCache.instance.AddVolume("door_manual_kanim", "ManualPressureDoor_open", NOISE_POLLUTION.NOISY.TIER2);
        SoundEventVolumeCache.instance.AddVolume("door_manual_kanim", "ManualPressureDoor_close", NOISE_POLLUTION.NOISY.TIER2);
        return buildingDef;
    }

    public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
    {
        Door door                                                                    = go.AddOrGet<Door>();
        door.hasComplexUserControls                                                  = true;
        door.unpoweredAnimSpeed                                                      = 1f;
        door.doorClosingSoundEventName                                               = "ManualPressureDoor_gear_LP";
        door.doorOpeningSoundEventName                                               = "ManualPressureDoor_gear_LP";
        door.doorType                                                                = Door.DoorType.ManualPressure;
        go.AddOrGet<ZoneTile>();
        go.AddOrGet<AccessControl>();
        go.AddOrGet<KBoxCollider2D>();
        Prioritizable.AddRef(go);
        go.AddOrGet<CopyBuildingSettings>().copyGroupTag                             = GameTags.Door;
        go.AddOrGet<Workable>().workTime                                             = 5f;
        Object.DestroyImmediate((Object)go.GetComponent<BuildingEnabledButton>());
    }

    public override void DoPostConfigureComplete(GameObject go)
    {
        ((AccessControl)go.GetComponent<AccessControl>()).controlEnabled             = true;
        ((KAnimControllerBase)go.GetComponent<KBatchedAnimController>()).initialAnim = "closed";
    }
  }
