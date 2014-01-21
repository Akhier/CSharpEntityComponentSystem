using System;
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
            List<UInt32> entitywithboth = EntityManager.getEntitiesInBothComponents(ComponentName.Coord, ComponentName.Display); 
            List<UInt32> entitywithboth2 = new List<UInt32>();
            foreach (UInt32 entity in entitywithboth) {
                if (EntityManager.componentsOnEntities[entity][ComponentName.Display].Render && (EntityManager.componentsOnEntities[entity][ComponentName.Display].displaylevel == DisplayLevel.Tile)) {
                    TCODConsole.root.putChar(EntityManager.componentsOnEntities[entity][ComponentName.Coord].X, EntityManager.componentsOnEntities[entity][ComponentName.Coord].Y, EntityManager.componentsOnEntities[entity][ComponentName.Display].DisplayIcon);
                }
                else {
                    entitywithboth2.Add(entity);
                }
            }
            
            entitywithboth = new List<UInt32>();

            foreach (UInt32 entity in entitywithboth2) {
                if (EntityManager.componentsOnEntities[entity][ComponentName.Display].Render && (EntityManager.componentsOnEntities[entity][ComponentName.Display].displaylevel == DisplayLevel.Feature)) {
                    TCODConsole.root.putChar(EntityManager.componentsOnEntities[entity][ComponentName.Coord].X, EntityManager.componentsOnEntities[entity][ComponentName.Coord].Y, EntityManager.componentsOnEntities[entity][ComponentName.Display].DisplayIcon);
                    entitywithboth.Remove(entity);
                }
                else {
                    entitywithboth.Add(entity);
                }
            }

            entitywithboth2 = new List<UInt32>();
            
            foreach (UInt32 entity in entitywithboth) {
                if (EntityManager.componentsOnEntities[entity][ComponentName.Display].Render && (EntityManager.componentsOnEntities[entity][ComponentName.Display].displaylevel == DisplayLevel.Item)) {
                    TCODConsole.root.putChar(EntityManager.componentsOnEntities[entity][ComponentName.Coord].X, EntityManager.componentsOnEntities[entity][ComponentName.Coord].Y, EntityManager.componentsOnEntities[entity][ComponentName.Display].DisplayIcon);
                    entitywithboth.Remove(entity);
                }
                else {
                    entitywithboth2.Add(entity);
                }
            }

            foreach (UInt32 entity in entitywithboth2) {
                if (EntityManager.componentsOnEntities[entity][ComponentName.Display].Render && (EntityManager.componentsOnEntities[entity][ComponentName.Display].displaylevel == DisplayLevel.Creature)) {
                    TCODConsole.root.putChar(EntityManager.componentsOnEntities[entity][ComponentName.Coord].X, EntityManager.componentsOnEntities[entity][ComponentName.Coord].Y, EntityManager.componentsOnEntities[entity][ComponentName.Display].DisplayIcon);
                }
            }
        }
    }
}
