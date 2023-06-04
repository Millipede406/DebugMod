using PatchQuest;

namespace DebugMod.Features.Visual
{
    public static class DisableFog
    {
        public static void Update()
        {
            Darkness.Intensity = 0f;
        }
    }
}
