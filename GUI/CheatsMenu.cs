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

        public static bool FastTravel { get; private set; }
        public static bool InfiniteDamage { get; private set; }
        public static bool InfiniteStamina { get; private set; }
        public static bool Invulnerability { get; private set; }
        public static bool NoCooldowns { get; private set; }
        public static bool ShinyMode { get; private set; }

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
            FastTravelButton();

            InfiniteDamageButton();

            InfiniteStaminaButton();

            InvulerabilityButton();

            NoCooldownsButton();

            ShinyModeButton();

            // Make the window draggable
            UnityEngine.GUI.DragWindow();
        }

        private static void FastTravelButton()
        {
            string text = "Fast Travel";

            if (UnityEngine.GUI.Button(rects[1], text))
            {
                // Button is pressed
            }
            else
            {
                // Button is not pressed
            }
        }

        private static void InfiniteDamageButton()
        {
            string[] text = { "Enable Infinite Damage", "Disable Infinite Damage" };
            string t = true ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[2], t))
            {
                // Button is pressed
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void InfiniteStaminaButton()
        {
            string[] text = { "Enable Infinite Stamina", "Disable Infinite Stamina" };
            string t = true ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[3], t))
            {
                // Button is pressed
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void InvulerabilityButton()
        {
            string[] text = { "Enable Invulnerability", "Disable Invulnerability" };
            string t = true ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[4], t))
            {
                // Button is pressed
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void NoCooldownsButton()
        {
            string[] text = { "Disable Cooldowns", "Enable Cooldowns" };
            string t = true ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[5], t))
            {
                // Button is pressed
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void ShinyModeButton()
        {
            string[] text = { "Enable Shiny Mode", "Disable Shiny Mode" };
            string t = true ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[6], t))
            {
                // Button is pressed
            }
            else
            {
                // Button is not pressed
            }
        }
    }
}
