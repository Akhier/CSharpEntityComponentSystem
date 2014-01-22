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
            EntityManager.addComponentToEntity(ComponentName.MainPlayer, player);
            EntityManager.addComponentToEntity(ComponentName.PlayerControl, player);
            EntityManager.addAndSetHealthComponent(12, 12, player);
            EntityManager.addComponentToEntity(ComponentName.Coord, player);
            EntityManager.addAndSetDisplayComponent('@', true, DisplayLevel.Creature, player);
            LibtcodRenderSystem render = new LibtcodRenderSystem(80, 50, "testing");
            MapSystem map = new MapSystem(80, 50);
            while (!TCODConsole.isWindowClosed()) {
                HealthSystem.checkDeaths();
                MapSystem.entityMapUpdate();
                LibtcodRenderSystem.drawMap();
                TCODConsole.flush();
                PlayerLibtcodInputSystem.checkInput();
            }
        }
    }
}
