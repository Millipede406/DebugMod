using DebugMod.GUI;
using HarmonyLib;
using PatchQuest;

namespace DebugMod.Features.Cheats
{
    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPatch(typeof(ShinyChance), nameof(ShinyChance.Roll))]
    public static class ShinyChancePatch
    {
        public static void Postfix(ref bool __result)
        {
            if (CheatsMenu.ShinyMode)
                __result = true;
        }
    }
}
