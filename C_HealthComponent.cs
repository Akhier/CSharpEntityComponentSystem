namespace CSharpEntityComponentSystem
{
    public class HealthComponent : Component {
        public override ComponentName getComponentName() {
            return ComponentName.Health;
        }
        public int HP, maxHP;
    }
}
