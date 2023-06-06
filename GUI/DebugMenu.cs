using UnityEngine;

namespace DebugMod.GUI
{
    public static class DebugMenu
    {
        public const int WINDOW_ID = 0;

        public static bool IsActive = true;

        private static Rect[] rects =
        {
            // Background
            new Rect(0, 0, 300, 135),

            // Cheats Menu button
            new Rect(10, 30, 280, 20),

            // Visual Menu button
            new Rect(10, 55, 280, 20),

            // Utility Menu button
            new Rect(10, 80, 280, 20),

            // Toggle Info text
            new Rect(10, 105, 280, 20)
        };
        private static Rect windowRect;

        public static void InitializeMenu()
        {
            // Setting the initial size and position of windowRect
            windowRect = rects[0];
        }
        public static void DrawMenu()
        {
            // Draw the window
            windowRect = UnityEngine.GUI.Window(WINDOW_ID, windowRect, (UnityEngine.GUI.WindowFunction)Menu, "Debug Menu");
        }
        public static void Menu(int windowID)
        {

            CheatsMenuButton();

            VisualMenuButton();

            ToggleInfoText();


            // Allow the window to be dragged around
            UnityEngine.GUI.DragWindow();
        }
        private static void CheatsMenuButton()
        {
            string[] text = { "Hide Cheats Menu", "Show Cheats Menu" };
            string t = CheatsMenu.IsActive ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[1], t))
            {
                // Button is pressed

                CheatsMenu.IsActive = !CheatsMenu.IsActive;
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void VisualMenuButton()
        {
            string[] text = { "Hide Visual Menu", "Show Visual Menu" };
            string t = VisualMenu.IsActive ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[2], t))
            {
                // Button is pressed

                VisualMenu.IsActive = !VisualMenu.IsActive;
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void UtilityMenuButton()
        {
            string[] text = { "Hide Utility Menu", "Show Utility Menu" };
            string t = VisualMenu.IsActive ? text[0] : text[1];

            if(UnityEngine.GUI.Button(rects[3], t))
            {
                UtilityMenu.IsActive = !UtilityMenu.IsActive;
            }
        }
        private static void ToggleInfoText()
        {
            string text = "Press F6 to Enable / Disable this menu";

            UnityEngine.GUI.Label(rects[4], text);
        }
    }
}
