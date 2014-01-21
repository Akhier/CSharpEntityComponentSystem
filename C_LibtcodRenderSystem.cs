﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    public class LibtcodRenderSystem {
        static private int Width, Height;
        public LibtcodRenderSystem(int width, int height, string title) {
            TCODConsole.initRoot(width, height, title);
            TCODConsole.root.setBackgroundColor(new TCODColor(15,15,15));
            TCODConsole.root.setForegroundColor(TCODColor.lightestGrey);
            TCODConsole.root.clear();
            TCODConsole.flush();
            Width = width;
            Height = height;
        }

        static public void drawMap() {
            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    TCODConsole.root.putChar(x, y, MapSystem.Tile[x, y] ? '.' : '#');
                }
            }
            //TCODConsole.root.putChar(MapSystem.Entrance.X, MapSystem.Entrance.Y, '<');
            //TCODConsole.root.putChar(MapSystem.Exit.X, MapSystem.Exit.Y, '>');
            List<UInt32> entitywithcoords = EntityManager.getEntitiesByComponent(ComponentName.Coord);
            List<UInt32> entitywithdisplay = EntityManager.getEntitiesByComponent(ComponentName.Display);
            var entitywithboth = entitywithcoords.Intersect(entitywithdisplay);
            foreach (UInt32 entity in entitywithdisplay.Intersect(entitywithcoords)) {
                TCODConsole.root.putChar(EntityManager.componentsOnEntities[entity][ComponentName.Coord].X, EntityManager.componentsOnEntities[entity][ComponentName.Coord].Y, EntityManager.componentsOnEntities[entity][ComponentName.Display].DisplayIcon);
            }
        }
    }
}
