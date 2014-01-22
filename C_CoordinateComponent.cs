﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    public class CoordinateComponent : Component {
        public override ComponentName getComponentName () {
            return ComponentName.Coord;
        }
        public override int GetHashCode() {
            return (23 * 31 + X) * 31 + Y;
        }
        public override bool Equals(object obj) {
            CoordinateComponent other = obj as CoordinateComponent;
            return ((other.X == this.X) && (other.Y == this.Y));
        }
        public int X, Y;
    }
}
