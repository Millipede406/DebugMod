using UnityEngine;

namespace DebugMod.GUI
{
    public static class ISMSettingsMenu
    {
        // Improved Screenshot Mode Settings
        // - Hide player
        // - Hide cursor
        // - Hide shots
        public const int WINDOW_ID = 3;

        public static bool IsActive;
        private static Rect[] rects =
        {
            // Window rect
            new Rect(0, 0, 0, 0),

            // Hide player rect
            new Rect(0, 0, 0, 0),

            // Hide cursor rect
            new Rect(0, 0, 0, 0),

            // Hide shots rect
            new Rect(0, 0, 0, 0)
        };
        private static Rect windowRect;

        public static void InitializeMenu()
        {
            // Setting initial size and position of windowRect
            windowRect = rects[0];
        }

        public static void DrawMenu()
        {

        }
    }
}
