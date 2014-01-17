﻿using System;
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
            do {
                Screen._renderScreenRegionsAsNeeded();
                Screen.makeNewMap();
                TCODConsole.flush();
                TCODConsole.waitForKeypress(true);
            } while (!TCODConsole.isWindowClosed()) ;
        }
    }
}
