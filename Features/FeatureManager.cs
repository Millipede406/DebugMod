using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebugMod.Features.Cheats;
using DebugMod.Features.Visual;

namespace DebugMod.Features
{
    public static class FeatureManager
    {
        public static void Initialize()
        {

        }

        public static void Update()
        {
            // Updating Invulnerability
            Invulnerability.Update();
        }
    }
}
