using UnityEngine;

namespace DebugMod.GUI
{
    public static class CheatsMenu
    {
        // Cheats Menu
        // Enable and disable different cheats
        // - Fast Travel
        // - Infinite Damage
        // - Infinite Stamina
        // - Invulnerability
        // - No cooldowns
        // - Shiny Mode

        public static bool IsActive;

        private static Rect[] rects =
        {
            // Window rect
            new Rect(0, 0, 0, 0),

            // Fast Travel rect
            new Rect(0, 0, 0, 0),

            // Infinite Damage rect
            new Rect(0, 0, 0, 0),

            // Infinite Stamina rect
            new Rect(0, 0, 0, 0),

            // Invulnerability rect
            new Rect(0, 0, 0, 0),

            // No Cooldowns rect
            new Rect(0, 0, 0, 0),

            // Shiny Mode rect
            new Rect(0, 0, 0, 0)
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
            windowRect = UnityEngine.GUI.Window(1, windowRect, (UnityEngine.GUI.WindowFunction)Menu, "Cheats Menu");
        }

        public static void Menu(int windowID)
        {
            // Draw window contents
        }
    }
}
