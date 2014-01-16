﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class EntityManager
    {
        private UInt32 _lowestUnsignedID = 0;
        public Dictionary<UInt32, Dictionary<ComponentName, dynamic>> componentsOnEntities = new Dictionary<uint, Dictionary<ComponentName, dynamic>>();
        private Dictionary<ComponentName, dynamic> _componentsByName = new Dictionary<ComponentName, dynamic>() {
            {ComponentName.Health, new HealthComponent()},
            {ComponentName.Coord, new CoordinateComponent()},
            {ComponentName.ScreenRegion, new ScreenRegionComponent()},
            {ComponentName.FlavorText, new FlavorTextComponent()}
        };

        public UInt32 addNewEntity() {
            if (_lowestUnsignedID < UInt32.MaxValue) {
                componentsOnEntities.Add(_lowestUnsignedID, new Dictionary<ComponentName, dynamic>());
                _lowestUnsignedID++;
                return _lowestUnsignedID - 1;
            }
            else {
                return 0;
            }
        }

        public void removeEntity(UInt32 entity) {
            componentsOnEntities.Remove(entity);
        }

        public List<UInt32> getEntitiesByComponent(ComponentName componentname) {
            List<UInt32> tempEntitiesList = new List<uint>();
            foreach (UInt32 entity in componentsOnEntities.Keys) {
                if (componentsOnEntities[entity].ContainsKey(componentname)) {
                    tempEntitiesList.Add(entity);
                }
            }
            return tempEntitiesList;
        }

        public void addComponentToEntity(ComponentName componentname, UInt32 entity) {
            componentsOnEntities[entity].Add(componentname, _componentsByName[componentname]);
        }

        public void removeComponentFromEntity(ComponentName componentname, UInt32 entity) {
            componentsOnEntities[entity].Remove(componentname);
        }

        public bool checkIfEntityHasComponent(ComponentName componentname, UInt32 entity) {
            if (componentsOnEntities[entity].ContainsKey(componentname)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
