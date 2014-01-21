using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    static public class PlayerLibtcodInputSystem {
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
            List<CoordinateComponent> coordList = EntityManager.getListOfAComponent<CoordinateComponent>(ComponentName.Coord);
            foreach (UInt32 entity in playerEntities) {
                dynamic playerCoord = new CoordinateComponent();
                playerCoord.X = EntityManager.componentsOnEntities[entity][ComponentName.Coord].X;
                playerCoord.Y = EntityManager.componentsOnEntities[entity][ComponentName.Coord].Y-1;
                if ((MapSystem.checkTile(playerCoord.X,playerCoord.Y))&&(!(coordList.Exists(playerCoord)))) {

                }
            }
        }
    }
}
