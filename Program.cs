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
        static void Main(string[] args) {
            UInt32 player = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Health, player);
            HealthSystem.setHP(player, 12);
            Console.Write(HealthSystem.getHP(player));
            HealthSystem.checkDeaths();
            MapSystem map = new MapSystem(80, 50);
            LibtcodRenderSystem render = new LibtcodRenderSystem(80, 50, "testing colors");
            LibtcodRenderSystem.drawMap();
            TCODConsole.flush();
            while (TCODConsole.waitForKeypress(true).KeyCode != TCODKeyCode.Escape) {
                MapSystem.newmap();
                LibtcodRenderSystem.drawMap();
                TCODConsole.flush();
            }
        }
    }
}
