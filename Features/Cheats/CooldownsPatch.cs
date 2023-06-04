using DebugMod.GUI;
using HarmonyLib;
using PatchQuest;

namespace DebugMod.Features.Cheats
{
    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPatch(typeof(PlayerActions), nameof(PlayerActions.ActivateSkill))]
    public class CooldownsPatch
    {
        public static void Prefix(ref float cooldown)
        {
            if (CheatsMenu.NoCooldowns)
            {
                cooldown = 0f;
            }
        }
    }
}
