using Harmony;

[HarmonyPatch(typeof(Door), "OnPrefabInit")]
internal class TinyInsulatedPressureDoor_Door_OnPrefabInit
{
    private static void Postfix(ref Door __instance)
    {
        Debug.Log("TinyInsulatedPressureDoor - Applying animation override");
        __instance.overrideAnims = new KAnimFile[]
        {
            Assets.GetAnim("anim_use_remote_kanim")
        };
    }
}