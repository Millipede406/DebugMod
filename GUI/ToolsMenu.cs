using UnityEngine;

namespace DebugMod.GUI
{
    public static class ToolsMenu
    {
        // Tools Menu
        // Enable and disable different tools
        // - Improved Screenshot Mode
        // - Improved Screenshot Mode Settings
        // - Disable Fog
        public static bool IsActive;

        private static Rect[] rects =
        {
            // Window rect
            new Rect(0, 0, 0, 0),

            // ISM Rect
            new Rect(0, 0, 0, 0),

            // ISM Settings Rect
            new Rect(0, 0, 0, 0),

            // Disable Fog
            new Rect(0, 0, 0, 0)
        };
        private static Rect windowRect;

        public static bool ImprovedScreenshotMode { get; private set; }
        public static bool DisableFog { get; private set; }

        public static void InitializeMenu()
        {
            // Setting the initial size and position of windowRect
            windowRect = rects[0];
        }

        public static void DrawMenu()
        {

        }
    }
}
