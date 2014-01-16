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

        public ScreenRegionComponent (int x, int y, int width, int height) {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            tileMap = new Tile[width, height];
        }

        public int Height, Width, X, Y;
        public Tile[,] tileMap;
    }
}
