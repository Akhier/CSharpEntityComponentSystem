using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystemTest
{
    public class HealthComponent : Component {
        public override ComponentName getComponentName() {
            return ComponentName.Health;
        }
        public int HP, maxHP;
    }
}
