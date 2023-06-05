using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebugMod.GUI;

namespace DebugMod.Features.Cheats
{
    public class FastTravel : IFeature
    {
        public void Initialize()
        {
            // HELLO
        }

        public void Update()
        {
            if (CheatsMenu.FastTravel)
            {
                // Making both players enter the ballooning state, allowing them to fast travel.
                PatchQuest.Player.P1.SetBallooning(true);
                PatchQuest.Player.P2.SetBallooning(true);
            }
        }
    }
}
