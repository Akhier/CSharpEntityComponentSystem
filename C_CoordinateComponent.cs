using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystemTest
{
    public class CoordinateComponent : Component {
        public override ComponentName getComponentName () {
            return ComponentName.Coord;
        }
        public int X, Y;
    }
}
