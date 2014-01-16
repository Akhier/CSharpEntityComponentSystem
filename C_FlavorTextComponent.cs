namespace CSharpEntityComponentSystem
{
    class FlavorTextComponent : Component {
        public override ComponentName getComponentName () {
            return ComponentName.FlavorText;
        }
        public string Name, Description;
    }
}
