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

        public static void DrawMenu()
        {

        }
    }
}
