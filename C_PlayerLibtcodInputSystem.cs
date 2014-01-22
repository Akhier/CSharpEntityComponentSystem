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
                    movePlayer(CardinalDirection.North);
                    break;
                case TCODKeyCode.Right:
                case TCODKeyCode.KeypadSix:
                    movePlayer(CardinalDirection.East);
                    break;
                case TCODKeyCode.Down:
                case TCODKeyCode.KeypadTwo:
                    movePlayer(CardinalDirection.South);
                    break;
                case TCODKeyCode.Left:
                case TCODKeyCode.KeypadFour:
                    movePlayer(CardinalDirection.West);
                    break;
                case TCODKeyCode.KeypadNine:
                    movePlayer(CardinalDirection.NorthEast);
                    break;
                case TCODKeyCode.KeypadThree:
                    movePlayer(CardinalDirection.SouthEast);
                    break;
                case TCODKeyCode.KeypadOne:
                    movePlayer(CardinalDirection.SouthWest);
                    break;
                case TCODKeyCode.KeypadSeven:
                    movePlayer(CardinalDirection.NorthWest);
                    break;
                case TCODKeyCode.Char:
                    switch (pressedkey.Character) {
                        case 'w':
                            movePlayer(CardinalDirection.North);
                            break;
                        case 'd':
                            movePlayer(CardinalDirection.East);
                            break;
                        case 's':
                            movePlayer(CardinalDirection.South);
                            break;
                        case 'a':
                            movePlayer(CardinalDirection.West);
                            break;
                        case '>':
                            goDownStairs();
                            break;
                    }
                    break;
            }
        }

        static void move(CardinalDirection dir, UInt32 entity) {
            CoordinateComponent entityCoord = EntityManager.componentsOnEntities[entity][ComponentName.Coord];
            if ((dir == CardinalDirection.North) || (dir == CardinalDirection.NorthEast) || (dir == CardinalDirection.NorthWest))
            {
                entityCoord.Y--;
            }
            else if ((dir == CardinalDirection.South) || (dir == CardinalDirection.SouthEast) || (dir == CardinalDirection.SouthWest))
            {
                entityCoord.Y++;
            }
            if ((dir == CardinalDirection.West) || (dir == CardinalDirection.NorthWest) || (dir == CardinalDirection.SouthWest))
            {
                entityCoord.X--;
            }
            else if ((dir == CardinalDirection.East) || (dir == CardinalDirection.NorthEast) || (dir == CardinalDirection.SouthEast))
            {
                entityCoord.X++;
            }
            if (!(MapSystem.checkTile(entityCoord.X, entityCoord.Y) && MapSystem.entityMap[entityCoord.X, entityCoord.Y]))
            {
                if ((dir == CardinalDirection.North) || (dir == CardinalDirection.NorthEast) || (dir == CardinalDirection.NorthWest))
                {
                    entityCoord.Y++;
                }
                else if ((dir == CardinalDirection.South) || (dir == CardinalDirection.SouthEast) || (dir == CardinalDirection.SouthWest))
                {
                    entityCoord.Y--;
                }
                if ((dir == CardinalDirection.West) || (dir == CardinalDirection.NorthWest) || (dir == CardinalDirection.SouthWest))
                {
                    entityCoord.X++;
                }
                else if ((dir == CardinalDirection.East) || (dir == CardinalDirection.NorthEast) || (dir == CardinalDirection.SouthEast))
                {
                    entityCoord.X--;
                }
            }
        }

        static void movePlayer(CardinalDirection dir) {
            List<UInt32> playerEntities = EntityManager.getEntitiesByComponent(ComponentName.PlayerControl);
            List<CoordinateComponent> coordList = EntityManager.getListOfAComponent<CoordinateComponent>(ComponentName.Coord);
            foreach (UInt32 entity in playerEntities) {
                move(dir, entity);
            }
        }

        static void goDownStairs() {
            CoordinateComponent playercoords = EntityManager.componentsOnEntities[EntityManager.getEntitiesByComponent(ComponentName.MainPlayer).First()][ComponentName.Coord];
            if (playercoords == MapSystem.Exit) {
                MapSystem.newmap();
            }
        }
    }
}
