using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystemTest
{
    public abstract class Component {
        public abstract ComponentName getComponentName();
    }
}
