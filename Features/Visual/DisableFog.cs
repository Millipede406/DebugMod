using PatchQuest;

namespace DebugMod.Features.Tools
{
    public static class DisableFog
    {
        public static void Update()
        {
            DebugConsole.Log("disableFog");
            Darkness.Intensity = 0f;
        }
    }
}
