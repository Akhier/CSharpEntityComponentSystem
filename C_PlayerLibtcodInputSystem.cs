using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    public class PlayerLibtcodInputSystem {
        static public PlayerLibtcodInputSystem() {
            TCODKey pressedkey = TCODConsole.waitForKeypress(true);
            switch (pressedkey.KeyCode) {
                case TCODKeyCode.Char:
                    switch (pressedkey.Character) {
                        case 'w':
                            break;
                    }
                    break;
            }
        }

        static void moveNorth() {
            List<UInt32> playerEntities = EntityManager.getEntitiesByComponent(ComponentName.Player);
            foreach (UInt32 entity in playerEntities) {
                
            }
        }
    }
}
