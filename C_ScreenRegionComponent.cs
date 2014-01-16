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

        public ScreenRegionComponent (int x, int y, int width, int height, bool border) {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            tileMap = new Tile[width, height];
            Border = border;
            toUpdate = false;
        }

        public int Height, Width, X, Y;
        public Tile[,] tileMap;
        public bool Border, toUpdate;
    }
}
