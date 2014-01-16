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
        private UInt32[] MainViews = new UInt32[3];
        public LibtcodRenderSystem (int screenwidth, int screenheight, string screentitle, EntityManager manager) {
            TCODConsole.initRoot(screenwidth, screenheight, screentitle);
            Manager = manager;
            for (int i = 0; i < 3; i++) {
                MainViews[i] = Manager.addNewEntity();
                Manager.addComponentToEntity(ComponentName.ScreenRegion, MainViews[i]);
            }
            TCODConsole.root.setBackgroundColor(TCODColor.darkerGrey);
            TCODConsole.root.setForegroundColor(TCODColor.lightestGrey);
            setScreenRegion(MainViews[0], 0, 0, 67, 36, true);
            setScreenRegion(MainViews[1], 0, 36, 80, 14, true);
            setScreenRegion(MainViews[2], 67, 0, 13, 36, true);
            Tile tile;
            tile.backColor = TCODColor.darkestGrey;
            tile.foreColor = TCODColor.lightestGrey;
            tile.tileChar = ' ';
            fillScreenRegion(MainViews[0], tile);
            fillScreenRegion(MainViews[1], tile);
            fillScreenRegion(MainViews[2], tile);
            setRegionUpdate(MainViews[0], true);
            setRegionUpdate(MainViews[1], true);
            setRegionUpdate(MainViews[2], true);
            tile.tileChar = 'H';
            _setTileInScreenRegion(MainViews[2], 3, 4, tile);
            tile.tileChar = 'P';
            _setTileInScreenRegion(MainViews[2], 4, 4, tile);
            tile.tileChar = ':';
            _setTileInScreenRegion(MainViews[2], 5, 4, tile);
            tile.tileChar = '0';
            _setTileInScreenRegion(MainViews[2], 7, 4, tile);
            tile.tileChar = '1';
            _setTileInScreenRegion(MainViews[2], 8, 4, tile);
            tile.tileChar = '3';
            _setTileInScreenRegion(MainViews[2], 9, 4, tile);
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
        public void setRegionUpdate (UInt32 entity, bool update) {
            Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].toUpdate = update;
        }
        public Tile getTileFromRegion (int x, int y, UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.ScreenRegion].tileMap[x, y];
        }

        private void _setTile (int x, int y, char tilechar, TCODColor foregroundcolor, TCODColor backgroundcolor) {
            TCODConsole.root.putCharEx(x, y, tilechar, foregroundcolor, backgroundcolor);
        }
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
            setRegionUpdate(entity, false);
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
