using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatchQuest;
using HarmonyLib;

namespace DebugMod.Features.Cheats
{
    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPatch(typeof(PlayerActions), nameof(PlayerActions.ActivateSkill))]
    public class CooldownsPatch
    {
        public static void Prefix(ref float cooldown)
        {
            cooldown = 0f;
        }
    }
}
