using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    static class EntityManager {
        static private UInt32 _lowestUnsignedID = 0;
        static public Dictionary<UInt32, Dictionary<ComponentName, dynamic>> componentsOnEntities = new Dictionary<uint, Dictionary<ComponentName, dynamic>>();

        static public UInt32 addNewEntity() {
            if (_lowestUnsignedID < UInt32.MaxValue) {
                componentsOnEntities.Add(_lowestUnsignedID, new Dictionary<ComponentName, dynamic>());
                _lowestUnsignedID++;
                return _lowestUnsignedID - 1;
            }
            else {
                return 0;
            }
        }

        static public void removeEntity(UInt32 entity) {
            componentsOnEntities.Remove(entity);
        }

        static public List<UInt32> getEntitiesByComponent(ComponentName componentname) {
            List<UInt32> tempEntitiesList = new List<uint>();
            foreach (UInt32 entity in componentsOnEntities.Keys) {
                if (componentsOnEntities[entity].ContainsKey(componentname)) {
                    tempEntitiesList.Add(entity);
                }
            }
            return tempEntitiesList;
        }

        static public List<UInt32> getEntitiesInBothComponents(ComponentName component1, ComponentName component2) {
            List<UInt32> Component1 = getEntitiesByComponent(component1);
            List<UInt32> Component2 = getEntitiesByComponent(component2);
            return Component1.Intersect(Component2).ToList<UInt32>();
        }

        static public List<T> getListOfAComponent<T>(ComponentName componentname) {
            List<T> tempComponentList = new List<T>();
            foreach (UInt32 entity in componentsOnEntities.Keys) {
                if (componentsOnEntities[entity].ContainsKey(componentname)) {
                    tempComponentList.Add(componentsOnEntities[entity][componentname]);
                }
            }
            return tempComponentList;
        }

        static public void addComponentToEntity(ComponentName componentname, UInt32 entity) {
            switch (componentname) {
                case ComponentName.Health:
                    componentsOnEntities[entity].Add(componentname, new HealthComponent());
                    break;
                case ComponentName.Coord:
                    componentsOnEntities[entity].Add(componentname, new CoordinateComponent());
                    break;
                case ComponentName.Display:
                    componentsOnEntities[entity].Add(componentname, new DisplayComponent());
                    break;
                case ComponentName.Flavor:
                    componentsOnEntities[entity].Add(componentname, new FlavorTextComponent());
                    break;
                case ComponentName.PlayerControl:
                    componentsOnEntities[entity].Add(componentname, new PlayerControlComponent());
                    break;
                case ComponentName.MainPlayer:
                    componentsOnEntities[entity].Add(componentname, new MainPlayerComponent());
                    break;
            }
        }

        static public void removeComponentFromEntity(ComponentName componentname, UInt32 entity) {
            componentsOnEntities[entity].Remove(componentname);
        }

        static public bool checkIfEntityHasComponent(ComponentName componentname, UInt32 entity) {
            if (componentsOnEntities[entity].ContainsKey(componentname)) {
                return true;
            }
            else {
                return false;
            }
        }

        static public void addAndSetCoordComponent(int x, int y, UInt32 entity) {
            addComponentToEntity(ComponentName.Coord, entity);
            componentsOnEntities[entity][ComponentName.Coord].X = x;
            componentsOnEntities[entity][ComponentName.Coord].Y = y;
        }

        static public void addAndSetDisplayComponent(char displayicon, bool render, DisplayLevel displaylevel, UInt32 entity) {
            addComponentToEntity(ComponentName.Display, entity);
            DisplayComponent display = componentsOnEntities[entity][ComponentName.Display];
            display.DisplayIcon = displayicon;
            display.Render = render;
            display.displaylevel = displaylevel;
        }

        static public void addAndSetHealthComponent(int hp, int maxhp, UInt32 entity) {
            addComponentToEntity(ComponentName.Health, entity);
            componentsOnEntities[entity][ComponentName.Health].HP = hp;
            componentsOnEntities[entity][ComponentName.Health].maxHP = maxhp;
        }
    }
}
