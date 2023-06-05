using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugMod.Features
{
    public interface IFeature
    {
        void Initialize();
        void Update();
    }
}
