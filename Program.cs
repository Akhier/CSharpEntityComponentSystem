using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LibtcodRenderSystem Screen = new LibtcodRenderSystem(80, 50, "test");
            UInt32 player = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Health, player);
            HealthSystem.setHP(player, 12);
            HealthSystem.checkDeaths();
            while (!TCODConsole.isWindowClosed()) {
                TCODConsole.root.clear();
                TCODConsole.root.putChar(40, 25, '@');
                TCODConsole.flush();
                TCODConsole.waitForKeypress(true);
            }
        }
    }
}
