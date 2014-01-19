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
        static private CoordinateComponent Entrance, Exit;
        //private EntityManager Manager;
        public MapSystem(int width, int height){
            //Manager = manager;
            Width = width;
            Height = height;
            newmap();
            UInt32 temp = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Coord, temp);
            EntityManager.addComponentToEntity(ComponentName.Display, temp);
            EntityManager.addComponentToEntity(ComponentName.Flavor, temp);
            EntityManager.componentsOnEntities[temp][ComponentName.Display].DisplayIcon = '>';
            EntityManager.componentsOnEntities[temp][ComponentName.Display].displaylevel = DisplayLevel.Tile;
            EntityManager.componentsOnEntities[temp][ComponentName.Display].Render = true;
            Exit = EntityManager.componentsOnEntities[temp][ComponentName.Coord];

        }
        static public void newmap(){
            Tile = MapGen.newMap(Width, Height, true);
        }
    }
}
