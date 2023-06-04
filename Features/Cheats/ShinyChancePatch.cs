using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatchQuest;
using HarmonyLib;
using DebugMod.GUI;

namespace DebugMod.Features.Cheats
{
    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPatch(typeof(ShinyChance), nameof(ShinyChance.Roll))]
    public static class ShinyChancePatch
    {
        public static void Postfix(ref bool __result)
        {
            if(CheatsMenu.ShinyMode)
                __result = true;
        }
    }
}
