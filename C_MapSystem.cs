using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSimpleMapGen;

namespace CSharpEntityComponentSystem
{
    public class MapSystem {
        static public bool[,] Tile;
        static private int Width, Height;
        public MapSystem(int width, int height) {
            Width = width;
            Height = height;
            newmap();
        }
        static public void newmap(){
            Tile = MapGen.newMap(Width, Height, true);
        }
    }
}
