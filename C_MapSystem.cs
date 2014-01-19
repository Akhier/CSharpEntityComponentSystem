using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSimpleMapGen;
using CSharpFloodFill;

namespace CSharpEntityComponentSystem
{
    public class MapSystem {
        static public bool[,] Tile;
        static private int Width, Height;
        static private int PreviousDownLocation = 7;   //The direction is where the number resides on the numpad so 7 is north west
        static public CoordinateComponent Entrance, Exit;
        public MapSystem(int width, int height){
            Width = width;
            Height = height;
            UInt32 temp = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Coord, temp);
            EntityManager.addComponentToEntity(ComponentName.Display, temp);
            EntityManager.addComponentToEntity(ComponentName.Flavor, temp);
            EntityManager.componentsOnEntities[temp][ComponentName.Display].DisplayIcon = '>';
            EntityManager.componentsOnEntities[temp][ComponentName.Display].displaylevel = DisplayLevel.Feature;
            EntityManager.componentsOnEntities[temp][ComponentName.Display].Render = true;
            EntityManager.componentsOnEntities[temp][ComponentName.Flavor].Name = "Downward Staircase";
            EntityManager.componentsOnEntities[temp][ComponentName.Flavor].Description = "This Staircase will lead you deeper into this place. Do you dare to continue?";
            Exit = EntityManager.componentsOnEntities[temp][ComponentName.Coord];
            temp = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Coord, temp);
            EntityManager.addComponentToEntity(ComponentName.Display, temp);
            EntityManager.addComponentToEntity(ComponentName.Flavor, temp);
            EntityManager.componentsOnEntities[temp][ComponentName.Display].DisplayIcon = '<';
            EntityManager.componentsOnEntities[temp][ComponentName.Display].displaylevel = DisplayLevel.Feature;
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
                        while (!checkposition(X, Y)) {
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
                        while (!checkposition(X, Y)) {
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
                        while (!checkposition(X, Y)) {
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
                        while (!checkposition(X, Y)) {
                            X++;
                            Y--;
                            if ((X >= Width) || (Y < 1)) {
                                PreviousDownLocation = 9;
                                break;
                            }
                        }
                        break;
                } 
            } while(!checkposition(X,Y));
            Entrance.X = X;
            Entrance.Y = Y;
            bool[,] boolmap = new bool[Width, Height];
            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    boolmap[x, y] = Tile[x, y];
                }
            }
            int[,] findingexit = FloodFill.Run(X, Y, boolmap);
            int highval = 0;
            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    if (highval < findingexit[x, y]) {
                        if (checkposition(x, y)) {
                            X = x;
                            Y = y;
                            highval = findingexit[x, y];
                        }
                    }
                }
            }
            if ((Entrance.X != X) && (Entrance.Y != Y)) {
                Exit.X = X;
                Exit.Y = Y;
            }
            else {
                Exit.X = X + 1;
                Exit.Y = Y + 1;
            }
            if (Y <= Height / 2) {
                if (X <= Width / 2) {
                    PreviousDownLocation = 7;
                }
                else {
                    PreviousDownLocation = 9;
                }
            }
            else {
                if (X <= Width / 2) {
                    PreviousDownLocation = 1;
                }
                else {
                    PreviousDownLocation = 3;
                }
            }
        }

        static private bool checkposition(int x,int y){
            if (Tile[x - 1, y - 1] && Tile[x - 1, y] && Tile[x - 1, y + 1] && Tile[x, y - 1] && Tile[x, y] && Tile[x, y + 1] && Tile[x + 1, y - 1] && Tile[x + 1, y] && Tile[x + 1, y + 1]) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
