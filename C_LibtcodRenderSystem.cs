using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    class LibtcodRenderSystem : ECSystem {
        private EntityManager Manager;
        public LibtcodRenderSystem (int screenwidth, int screenheight, string screentitle, EntityManager manager) {
            TCODConsole.initRoot(screenwidth, screenheight, screentitle);
            Manager = manager;
        }

        public void setScreenRegion(UInt32 entity, int x, int y, int width, int height, bool border) {
            Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].X = x;
            Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].Y = y;
            Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].Height = height;
            Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].Width = width;
            Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].tileMap = new Tile[width, height];
            Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].Border = border;
            Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].toUpdate = false;
        }

        public int getRegionWidth (UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].Width;
        }
        public int getRegionHeight (UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].Height;
        }
        public int getRegionX (UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].X;
        }
        public int getRegionY (UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].Y;
        }
        public bool checkRegionBorder (UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].Border;
        }
        public bool checkRegionForUpdate (UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].toUpdate;
        }
        public Tile getTileFromRegion (int x, int y, UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].tileMap[x, y];
        }

        /// <summary>
        /// Puts a character at a selected position with the selected color (TCODConsole.root.putCharEx wrapper)
        /// </summary>
        /// <param name="x">X Coords</param>
        /// <param name="y">Y Coords</param>
        /// <param name="tilechar">The character to place</param>
        /// <param name="foregroundcolor">Foreground color to use</param>
        /// <param name="backgroundcolor">Background color to use</param>
        private void _setTile (int x, int y, char tilechar, TCODColor foregroundcolor, TCODColor backgroundcolor) {
            TCODConsole.root.putCharEx(x, y, tilechar, foregroundcolor, backgroundcolor);
        }
        /// <summary>
        /// Puts a character at a selected position with the selected color (TCODConsole.root.putCharEx wrapper)
        /// </summary>
        /// <param name="x">X Coords</param>
        /// <param name="y">Y Coords</param>
        /// <param name="tile">The character, foreground color, and background color</param>
        private void _setTile (int x, int y, Tile tile) {
            TCODConsole.root.putCharEx(x, y, tile.tileChar, tile.foreColor, tile.backColor);
        }

        public void _renderScreenRegionsAsNeeded () {
            foreach (UInt32 entity in Manager.getEntitiesByComponent(ComponentName.ScreenRegion)) {
                if (checkRegionForUpdate(entity)) {
                    _renderScreenRegion(entity);
                }
            }
        }

        private void _renderScreenRegion (UInt32 entity) {
            bool border = checkRegionBorder(entity);
            if (border) {
                TCODConsole.root.printFrame(getRegionX(entity), getRegionY(entity), getRegionWidth(entity), getRegionHeight(entity),false);
            }
            for (int y = (border ? 1 : 0); y < getRegionHeight(entity) + (border ? -1 : 0); y++) {
                for (int x = (border ? 1 : 0); x < getRegionWidth(entity) + (border ? -1 : 0); x++) {
                    _setTile(x + getRegionX(entity), y + getRegionY(entity), getTileFromRegion(x, y, entity));
                }
            }
        }

        private void _setTileInScreenRegion (UInt32 screenregionentity, int x, int y, Tile tile) {
            Manager.componentsOnEntities[screenregionentity][ComponentName.ScreenRegion].tileMap[x, y] = tile;
        }
        
        public void fillScreenRegion (UInt32 screenregionentity, Tile tile) {
            for (int y = 0; y < getRegionHeight(screenregionentity); y++) {
                for (int x = 0; x < getRegionWidth(screenregionentity); x++) {
                    _setTileInScreenRegion(screenregionentity, x, y, tile);
                }
            }
        }
    }
}
