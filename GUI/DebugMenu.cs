﻿using System;
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
        public static bool IsActive;

        private static Rect[] rects =
        {
            // Background
            new Rect(0, 0, 300, 105),

            // Cheats Menu button
            new Rect(10, 30, 280, 20),

            // Tools Menu button
            new Rect(10, 55, 280, 20),

            // Toggle Info text
            new Rect(10, 80, 280, 20)
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
            windowRect = UnityEngine.GUI.Window(0, windowRect, (UnityEngine.GUI.WindowFunction)Menu, "Debug Menu");
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
            string[] text = { "Show Cheats Menu", "Hide Cheats Menu" };
            string t = CheatsMenu.IsActive ? text[0] : text[1];

            if(UnityEngine.GUI.Button(rects[1], t))
            {
                // Button is pressed
            }
            else
            {
                // Button is not pressed
            }
        }
        private static void ToolsMenuButton()
        {
            string[] text = { "Show Tools Menu", "Hide Tools Menu" };
            string t = ToolsMenu.IsActive ? text[0] : text[1];

            if(UnityEngine.GUI.Button(rects[2], t))
            {
                // Button is pressed
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