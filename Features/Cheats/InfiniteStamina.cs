using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebugMod.GUI;

namespace DebugMod.Features.Cheats
{
    public static class InfiniteStamina
    {
        public static void Update()
        {
            if (CheatsMenu.InfiniteStamina)
            {
                // Setting stamina for both players to maximum possible value
                PatchQuest.Player.P1.Stamina = int.MaxValue;
                PatchQuest.Player.P2.Stamina = int.MaxValue;
            }
        }
    }
}
