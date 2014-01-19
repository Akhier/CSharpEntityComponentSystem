using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSimpleMapGen;

namespace CSharpEntityComponentSystem
{
    public class MapSystem {
        static public bool[,] Tile;
        static private int Width, Height;
        static private int PreviousDownLocation = 7;   //The direction is where the number resides on the numpad so 7 is north west
        static private CoordinateComponent Entrance, Exit;
        public MapSystem(int width, int height){
            Width = width;
            Height = height;
            UInt32 temp = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Coord, temp);
            EntityManager.addComponentToEntity(ComponentName.Display, temp);
            EntityManager.addComponentToEntity(ComponentName.Flavor, temp);
            EntityManager.componentsOnEntities[temp][ComponentName.Display].DisplayIcon = '>';
            EntityManager.componentsOnEntities[temp][ComponentName.Display].displaylevel = DisplayLevel.Tile;
            EntityManager.componentsOnEntities[temp][ComponentName.Display].Render = true;
            EntityManager.componentsOnEntities[temp][ComponentName.Flavor].Name = "Downward Staircase";
            EntityManager.componentsOnEntities[temp][ComponentName.Flavor].Description = "This Staircase will lead you deeper into this place. Do you dare to continue?";
            Exit = EntityManager.componentsOnEntities[temp][ComponentName.Coord];
            temp = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Coord, temp);
            EntityManager.addComponentToEntity(ComponentName.Display, temp);
            EntityManager.addComponentToEntity(ComponentName.Flavor, temp);
            EntityManager.componentsOnEntities[temp][ComponentName.Display].DisplayIcon = '<';
            EntityManager.componentsOnEntities[temp][ComponentName.Display].displaylevel = DisplayLevel.Tile;
            EntityManager.componentsOnEntities[temp][ComponentName.Display].Render = true;
            EntityManager.componentsOnEntities[temp][ComponentName.Flavor].Name = "Upward Staircase";
            EntityManager.componentsOnEntities[temp][ComponentName.Flavor].Description = "This Staircase will lead you upwards to where you have already been, or rather it would if a block of stone hadn't slammed into place as soon as you stepped off the staircase. Apperently retreating isn't an option here so you better go forward to live or die with honor(no matter how forced upon you).";
            Entrance = EntityManager.componentsOnEntities[temp][ComponentName.Coord];
            newmap();
        }

        static public void newmap(){
            Tile = MapGen.newMap(Width, Height, true);
            int X = 1, Y = 1;
            do {
                switch (PreviousDownLocation) {
                    case 7:
                        X = 1;
                        Y = 1;
                        while (!checkstart(X, Y)) {
                            X++;
                            Y++;
                            if ((X >= Width) || (Y >= Height)) {
                                PreviousDownLocation = 9;
                                break;
                            }
                        }
                        break;
                    case 9:
                        X = Width - 1;
                        Y = 1;
                        while (!checkstart(X, Y)) {
                            X--;
                            Y++;
                            if ((X < 1) || (Y >= Height)) {
                                PreviousDownLocation = 3;
                                break;
                            }
                        }
                        break;
                    case 3:
                        X = Width - 1;
                        Y = Height - 1;
                        while (!checkstart(X, Y)) {
                            X--;
                            Y--;
                            if ((X < 1) || (Y < 1)) {
                                PreviousDownLocation = 1;
                                break;
                            }
                        }
                        break;
                    case 1:
                        X = 1;
                        Y = Height - 1;
                        while (!checkstart(X, Y)) {
                            X++;
                            Y--;
                            if ((X >= Width) || (Y < 1)) {
                                PreviousDownLocation = 9;
                                break;
                            }
                        }
                        break;
                } 
            } while(checkstart(X,Y));

        }

        static private bool checkstart(int x,int y){
            if (Tile[x - 1, y - 1] && Tile[x - 1, y] && Tile[x - 1, y + 1] && Tile[x, y - 1] && Tile[x, y] && Tile[x, y + 1] && Tile[x + 1, y - 1] && Tile[x + 1, y] && Tile[x + 1, y + 1]) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
