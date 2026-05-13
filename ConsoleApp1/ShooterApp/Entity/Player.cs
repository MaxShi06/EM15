using System;
using System.Collections.Generic;

namespace ConsoleApp1.ShooterApp.Entity
{
    class Player
    {
        public string Name;
        public Weapon ActiveWeapon;

        private List<Weapon> weapons = new List<Weapon>();
        private List<Magazine> magazines = new List<Magazine>();

        private int maxWeapons = 4;
        private int maxMagazines = 6;

        public Player(string name)
        {
            Name = name;
        }

        public void AddWeapon(Weapon weapon)
        {
            if (weapons.Count >= maxWeapons)
            {
                Console.WriteLine("Слоти зброї заповнені (макс. " + maxWeapons + ")!");
                return;
            }
            weapons.Add(weapon);
            if (ActiveWeapon == null)
                ActiveWeapon = weapon;
            Console.WriteLine("Зброю додано: " + weapon.Name);
        }

        public void AddMagazine(Magazine mag)
        {
            if (magazines.Count >= maxMagazines)
            {
                Console.WriteLine("Слоти магазинів заповнені (макс. " + maxMagazines + ")!");
                return;
            }
            magazines.Add(mag);
            Console.WriteLine("Магазин додано: " + mag.Caliber + " (" + mag.Bullets + " набоїв)");
        }

        public void SelectWeaponId(int id)
        {
            Weapon found = weapons.Find(w => w.Id == id);
            if (found == null)
            {
                Console.WriteLine("Зброю з ID " + id + " не знайдено.");
                return;
            }
            ActiveWeapon = found;
            Console.WriteLine("Активна зброя: " + found.Name);
        }

        public void SwitchWeapon()
        {
            if (weapons.Count == 0)
            {
                Console.WriteLine("Немає зброї.");
                return;
            }

            int index = weapons.IndexOf(ActiveWeapon);// Index of це метод для List, який повертає індекс елемента.
            int next = (index + 1) % weapons.Count;
            ActiveWeapon = weapons[next];
            Console.WriteLine("Активна зброя: " + ActiveWeapon.Name);
        }

        public void Reload()
        {
            if (ActiveWeapon == null)
            {
                Console.WriteLine("Немає активної зброї.");
                return;
            }

            Magazine found = magazines.Find(mag => mag.Caliber == ActiveWeapon.Caliber);

            if (found == null)
            {
                Console.WriteLine("Немає магазину калібру " + ActiveWeapon.Caliber + " в інвентарі.");
                return;
            }

            if (ActiveWeapon.Magazine != null)
            {
                magazines.Add(ActiveWeapon.Magazine);
                Console.WriteLine("Старий магазин повернуто в інвентар.");
            }

            magazines.Remove(found);
            ActiveWeapon.ReplaceMagazine(found);
        }

        public void ShowWeapons()
        {
            if (weapons.Count == 0)
            {
                Console.WriteLine("Немає зброї.");
                return;
            }

            Console.WriteLine("--- Зброя ---");
            foreach (Weapon w in weapons)
            {
                string active = (w == ActiveWeapon) ? " [АКТИВНА]" : "";
                string magInfo = (w.Magazine != null) ? w.Magazine.Bullets + " набоїв" : "без магазину";
                Console.WriteLine("[" + w.Id + "] " + w.Name + " | " + w.Caliber + " | " + w.FireMode + " | " + magInfo + active);
            }
        }

        public void ShowMagazines()
        {
            if (magazines.Count == 0)
            {
                Console.WriteLine("Немає магазинів.");
                return;
            }

            Console.WriteLine("--- Магазини ---");
            foreach (Magazine m in magazines)
            {
                Console.WriteLine("[" + m.Id + "] Калібр: " + m.Caliber + " | Набоїв: " + m.Bullets);
            }
        }
        public List<Weapon> GetWeapons()
        {
            return weapons;
        }

        public List<Magazine> GetMagazines()
        {
            return magazines;
        }
    }
}
