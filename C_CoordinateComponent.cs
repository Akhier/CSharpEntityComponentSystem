namespace CSharpEntityComponentSystem
{
    public class CoordinateComponent : Component {
        public override ComponentName getComponentName () {
            return ComponentName.Coord;
        }
        public int X, Y;
    }
}
