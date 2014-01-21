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
                case TCODKeyCode.KeypadEight:
                    move(CardinalDirection.North);
                    break;
                case TCODKeyCode.Right:
                case TCODKeyCode.KeypadSix:
                    move(CardinalDirection.East);
                    break;
                case TCODKeyCode.Down:
                case TCODKeyCode.KeypadTwo:
                    move(CardinalDirection.South);
                    break;
                case TCODKeyCode.Left:
                case TCODKeyCode.KeypadFour:
                    move(CardinalDirection.West);
                    break;
                case TCODKeyCode.KeypadNine:
                    move(CardinalDirection.NorthEast);
                    break;
                case TCODKeyCode.KeypadThree:
                    move(CardinalDirection.SouthEast);
                    break;
                case TCODKeyCode.KeypadOne:
                    move(CardinalDirection.SouthWest);
                    break;
                case TCODKeyCode.KeypadSeven:
                    move(CardinalDirection.NorthWest);
                    break;
                case TCODKeyCode.Char:
                    switch (pressedkey.Character) {
                        case 'w':
                            move(CardinalDirection.North);
                            break;
                        case 'd':
                            move(CardinalDirection.East);
                            break;
                        case 's':
                            move(CardinalDirection.South);
                            break;
                        case 'a':
                            move(CardinalDirection.West);
                            break;
                    }
                    break;
            }
        }

        static void move(CardinalDirection dir) {
            List<UInt32> playerEntities = EntityManager.getEntitiesByComponent(ComponentName.Player);
            List<CoordinateComponent> coordList = EntityManager.getListOfAComponent<CoordinateComponent>(ComponentName.Coord);
            foreach (UInt32 entity in playerEntities) {
                CoordinateComponent playerCoord = EntityManager.componentsOnEntities[entity][ComponentName.Coord];
                if ((dir == CardinalDirection.North) || (dir == CardinalDirection.NorthEast) || (dir == CardinalDirection.NorthWest)) {
                    playerCoord.Y--;
                }
                else if ((dir == CardinalDirection.South) || (dir == CardinalDirection.SouthEast) || (dir == CardinalDirection.SouthWest)) {
                    playerCoord.Y++;
                }
                if ((dir == CardinalDirection.West) || (dir == CardinalDirection.NorthWest) || (dir == CardinalDirection.SouthWest)) {
                    playerCoord.X--;
                }
                else if ((dir == CardinalDirection.East) || (dir == CardinalDirection.NorthEast) || (dir == CardinalDirection.SouthEast)) {
                    playerCoord.X++;
                }
                if (!(MapSystem.checkTile(playerCoord.X,playerCoord.Y) && MapSystem.entityMap[playerCoord.X,playerCoord.Y])) {
                    if ((dir == CardinalDirection.North) || (dir == CardinalDirection.NorthEast) || (dir == CardinalDirection.NorthWest)) {
                        playerCoord.Y++;
                    }
                    else if ((dir == CardinalDirection.South) || (dir == CardinalDirection.SouthEast) || (dir == CardinalDirection.SouthWest)) {
                        playerCoord.Y--;
                    }
                    if ((dir == CardinalDirection.West) || (dir == CardinalDirection.NorthWest) || (dir == CardinalDirection.SouthWest)) {
                        playerCoord.X++;
                    }
                    else if ((dir == CardinalDirection.East) || (dir == CardinalDirection.NorthEast) || (dir == CardinalDirection.SouthEast)) {
                        playerCoord.X--;
                    }
                }
            }
        }
    }
}
