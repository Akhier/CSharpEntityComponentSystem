﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class FlavorTextComponent {
        public override ComponentName getComponentName() {
            return ComponentName.Flavor;
        }
        public string Name, FlavorText;
    }
}
