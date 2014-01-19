using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    class LibtcodRenderSystem {
        static public LibtcodRenderSystem(int width, int height, string title) {
            TCODConsole.initRoot(width, height, title);
        }
    }
}
