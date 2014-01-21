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
            EntityManager.addComponentToEntity(ComponentName.Player, player);
            EntityManager.addAndSetHealthComponent(12, 12, player);
            HealthSystem.checkDeaths();
            MapSystem map = new MapSystem(80, 50);
            LibtcodRenderSystem render = new LibtcodRenderSystem(80, 50, "testing");
            EntityManager.addAndSetCoordComponent(MapSystem.Entrance.X, MapSystem.Entrance.Y, player);
            EntityManager.addAndSetDisplayComponent('@', true, DisplayLevel.Creature, player);
            LibtcodRenderSystem.drawMap();
            TCODConsole.flush();
            while (!TCODConsole.isWindowClosed()) {//(TCODConsole.waitForKeypress(true).KeyCode != TCODKeyCode.Escape) {
                //MapSystem.newmap();
                PlayerLibtcodInputSystem.checkInput();
                MapSystem.entityMapUpdate();
                LibtcodRenderSystem.drawMap();
                TCODConsole.flush();
            }
        }
    }
}
