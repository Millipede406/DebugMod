using PatchQuest;
using DebugMod.GUI;

namespace DebugMod.Features.Visual
{
    public class DisableFog : IFeature
    {
        public void Initialize()
        {

        }

        public void Update()
        {
            if (VisualMenu.DisableFog)
            {
                Darkness.Intensity = 0f;
            }
        }
    }
}
