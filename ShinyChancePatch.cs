using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatchQuest;
using HarmonyLib;

namespace DebugMod
{
    [HarmonyPatch(typeof(ShinyChance))]
    [HarmonyPatch(nameof(ShinyChance.BASE_SHINY_CHANCE))]
    [HarmonyPatch(MethodType.Getter)]
    public static class ShinyChancePatch
    {
        public static void Postfix(ref float __result)
        {
            __result = int.MaxValue;
        }
    }
}
