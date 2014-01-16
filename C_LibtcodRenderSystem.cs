using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    class LibtcodRenderSystem : ECSystem {
        /// <summary>
        /// Constructor Initiates the TCODConsole Root
        /// </summary>
        /// <param name="screenwidth">Width of the actual game window</param>
        /// <param name="screenheight">Height of the actual game window</param>
        /// <param name="screentitle">The title of the game window</param>
        public LibtcodRenderSystem (int screenwidth, int screenheight, string screentitle) {
            TCODConsole.initRoot(screenwidth, screenheight, screentitle);
        }

        static public int getRegionWidth (UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.ScreenRegion].Width;
        }
        static public int getRegionHeight (UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.ScreenRegion].Height;
        }
        static public int getRegionX (UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.ScreenRegion].X;
        }
        static public int getRegionY (UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.ScreenRegion].Y;
        }
        static public bool checkRegionBorder (UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.ScreenRegion].Border;
        }
        static public bool checkRegionForUpdate (UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.ScreenRegion].ToUpdate;
        }
        static public Tile getTileFromRegion (int x, int y, UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.ScreenRegion].TileMap[x, y];
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

        private void _renderScreenRegionsAsNeeded () {
            foreach (UInt32 entity in EntityManager.getEntitiesByComponent(ComponentName.ScreenRegion)) {
                if (checkRegionBorder(entity)) {
                    _renderScreenRegion(entity);
                }
            }
        }

        private void _renderScreenRegion (UInt32 entity) {
            if (checkRegionBorder(entity)) {
                TCODConsole.root.printFrame(getRegionX(entity), getRegionY(entity), getRegionWidth(entity), getRegionHeight(entity));
            }
            for (int y = getRegionY(entity) + (checkRegionBorder(entity) ? 1 : 0); y < getRegionHeight(entity) + getRegionY(entity) + (checkRegionBorder(entity) ? -1 : 0); y++) {
                for (int x = getRegionX(entity) + (checkRegionBorder(entity) ? 1 : 0); x < getRegionWidth(entity) + getRegionX(entity) + (checkRegionBorder(entity) ? -1 : 0); x++) {
                    _setTile(x, y, getTileFromRegion(x, y, entity));
                }
            }
        }
    }
}
