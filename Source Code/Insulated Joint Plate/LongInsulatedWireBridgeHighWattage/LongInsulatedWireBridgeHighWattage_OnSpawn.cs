
using Harmony;


[HarmonyPatch(typeof(BuildingComplete), "OnSpawn")]
public class LongInsulatedWireBridgeHighWattage_BuildingComplete_OnSpawn
{
    public static void Postfix(ref BuildingComplete __instance)
    {

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