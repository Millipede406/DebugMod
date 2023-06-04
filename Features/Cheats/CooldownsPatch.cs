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
            cooldown = 0f;
        }
    }
}
