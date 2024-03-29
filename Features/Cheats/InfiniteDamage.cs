﻿using DebugMod.GUI;
using HarmonyLib;
using PatchQuest;

namespace DebugMod.Features.Cheats
{
    [HarmonyPatch(typeof(Scaling))]
    [HarmonyPatch(nameof(Scaling.BlasterDamageScale))]
    [HarmonyPatch(MethodType.Getter)]
    public static class InfiniteBlasterDamage
    {
        public static void Postfix(ref float __result)
        {
            if (CheatsMenu.InfiniteDamage)
                __result = int.MaxValue;
        }
    }

    [HarmonyPatch(typeof(Scaling))]
    [HarmonyPatch(nameof(Scaling.RidingDamageScale))]
    [HarmonyPatch(MethodType.Getter)]
    public static class InfiniteMountDamage
    {
        public static void Postfix(ref float __result)
        {
            if (CheatsMenu.InfiniteDamage)
                __result = int.MaxValue;
        }
    }
}