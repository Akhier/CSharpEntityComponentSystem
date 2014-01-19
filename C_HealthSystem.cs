using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class HealthSystem {
        static public void setHP (UInt32 entity, int newhp) {
            EntityManager.componentsOnEntities[entity][ComponentName.Health].HP = newhp;
        }

        static public void setMaxHP (UInt32 entity, int maxhp) {
            EntityManager.componentsOnEntities[entity][ComponentName.Health].maxHP = maxhp;
        }

        static public int getHP(UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.Health].HP;
        }

        static public int getMaxHP(UInt32 entity) {
            return EntityManager.componentsOnEntities[entity][ComponentName.Health].maxHP;
        }

        static public void lowerHP (UInt32 entity, int amount) {
            EntityManager.componentsOnEntities[entity][ComponentName.Health].HP -= amount;
        }

        static public void raiseHP (UInt32 entity, int amount) {
            EntityManager.componentsOnEntities[entity][ComponentName.Health].HP += amount;
            if (getHP(entity) > getMaxHP(entity)) {
                setHP(entity, getMaxHP(entity));
            }
        }

        static public void checkDeaths() {
            foreach (UInt32 entity in EntityManager.getEntitiesByComponent(ComponentName.Health))
            {
                if (getHP(entity) < 1) {
                    //entity is dead so do death stuff
                }
            }
        }

    }
}
