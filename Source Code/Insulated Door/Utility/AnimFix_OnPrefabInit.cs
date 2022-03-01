using HarmonyLib;
//without game crash
[HarmonyPatch(typeof(Door), "OnPrefabInit")]
internal class AnimDoor_Door_OnPrefabInit
{
    private static void Postfix(ref Door __instance)
    {
        __instance.overrideAnims = new KAnimFile[]
        {
            Assets.GetAnim("anim_use_remote_kanim")
        };
    }
}