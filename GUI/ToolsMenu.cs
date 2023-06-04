using UnityEngine;

namespace DebugMod.GUI
{
    public static class ToolsMenu
    {
        public const int WINDOW_ID = 2;

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
            // Draw the window
            windowRect = UnityEngine.GUI.Window(WINDOW_ID, windowRect, (UnityEngine.GUI.WindowFunction)Menu, "Tools Menu");
        }
        public static void Menu(int windowID)
        {
            //Draw window contents
            ImprovedScreenshotModeButton();

            ImprovedScreenshotModeSettingsButton();

            DisableFogButton();


            // Make the window draggable
            UnityEngine.GUI.DragWindow();
        }
        private static void ImprovedScreenshotModeButton()
        {
            string[] text = { "Disable ISM", "Enable ISMe" };
            string t = ImprovedScreenshotMode ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[1], t))
            {
                ImprovedScreenshotMode = !ImprovedScreenshotMode;
            }
        }
        private static void ImprovedScreenshotModeSettingsButton()
        {
            string text = "Settings";

            if(UnityEngine.GUI.Button(rects[2], text))
            {
                // Enable the ISM Settings Menu
            }
        }
        private static void DisableFogButton()
        {
            string[] text = { "Enable Fog", "Disable Fog" };
            string t = DisableFog ? text[0] : text[1];

            if(UnityEngine.GUI.Button(rects[3], t))
            {
                DisableFog = !DisableFog;
            }
        }
    }
}
