using System.Collections.Generic;
using TUNING;
using UnityEngine;

public class TinyDoorConfig : IBuildingConfig
{
    public const string ID                                                           = "TinyDoor";
    // Which build menu to add to
    public const string menu = "Base";
    // Which item in build menu to add after
    public const string pred = "Door";
    // Which tech tree entry to add to, "none" if no research is requried.
    public const string tech = "none";

    public override BuildingDef CreateBuildingDef()
    {
        float[] tieR2                                                                = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
        string[] allMetals                                                           = MATERIALS.ALL_METALS;
        EffectorValues none1                                                         = TUNING.NOISE_POLLUTION.NONE;
        EffectorValues none2                                                         = TUNING.BUILDINGS.DECOR.NONE;
        EffectorValues noise                                                         = none1;
        BuildingDef buildingDef                                                      = BuildingTemplates.CreateBuildingDef("TinyDoor", 1, 1, "Tiny_door_internal_kanim", 30, 5f, tieR2, allMetals, 1600f, BuildLocationRule.Tile, none2, noise, 1f);
        buildingDef.Entombable                                                       = true;
        buildingDef.Floodable                                                        = false;
        buildingDef.IsFoundation                                                     = false;
        buildingDef.AudioCategory                                                    = "Metal";
        buildingDef.PermittedRotations                                               = PermittedRotations.R90;
        buildingDef.ForegroundLayer                                                  = Grid.SceneLayer.TileMain;
        buildingDef.LogicInputPorts                                                  = DoorConfig.CreateSingleInputPortList(new CellOffset(0, 0));
        SoundEventVolumeCache.instance.AddVolume("door_internal_kanim", "Open_DoorInternal", TUNING.NOISE_POLLUTION.NOISY.TIER2);
        SoundEventVolumeCache.instance.AddVolume("door_internal_kanim", "Close_DoorInternal", TUNING.NOISE_POLLUTION.NOISY.TIER2);
        return buildingDef;
    }

    public static List<LogicPorts.Port> CreateSingleInputPortList(CellOffset offset)
    {
        return new List<LogicPorts.Port>()
        {
          LogicPorts.Port.InputPort(Door.OPEN_CLOSE_PORT_ID, offset, (string) STRINGS.BUILDINGS.PREFABS.DOOR.LOGIC_OPEN, (string) STRINGS.BUILDINGS.PREFABS.DOOR.LOGIC_OPEN_ACTIVE, (string) STRINGS.BUILDINGS.PREFABS.DOOR.LOGIC_OPEN_INACTIVE, false, false)
        };
    }

    public override void DoPostConfigureComplete(GameObject go)
    {
        Door door                                                                    = go.AddOrGet<Door>();
        door.unpoweredAnimSpeed                                                      = 1f;
        door.doorType                                                                = Door.DoorType.Internal;
        door.doorOpeningSoundEventName                                               = "Open_DoorInternal";
        door.doorClosingSoundEventName                                               = "Close_DoorInternal";
        go.AddOrGet<AccessControl>().controlEnabled                                  = true;
        go.AddOrGet<CopyBuildingSettings>().copyGroupTag                             = GameTags.Door;
        go.AddOrGet<Workable>().workTime                                             = 3f;
        ((KAnimControllerBase)go.GetComponent<KBatchedAnimController>()).initialAnim = "closed";
        go.AddOrGet<ZoneTile>();
        go.AddOrGet<KBoxCollider2D>();
        Prioritizable.AddRef(go);
        Object.DestroyImmediate((Object)go.GetComponent<BuildingEnabledButton>());
    }
}
