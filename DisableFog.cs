using PatchQuest;

namespace DebugMod
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
