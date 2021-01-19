using Harmony;

[HarmonyPatch(typeof(Door), "OnSimDoorClosed")]
public class TinyInsulatedPressureDoor_Door_Closed
{
    public static void Postfix(ref BuildingComplete __instance)
    {
        InsulatingDoor insulatingDoor = __instance.gameObject.GetComponent<InsulatingDoor>();

        if (insulatingDoor != null)
        {
            insulatingDoor.SetInsulation(__instance.gameObject, insulatingDoor.door.building.Def.ThermalConductivity);
        }
    }
}