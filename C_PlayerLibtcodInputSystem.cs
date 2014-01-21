using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    static public class PlayerLibtcodInputSystem {
        static public void checkInput() {
            TCODKey pressedkey = TCODConsole.waitForKeypress(true);
            switch (pressedkey.KeyCode) {
                case TCODKeyCode.Up:
                    moveNorth();
                    break;
                case TCODKeyCode.Char:
                    switch (pressedkey.Character) {
                        case 'w':
                            moveNorth();
                            break;
                    }
                    break;
            }
        }

        static void moveNorth() {
            List<UInt32> playerEntities = EntityManager.getEntitiesByComponent(ComponentName.Player);
            List<CoordinateComponent> coordList = EntityManager.getListOfAComponent<CoordinateComponent>(ComponentName.Coord);
            foreach (UInt32 entity in playerEntities) {
                CoordinateComponent playerCoord = EntityManager.componentsOnEntities[entity][ComponentName.Coord];
                playerCoord.Y--;
                if (MapSystem.checkTile(playerCoord.X,playerCoord.Y) && MapSystem.entityMap[playerCoord.X,playerCoord.Y]) {
                    EntityManager.componentsOnEntities[entity][ComponentName.Coord] = playerCoord;
                }
                else {
                    playerCoord.Y++;
                }
            }
        }
    }
}
