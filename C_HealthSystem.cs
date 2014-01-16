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
        
        public void setHP (UInt32 entity, int newhp) {
            Manager.componentsOnEntities[entity][ComponentName.Health].HP = newhp;
        }

        public void setMaxHP (UInt32 entity, int maxhp) {
            Manager.componentsOnEntities[entity][ComponentName.Health].maxHP = maxhp;
        }

        public int getHP(UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.Health].HP;
        }

        public int getMaxHP(UInt32 entity) {
            return Manager.componentsOnEntities[entity][ComponentName.Health].maxHP;
        }

        public void lowerHP (UInt32 entity, int amount) {
            Manager.componentsOnEntities[entity][ComponentName.Health].HP -= amount;
        }

        public void raiseHP (UInt32 entity, int amount) {
            Manager.componentsOnEntities[entity][ComponentName.Health].HP += amount;
            if (getHP(entity) > getMaxHP(entity)) {
                setHP(entity, getMaxHP(entity));
            }
        }

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
