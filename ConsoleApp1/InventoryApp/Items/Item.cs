using System;

namespace ConsoleApp1.InventoryApp.Items
{
    class Item
    {
        public int Id;
        public string Name;
        public int Price;

        public Item(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public virtual void Use()
        {
            Console.WriteLine("Використано предмет: " + Name);
        }
    }
}
