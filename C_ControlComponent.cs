using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class ControlComponent : Component {
        public override ComponentName getComponentName() {
            return ComponentName.Control;
        }
    }
}
