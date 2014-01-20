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
                case ComponentName.Control:
                    componentsOnEntities[entity].Add(componentname, new ControlComponent());
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
    }
}
