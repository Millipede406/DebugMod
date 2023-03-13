using PatchQuest;
using HarmonyLib;

namespace DebugMod
{
    [HarmonyPatch(typeof(Scaling))]
    [HarmonyPatch(nameof(Scaling.BlasterDamageScale))]
    [HarmonyPatch(MethodType.Getter)]
    public static class InfiniteDamage
    {
        public static void Postfix(ref float __result)
        {
            if (ModMain.infDamage)
                __result = int.MaxValue;
        }
    }
}