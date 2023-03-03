using PatchQuest;

namespace DebugMod
{
    public static class DisableFog
    {
        public static void Update()
        {
            Darkness.Intensity = 0f;
        }
    }
}
