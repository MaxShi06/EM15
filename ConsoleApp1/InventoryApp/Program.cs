using System;
using ConsoleApp1.InventoryApp.Items;

namespace ConsoleApp1.InventoryApp
{
    class InventoryProgram
    {
        static Player player;

        static void Main()
        {
            Console.Write("Введіть ім'я гравця: ");
            string name = Console.ReadLine();
            player = new Player(name, 100, 50, 80);

            while (true)
            {
                Console.WriteLine("\n=== Інвентар ===");
                Console.WriteLine("1 - Показати стати гравця");
                Console.WriteLine("2 - Показати інвентар");
                Console.WriteLine("3 - Додати предмет");
                Console.WriteLine("4 - Видалити предмет");
                Console.WriteLine("5 - Використати предмет");
                Console.WriteLine("0 - Вийти");
                Console.Write("Вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": player.ShowStats(); break;
                    case "2": player.ShowInventory(); break;
                    case "3": AddItem(); break;
                    case "4": RemoveItem(); break;
                    case "5": UseItem(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір."); break;
                }

                Console.WriteLine("\nНатисніть Enter для продовження...");
                Console.ReadLine();
            }
        }

        static void AddItem()
        {
            Console.WriteLine("Оберіть предмет:");
            Console.WriteLine("1 - Health Potion");
            Console.WriteLine("2 - Mana Potion");
            Console.Write("Вибір: ");

            string choice = Console.ReadLine();
            int id;

            try
            {
                Console.Write("ID предмета: ");
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірний ID.");
                return;
            }

            if (choice == "1")
                player.AddItem(new HealthPotion(id, 50));
            else if (choice == "2")
                player.AddItem(new ManaPotion(id, 30));
            else
                Console.WriteLine("Невірний вибір.");
        }

        static void RemoveItem()
        {
            player.ShowInventory();
            Console.Write("ID предмета для видалення: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                player.RemoveItem(id);
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірний ID.");
            }
        }

        static void UseItem()
        {
            player.ShowInventory();
            Console.Write("ID предмета для використання: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                player.UseItem(id);
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірний ID.");
            }
        }
    }
}
