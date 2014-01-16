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
            EntityManager Manager = new EntityManager();
            LibtcodRenderSystem Screen = new LibtcodRenderSystem(80, 50, "test", Manager);
            HealthSystem Health = new HealthSystem(Manager);
            UInt32 player = Manager.addNewEntity();
            Manager.addComponentToEntity(ComponentName.Health, player);
            Health.setHP(player, 12);
            Health.checkDeaths();
            UInt32 region = Manager.addNewEntity();
            Manager.addComponentToEntity(ComponentName.ScreenRegion, region);
            Screen.setScreenRegion(region, 0, 0, 65, 31, true);
            Manager.componentsOnEntities[region][ComponentName.ScreenRegion].toUpdate = true;
            UInt32 otherregion = Manager.addNewEntity();
            Manager.addComponentToEntity(ComponentName.ScreenRegion, otherregion);
            Screen.setScreenRegion(otherregion, 0, 31, 80, 19, true);
            Manager.componentsOnEntities[otherregion][ComponentName.ScreenRegion].toUpdate = true;
            Tile tile;
            tile.backColor = TCODColor.darkestGrey;
            tile.foreColor = TCODColor.lightestGrey;
            tile.tileChar = ' ';
            Screen.fillScreenRegion(region, tile);
            Screen.fillScreenRegion(otherregion, tile);
            while (!TCODConsole.isWindowClosed()) {
                TCODConsole.root.clear();
                Screen._renderScreenRegionsAsNeeded();
                TCODConsole.flush();
                TCODConsole.waitForKeypress(true);
            }
        }
    }
}
