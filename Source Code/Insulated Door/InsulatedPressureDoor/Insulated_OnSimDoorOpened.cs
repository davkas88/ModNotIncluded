using Harmony;

[HarmonyPatch(typeof(Door), "OnSimDoorOpened")]
public class InsulatedPressureDoor_Door_OnSimDoorOpened
{
    public static void Postfix(ref Door __instance)
    {
        InsulatingDoor insulatingDoor = __instance.gameObject.GetComponent<InsulatingDoor>();

        if (insulatingDoor != null)
        {
            insulatingDoor.SetInsulation(__instance.gameObject, 0.01f);
        }
    }
}