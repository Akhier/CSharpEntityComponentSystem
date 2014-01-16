using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class HealthSystem : ECSystem {
        private EntityManager Manager;
        public HealthSystem(EntityManager manager) {
            Manager = manager;
        }
        /// <summary>
        /// Sets the selected entity's HP to a new value
        /// </summary>
        /// <param name="entity">The UInt32 ID of entity to affect</param>
        /// <param name="newhp">The new value to set the hp to</param>
        public void setHP (UInt32 entity, int newhp) {
            Manager.componentsOnEntities[entity][ComponentName.Health].HP = newhp;
        }

        /// <summary>
        /// If the selected entity has the HealthComponent set the max HP
        /// </summary>
        /// <param name="entity">The UInt32 ID of entity to affect</param>
        /// <param name="maxhp">The max hp you want the entity to have as an int</param>
        public void setMaxHP (UInt32 entity, int maxhp) {
            Manager.componentsOnEntities[entity][ComponentName.Health].maxHP = maxhp;
        }

        /// <summary>
        /// Gets the selected entity's hp
        /// </summary>
        /// <param name="entity">The UInt32 ID of entity to check</param>
        /// <returns>The entity's HP</returns>
        public int getHP(UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.Health].HP;
        }

        /// <summary>
        /// Gets the selected entity's max hp
        /// </summary>
        /// <param name="entity">The UInt32 ID of entity to check</param>
        /// <returns>The entity's maxHP</returns>
        public int getMaxHP(UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.Health].maxHP;
        }

        /// <summary>
        /// Lowers selected entity's HP by selected amount
        /// </summary>
        /// <param name="entity">The UInt32 ID of entity to affect</param>
        /// <param name="amount">The amount you want to change the HP by</param>
        public void lowerHP (UInt32 entity, int amount) {
            Manager.componentsOnEntities[entity][ComponentName.Health].HP -= amount;
        }

        /// <summary>
        /// Raises selected entity's HP by selected amount up to the max hp
        /// </summary>
        /// <param name="entity">The UInt32 ID of entity to affect</param>
        /// <param name="amount">The amount you want to change the HP by</param>
        public void raiseHP (UInt32 entity, int amount) {
            Manager.componentsOnEntities[entity][ComponentName.Health].HP += amount;
            if (getHP(entity) > getMaxHP(entity)) {
                setHP(entity, getMaxHP(entity));
            }
        }

        /// <summary>
        /// Checks if any entities with the HealthComponent has an HP less then 1 and does as required
        /// </summary>
        public void checkDeaths() {
            foreach (UInt32 entity in Manager.getEntitiesByComponent(ComponentName.Health))
            {
                if (getHP(entity) < 1) {
                    //entity is dead so do death stuff
                }
            }
        }

    }
}
