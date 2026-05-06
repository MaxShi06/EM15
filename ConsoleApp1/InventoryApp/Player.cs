using System;
using System.Collections.Generic;
using ConsoleApp1.InventoryApp.Items;

namespace ConsoleApp1.InventoryApp
{
    class Player
    {
        public string Name;

        public int CurrentHealth;
        public int MaxHealth;

        public int CurrentMana;
        public int MaxMana;

        public int CurrentEnergy;
        public int MaxEnergy;

        private List<Item> inventory = new List<Item>();
        private int maxSlots = 10;

        public Player(string name, int maxHealth, int maxMana, int maxEnergy)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            MaxMana = maxMana;
            CurrentMana = maxMana;
            MaxEnergy = maxEnergy;
            CurrentEnergy = maxEnergy;
        }

        public void SetHealth(int current, int max)
        {
            MaxHealth = max;
            CurrentHealth = current;
        }

        public void SetMana(int current, int max)
        {
            MaxMana = max;
            CurrentMana = current;
        }

        public void SetEnergy(int current, int max)
        {
            MaxEnergy = max;
            CurrentEnergy = current;
        }

        public void AddItem(Item item)
        {
            if (inventory.Count >= maxSlots)
            {
                Console.WriteLine("Інвентар повний!");
                return;
            }
            inventory.Add(item);
            Console.WriteLine("Додано: " + item.Name);
        }

        public void RemoveItem(int id)
        {
            Item found = null;
            foreach (Item item in inventory)
            {
                if (item.Id == id)
                {
                    found = item;
                    break;
                }
            }

            if (found == null)
            {
                Console.WriteLine("Предмет не знайдено.");
                return;
            }

            inventory.Remove(found);
            Console.WriteLine("Видалено: " + found.Name);
        }

        public void ShowInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Інвентар порожній.");
                return;
            }

            Console.WriteLine("--- Інвентар " + Name + " ---");
            foreach (Item item in inventory)
            {
                Console.WriteLine("[" + item.Id + "] " + item.Name + " | Ціна: " + item.Price);
            }
        }

        public void UseItem(int id)
        {
            foreach (Item item in inventory)
            {
                if (item.Id == id)
                {
                    item.Use();
                    return;
                }
            }
            Console.WriteLine("Предмет не знайдено.");
        }

        public void ShowStats()
        {
            Console.WriteLine("Гравець: " + Name);
            Console.WriteLine("HP:     " + CurrentHealth + "/" + MaxHealth);
            Console.WriteLine("Mana:   " + CurrentMana + "/" + MaxMana);
            Console.WriteLine("Energy: " + CurrentEnergy + "/" + MaxEnergy);
        }
    }
}
