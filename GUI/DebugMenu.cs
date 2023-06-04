using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;

namespace DebugMod.GUI
{
    public static class DebugMenu
    {
        public const int WINDOW_ID = 0;

        public static bool IsActive = true;

        private static Rect[] rects =
        {
            // Background
            new Rect(0, 0, 300, 125),

            // Cheats Menu button
            new Rect(10, 30, 280, 20),

            // Tools Menu button
            new Rect(10, 55, 280, 20),

            // Toggle Info text
            new Rect(10, 80, 280, 40)
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

            ToolsMenuButton();

            ToggleInfoText();


            // Allow the window to be dragged around
            UnityEngine.GUI.DragWindow();
        }
        private static void CheatsMenuButton()
        {
            string[] text = { "Hide Cheats Menu", "Show Cheats Menu" };
            string t = CheatsMenu.IsActive ? text[0] : text[1];

            if(UnityEngine.GUI.Button(rects[1], t))
            {
                // Button is pressed

                CheatsMenu.IsActive = !CheatsMenu.IsActive;
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void ToolsMenuButton()
        {
            string[] text = { "Hide Visual Menu", "Show Visual Menu" };
            string t = VisualMenu.IsActive ? text[0] : text[1];

            if(UnityEngine.GUI.Button(rects[2], t))
            {
                // Button is pressed

                VisualMenu.IsActive = !VisualMenu.IsActive;
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void ToggleInfoText()
        {
            string text = "Press F6 to Enable / Disable this menu";

            UnityEngine.GUI.Label(rects[3], text);
        }
    }
}
