using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class MapComponent : Component {
        public override ComponentName getComponentName () {
            return ComponentName.Map;
        }
        public Tile[,] Tiles;
    }
}
