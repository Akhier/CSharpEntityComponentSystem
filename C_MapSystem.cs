using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSimpleMapGen;

namespace CSharpEntityComponentSystem
{
    class MapSystem : ECSystem {
        private EntityManager Manager;
        public Dictionary<string,UInt32> Maps = new Dictionary<string,UInt32>();
        public TileDictonary TileDict = new TileDictonary();
        public MapSystem(EntityManager manager) {
            Manager = manager;
        }

        public UInt32 addNewMap(string mapname, int width, int height) {
            UInt32 newmapID = Manager.addNewEntity();
            Manager.addComponentToEntity(ComponentName.Map, newmapID);
            Manager.addComponentToEntity(ComponentName.FlavorText, newmapID);
            Manager.componentsOnEntities[newmapID][ComponentName.FlavorText].Name = mapname;
            Manager.componentsOnEntities[newmapID][ComponentName.Map] = new Tile[width, height];
            int[,] newmap = MapGen.newMap(width, height);
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Manager.componentsOnEntities[newmapID][ComponentName.Map][x, y] = TileDict.TileAttributes[newmap[x, y]];
                }
            }
            return newmapID;
        }
    }
}
