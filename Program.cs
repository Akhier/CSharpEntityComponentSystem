using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace EntityComponentSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UInt32 player = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Health, player);
            HealthSystem.setHP(player, 12);
            HealthSystem.checkDeaths();
            TCODConsole.initRoot(80, 50, "test");
            while (!TCODConsole.isWindowClosed()) {
                TCODConsole.root.clear();
                TCODConsole.root.putChar(40, 25, '@');
                TCODConsole.flush();
                TCODConsole.waitForKeypress(true);
            }
        }
    }
}
