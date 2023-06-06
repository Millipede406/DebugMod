using DebugMod.GUI;

namespace DebugMod.Features.Utility
{
    public class ForceShowCursor : IFeature
    {
        public void Initialize()
        {

        }

        public void Update()
        {
            if (!UtilityMenu.ForceShowCursor)
            {
                return;
            }

            UnityEngine.Cursor.visible = true;
            UnityEngine.Screen.lockCursor = false;
        }
    }
}
