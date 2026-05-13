using System;

namespace ConsoleApp1.ShooterApp.Entity
{
    enum FireMode { Single, Burst, Auto } 

    class Weapon
    {
        public int Id;
        public string Name;
        public string Caliber;
        public Magazine Magazine;
        public FireMode FireMode;

        public Weapon(int id, string name, string caliber, FireMode fireMode)
        {
            Id = id;
            Name = name;
            Caliber = caliber;
            FireMode = fireMode;
            Magazine = null;
        }

        public void ReplaceMagazine(Magazine newMag)
        {
            Magazine = newMag;
            Console.WriteLine("Магазин встановлено. Набоїв: " + newMag.Bullets);
        }

        public void SwitchFireMode()
        {
            if (FireMode == FireMode.Single)
                FireMode = FireMode.Burst;
            else if (FireMode == FireMode.Burst)
                FireMode = FireMode.Auto;
            else
                FireMode = FireMode.Single;

            Console.WriteLine("Режим вогню: " + FireMode);
        }

        public void Shoot()
        {
            if (Magazine == null)
            {
                Console.WriteLine("Немає магазину! Перезарядіть.");
                return;
            }

            if (Magazine.Bullets <= 0)
            {
                Console.WriteLine("Магазин порожній! Перезарядіть.");
                return;
            }

            if (FireMode == FireMode.Single)
            {
                Magazine.Bullets--;
                Console.WriteLine("Постріл! Залишилось набоїв: " + Magazine.Bullets);
            }
            else if (FireMode == FireMode.Burst)
            {
                int shots = Math.Min(3, Magazine.Bullets);
                Magazine.Bullets -= shots;
                Console.WriteLine("Черга (" + shots + " постр.)! Залишилось: " + Magazine.Bullets);
            }
            else if (FireMode == FireMode.Auto)
            {
                Console.WriteLine("Автоогонь! Витрачено " + Magazine.Bullets + " набоїв.");
                Magazine.Bullets = 0;
            }
        }
    }
}
