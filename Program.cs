using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEntityComponentSystem
{
    class Program
    {
        static void Main(string[] args) {
            UInt32 player = EntityManager.addNewEntity();
            EntityManager.addComponentToEntity(ComponentName.Health, player);
            HealthSystem.setHP(player, 12);
            Console.Write(HealthSystem.getHP(player));
            HealthSystem.checkDeaths();
            MapSystem map = new MapSystem(100, 100);
            Console.ReadKey();
        }
    }
}
