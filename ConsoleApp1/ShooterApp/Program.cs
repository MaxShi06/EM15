using System;
using System.Collections.Generic;
using ConsoleApp1.ShooterApp.Entity;

namespace ConsoleApp1.ShooterApp
{
    class ShooterProgram
    {
        static Player player;

        static void Main()
        {
            Console.Write("Ім'я гравця: ");
            string name = Console.ReadLine();
            player = new Player(name);

            player.AddWeapon(new Weapon(1, "AK-47",    "7.62", FireMode.Auto));
            player.AddWeapon(new Weapon(2, "Glock 17", "9mm",  FireMode.Single));
            player.AddMagazine(new Magazine(1, "7.62", 30));
            player.AddMagazine(new Magazine(2, "7.62", 30));
            player.AddMagazine(new Magazine(3, "9mm",  17));

            while (true)
            {
                Console.Clear();
                DrawHUD();

                Console.WriteLine();
                Console.WriteLine("  1 - Вибрати зброю по ID");
                Console.WriteLine("  2 - Перемкнути зброю");
                Console.WriteLine("  3 - Перезарядити");
                Console.WriteLine("  4 - Стріляти");
                Console.WriteLine("  5 - Змінити режим вогню");
                Console.WriteLine("  0 - Вийти");
                Console.Write("\n  Вибір: ");

                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1": SelectWeapon(); break;
                    case "2": player.SwitchWeapon(); break;
                    case "3": player.Reload(); break;
                    case "4":
                        if (player.ActiveWeapon != null)
                            player.ActiveWeapon.Shoot();
                        else
                            Console.WriteLine("  Немає активної зброї.");
                        break;
                    case "5":
                        if (player.ActiveWeapon != null)
                            player.ActiveWeapon.SwitchFireMode();
                        else
                            Console.WriteLine("  Немає активної зброї.");
                        break;
                    case "0": return;
                    default: Console.WriteLine("  Невірний вибір."); break;
                }

                Console.WriteLine("\n  Натисніть Enter для продовження...");
                Console.ReadLine();
            }
        }

        static void DrawHUD()
        {
            Console.WriteLine("  ╔══════════════════════════════════════╗");
            Console.WriteLine("  ║  ГРАВЕЦЬ: " + PadRight(player.Name, 27) + "║");
            Console.WriteLine("  ╠══════════════════════════════════════╣");

            // --- зброя ---
            Console.WriteLine("  ║  ЗБРОЯ                               ║");
            List<Weapon> weapons = player.GetWeapons(); 
            if (weapons.Count == 0)
            {
                Console.WriteLine("  ║    (немає)                           ║");
            }
            else
            {
                foreach (Weapon w in weapons)
                {
                    string active = (w == player.ActiveWeapon) ? "►" : " ";
                    string magInfo = (w.Magazine != null) ? w.Magazine.Bullets + " набоїв" : "без магазину";
                    string line = active + " [" + w.Id + "] " + w.Name + " | " + w.Caliber + " | " + w.FireMode + " | " + magInfo;
                    Console.WriteLine("  ║  " + PadRight(line, 36) + "║");
                }
            }

            Console.WriteLine("  ╠══════════════════════════════════════╣");

            // --- магазини ---
            Console.WriteLine("  ║  МАГАЗИНИ В ІНВЕНТАРІ                ║");
            List<Magazine> magazines = player.GetMagazines();
            if (magazines.Count == 0)
            {
                Console.WriteLine("  ║    (немає)                           ║");
            }
            else
            {
                foreach (Magazine m in magazines)
                {
                    string line = "[" + m.Id + "] " + m.Caliber + "  —  " + m.Bullets + " набоїв";
                    Console.WriteLine("  ║    " + PadRight(line, 34) + "║");
                }
            }

            Console.WriteLine("  ╚══════════════════════════════════════╝");
        }

        static string PadRight(string text, int width)
        {
            if (text.Length >= width) return text.Substring(0, width);
            return text + new string(' ', width - text.Length);
        }

        static void SelectWeapon()
        {
            Console.Write("  Введіть ID зброї: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                player.SelectWeaponId(id);
            }
            catch (FormatException)
            {
                Console.WriteLine("  Невірний ID.");
            }
        }
    }
}
