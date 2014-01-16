using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class ScreenRegionComponent : Component {
        public override ComponentName getComponentName () {
            return ComponentName.ScreenRegion;
        }
        public int Height, Width, X, Y;
        public Tile[,] tileMap;
        public bool Border, toUpdate;
    }
}
