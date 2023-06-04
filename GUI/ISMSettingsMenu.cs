using UnityEngine;

namespace DebugMod.GUI
{
    public static class ISMSettingsMenu
    {
        public const int WINDOW_ID = 3;

        public static bool IsActive;
        private static Rect[] rects =
        {
            // Window rect
            new Rect(930, 0, 300, 135),

            // Hide player rect
            new Rect(10, 30, 280, 20),

            // Hide cursor rect
            new Rect(10, 55, 280, 20),

            // Hide shots rect
            new Rect(10, 80, 280, 20),

            // Warning label
            new Rect(10, 105, 280, 20)
        };
        private static Rect windowRect;

        public static bool HidePlayer { get; private set; }
        public static bool HideCursor { get; private set; }
        public static bool HideShots { get; private set; }   

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
            string text = "Hide Player";
            HidePlayer = UnityEngine.GUI.Toggle(rects[1], HidePlayer, text);
        }
        private static void HideCursorToggle()
        {
            string text = "Hide Cursor";
            HideCursor = UnityEngine.GUI.Toggle(rects[2], HideCursor, text);
        }
        private static void HideShotsToggle()
        {
            string text = "Hide Shots*";
            HideShots = UnityEngine.GUI.Toggle(rects[3], HideShots, text);
        }
        private static void WarningLabel()
        {
            string text = "*Can cause a significant amount of lag to enable and disable";
            UnityEngine.GUI.Label(rects[4], text);
        }
    }
}
