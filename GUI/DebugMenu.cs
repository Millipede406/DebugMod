using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DebugMod.GUI
{
    public static class DebugMenu
    {
        private static Rect[] rects =
        {
            // Background
            new Rect(0, 0, 0, 0),

            // Cheats Menu button
            new Rect(0, 0, 0, 0),

            // Tools Menu button
            new Rect(0, 0, 0, 0),

            // Toggle Info text
            new Rect(0, 0, 0, 0)
        };
        private static Rect windowRect;

        public static void InitializeMenu()
        {
            windowRect = rects[0];
        }
        public static void DrawMenu()
        {

        }
    }
}
