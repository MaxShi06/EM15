using System;

namespace ConsoleApp1.InventoryApp.Items
{
    class HealthPotion : Item
    {
        public int HealAmount;

        public HealthPotion(int id, int healAmount) : base(id, "Health Potion", 15)
        {
            HealAmount = healAmount;
        }

        public override void Use()
        {
            Console.WriteLine("Випито зілля здоров'я. Відновлено " + HealAmount + " HP.");
        }
    }
}
