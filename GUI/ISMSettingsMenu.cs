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
            new Rect(0, 0, 0, 0),

            // Warning label
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
            // Draw the window
            windowRect = UnityEngine.GUI.Window(WINDOW_ID, windowRect, (UnityEngine.GUI.WindowFunction)Menu, "Improved Screenshot Mode Settings");
        }

        public static void Menu(int windowID)
        {
            // Draw window contents
            HidePlayerToggle();

            HideCursorToggle();

            HideShotsToggle();

            WarningLabel();

            // Make window draggable
            UnityEngine.GUI.DragWindow();
        }
        private static void HidePlayerToggle()
        {

        }
        private static void HideCursorToggle()
        {

        }
        private static void HideShotsToggle()
        {

        }
        private static void WarningLabel()
        {

        }
    }
}
