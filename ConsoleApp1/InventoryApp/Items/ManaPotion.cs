using System;

namespace ConsoleApp1.InventoryApp.Items
{
    class ManaPotion : Item
    {
        public int ManaAmount;

        public ManaPotion(int id, int manaAmount) : base(id, "Mana Potion", 12)
        {
            ManaAmount = manaAmount;
        }

        public override void Use()
        {
            Console.WriteLine("Випито зілля мани. Відновлено " + ManaAmount + " MP.");
        }
    }
}
