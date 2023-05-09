using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatchQuest;
using HarmonyLib;

namespace DebugMod
{
    [HarmonyPatch(MethodType.Getter)]
    [HarmonyPatch(typeof(ShinyChance), "get_BASE_SHINY_CHANCE")]
    public static class ShinyChancePatch
    {
        public static void Postfix(ref float __result)
        {
            __result = float.MaxValue;
        }
    }
}
