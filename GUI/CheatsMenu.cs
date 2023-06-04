using UnityEngine;

namespace DebugMod.GUI
{
    public static class CheatsMenu
    {
        public const int WINDOW_ID = 1;

        public static bool IsActive;

        private static Rect[] rects =
        {
            // Window rect
            new Rect(310, 0, 300, 190),

            // Fast Travel rect
            new Rect(10, 30, 280, 20),

            // Infinite Damage rect
            new Rect(10, 55, 280, 20),

            // Infinite Stamina rect
            new Rect(10, 80, 280, 20),

            // Invulnerability rect
            new Rect(10, 105, 280, 20),

            // No Cooldowns rect
            new Rect(10, 130, 280, 20),

            // Shiny Mode rect
            new Rect(10, 155, 280, 20)
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
            windowRect = UnityEngine.GUI.Window(WINDOW_ID, windowRect, (UnityEngine.GUI.WindowFunction)Menu, "Cheats Menu");
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

            FastTravel = UnityEngine.GUI.Button(rects[1], text);
        }

        private static void InfiniteDamageButton()
        {
            string[] text = { "Disable Infinite Damage", "Enable Infinite Damage" };
            string t = InfiniteDamage ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[2], t))
            {
                InfiniteDamage = !InfiniteDamage;
            }
        }
        private static void InfiniteStaminaButton()
        {
            string[] text = { "Disable Infinite Stamina", "Enable Infinite Stamina" };
            string t = InfiniteStamina ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[3], t))
            {
                InfiniteStamina = !InfiniteStamina;
            }
        }
        private static void InvulerabilityButton()
        {
            string[] text = { "Disable Invulnerability", "Enable Invulnerability" };
            string t = Invulnerability ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[4], t))
            {
                Invulnerability = !Invulnerability;
            }
        }
        private static void NoCooldownsButton()
        {
            string[] text = { "Enable Cooldowns", "Disable Cooldowns" };
            string t = NoCooldowns ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[5], t))
            {
                NoCooldowns = !NoCooldowns;
            }
        }
        private static void ShinyModeButton()
        {
            string[] text = { "Disable Shiny Mode", "Enable Shiny Mode" };
            string t = ShinyMode ? text[0] : text[1];

            if (UnityEngine.GUI.Button(rects[6], t))
            {
                ShinyMode = !ShinyMode;
            }
        }
    }
}
