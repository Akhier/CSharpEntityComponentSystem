namespace CSharpEntityComponentSystem
{
    class PlayerControlComponent : Component {
        public override ComponentName getComponentName() {
            return ComponentName.Control;
        }
    }
}
