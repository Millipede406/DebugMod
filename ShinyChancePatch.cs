using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatchQuest;
using HarmonyLib;

namespace DebugMod
{
    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPatch(typeof(ShinyChance), nameof(ShinyChance.Roll))]
    public static class ShinyChancePatch
    {
        public static void Postfix(ref bool __result)
        {
            if(ModMain.ShinyMode)
                __result = true;
        }
    }
}
