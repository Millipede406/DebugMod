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
            Console.Log(Console.LogType.Feature, "Force Show Cursor update");
            if (!UtilityMenu.ForceShowCursor)
            {
                return;
            }

            Console.Log(Console.LogType.Feature, "Force Show Cursor active");

            UnityEngine.Cursor.visible = true;
            UnityEngine.Screen.lockCursor = false;
        }
    }
}
