using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DebugMod.GUI
{
    public static class UtilityMenu
    {
        public const int WINDOW_ID = 4;

        public static bool IsActive;

        private static Rect[] rects =
        {
            // Window rect
            new Rect(1240, 0, 300, 60),

            // Force Show Cursor
            new Rect(10, 30, 280, 20)
        };

        private static Rect windowRect;

        public static bool ForceShowCursor { get; private set; } = false;

        public static void InitializeMenu()
        {
            // Setting initial size and position of windowRect
            windowRect = rects[0];
        }

        public static void DrawMenu()
        {
            // Draw the window
            windowRect = UnityEngine.GUI.Window(WINDOW_ID, windowRect, (UnityEngine.GUI.WindowFunction)Menu, "Utility Menu");
        }

        public static void Menu(int windowID)
        {
            // Draw window contents
            ForceShowCursorButton();

            // Making the window draggable
            UnityEngine.GUI.DragWindow();
        }

        private static void ForceShowCursorButton()
        {
            string text = "Force Show Cursor";
            string t = text + (ForceShowCursor ? " [ON]" : " [OFF]");

            if(UnityEngine.GUI.Button(rects[1], t))
            {
                ForceShowCursor = !ForceShowCursor;
            }
        }
    }
}
