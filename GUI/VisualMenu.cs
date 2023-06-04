using UnityEngine;

namespace DebugMod.GUI
{
    public static class VisualMenu
    {
        public const int WINDOW_ID = 2;

        public static bool IsActive;

        private static Rect[] rects =
        {
            // Window rect
            new Rect(620, 0, 300, 85),

            // ISM Rect
            new Rect(10, 30, 185, 20),

            // ISM Settings Rect
            new Rect(200, 30, 90, 20),

            // Disable Fog
            new Rect(10, 55, 280, 20)
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
            windowRect = UnityEngine.GUI.Window(WINDOW_ID, windowRect, (UnityEngine.GUI.WindowFunction)Menu, "Visual Menu");
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
            string[] text = { "Disable ISM", "Enable ISM" };
            string t = ImprovedScreenshotMode ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[1], t))
            {
                ImprovedScreenshotMode = !ImprovedScreenshotMode;
            }

            if (ImprovedScreenshotMode)
            {
                Features.Visual.ISM.ImprovedScreenshotMode.EnableIsm();
            }
            else
            {
                Features.Visual.ISM.ImprovedScreenshotMode.DisableIsm();
            }
        }
        private static void ImprovedScreenshotModeSettingsButton()
        {
            string text = "Settings";

            if (UnityEngine.GUI.Button(rects[2], text))
            {
                ISMSettingsMenu.IsActive = !ISMSettingsMenu.IsActive;
            }
        }
        private static void DisableFogButton()
        {
            string[] text = { "Enable Fog", "Disable Fog" };
            string t = DisableFog ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[3], t))
            {
                DisableFog = !DisableFog;
            }
        }
    }
}
