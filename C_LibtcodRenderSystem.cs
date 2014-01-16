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
    }
}
