using Harmony;

[HarmonyPatch(typeof(BuildingComplete), "OnCleanUp")]
public class TinyInsulatedManualPressureDoor_BuildingComplete_OnCleanUp
{
    public static void Postfix(ref BuildingComplete __instance)
    {
       InsulatingDoor insulatingDoor = __instance.gameObject.GetComponent<InsulatingDoor>();

        if (insulatingDoor != null)
        {
            insulatingDoor.SetInsulation(__instance.gameObject, 1f);
        }
    }
}