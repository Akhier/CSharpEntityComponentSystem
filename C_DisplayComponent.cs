using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class DisplayComponent : Component {
        public override ComponentName getComponentName() {
            return ComponentName.Display;
        }
        public bool Render;
        public char DisplayIcon;
        public DisplayLevel displaylevel;
    }
}
