using System;
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
        public static bool operator ==(CoordinateComponent thiscoord,CoordinateComponent othercoord){
            if ((thiscoord.X == othercoord.X) && (thiscoord.Y == othercoord.Y)) {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(CoordinateComponent thiscoord, CoordinateComponent othercoord) {
            if ((thiscoord.X != othercoord.X) || (thiscoord.Y != othercoord.Y)) {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int X, Y;
    }
}
