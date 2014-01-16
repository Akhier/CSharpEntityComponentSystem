using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    static class EntityManager
    {
        static private UInt32 _lowestUnsignedID = 0;
        static public Dictionary<UInt32, Dictionary<ComponentName, dynamic>> componentsOnEntities = new Dictionary<uint, Dictionary<ComponentName, dynamic>>();
        static private Dictionary<ComponentName, dynamic> _componentsByName = new Dictionary<ComponentName, dynamic>() {
            {ComponentName.Health, new HealthComponent()},
            {ComponentName.Coord, new CoordinateComponent()},
            {ComponentName.ScreenRegion, new ScreenRegionComponent()},
            {ComponentName.FlavorText, new FlavorTextComponent()}
        };

        /// <summary>
        /// Adds a new entity to the componentsOnEntities Dictionary and increments the _lowestUnsignedID by 1
        /// </summary>
        /// <returns>Returns the entities ID as a UInt32</returns>
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

        /// <summary>
        /// Removes the dictionary entry for requested entity from componentsOnEntities
        /// </summary>
        /// <param name="entity">The UInt32 ID of the entity to remove</param>
        static public void removeEntity(UInt32 entity) {
            componentsOnEntities.Remove(entity);
        }

        /// <summary>
        /// Retreives a List containing the UInt32 ID of all entities that have the requested component 
        /// </summary>
        /// <param name="componentname">The string name of the component to sort by</param>
        /// <returns>Returns a List of UInt32 IDs of entities </returns>
        static public List<UInt32> getEntitiesByComponent(ComponentName componentname) {
            List<UInt32> tempEntitiesList = new List<uint>();
            foreach (UInt32 entity in componentsOnEntities.Keys) {
                if (componentsOnEntities[entity].ContainsKey(componentname)) {
                    tempEntitiesList.Add(entity);
                }
            }
            return tempEntitiesList;
        }

        /// <summary>
        /// Adds the requested component to the entity in the componentsOnEntities dictionary
        /// </summary>
        /// <param name="componentname">The string name of the component to add</param>
        /// <param name="entity">The UInt32 ID of the entity to add the component to</param>
        static public void addComponentToEntity(ComponentName componentname, UInt32 entity) {
            componentsOnEntities[entity].Add(componentname, _componentsByName[ComponentName.Health]);
        }

        /// <summary>
        /// Removes the requested component from the entity in the componentsOnEntities dictionary
        /// </summary>
        /// <param name="componentname">The string name of the component to remove</param>
        /// <param name="entity">The UInt32 ID of the entity to remove the component to</param>
        static public void removeComponentFromEntity(ComponentName componentname, UInt32 entity) {
            componentsOnEntities[entity].Remove(componentname);
        }

        /// <summary>
        /// Checks if selected entity has the named component
        /// </summary>
        /// <param name="componentname">The string name of the component to check</param>
        /// <param name="entity">The UInt32 ID of the entity to check</param>
        /// <returns>Returns a bool of whether the entity has the named component</returns>
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
