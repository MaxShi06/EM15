using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Code1.Models;
using ConsoleApp1.Code1.Services;

namespace ConsoleApp1.Code1
{
   internal class Program
    {
        static ContactService service = new ContactService();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== МЕНЕДЖЕР КОНТАКТІВ ===");
                Console.WriteLine("1 - Додати контакт");
                Console.WriteLine("2 - Показати всі контакти");
                Console.WriteLine("3 - Знайти контакт");
                Console.WriteLine("4 - Видалити контакт");
                Console.WriteLine("5 - Редагувати контакт");
                Console.WriteLine("0 - Вийти");
                Console.Write("Вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddContact(); Pause(); break;
                    case "2": ShowAll(); Pause(); break;
                    case "3": SearchContact(); Pause(); break;
                    case "4": DeleteContact(); Pause(); break;
                    case "5": EditContact(); Pause(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір."); Pause(); break;
                }
            }
        }

        static void AddContact()
        {
            Console.Write("Ім'я: ");
            string name = Console.ReadLine();

            List<string> phones = new List<string>();
            Console.WriteLine("Вводьте номери телефонів (порожній рядок — завершити):");
            while (true)
            {
                Console.Write("  Номер: ");
                string phone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phone)) break;

                if (!IsValidPhone(phone))
                {
                    Console.WriteLine("  Невірний формат. Номер має містити від 10 до 13 цифр.");
                    continue;
                }

                if (service.IsPhoneDuplicate(phone))
                {
                    Console.WriteLine("  Цей номер вже є в іншому контакті.");
                    continue;
                }

                phones.Add(phone);
            }

            Console.Write("Адреса: ");
            string address = Console.ReadLine();

            try
            {
                Contact contact = new Contact(name, phones, address);
                service.Add(contact);
                Console.WriteLine("Контакт додано.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

        static void ShowAll()
        {
            List<Contact> all = service.GetAll();
            if (all.Count == 0)
            {
                Console.WriteLine("Список контактів порожній.");
                return;
            }

            Console.WriteLine("\n--- Всі контакти ---");
            foreach (Contact c in all)
            {
                Console.WriteLine(c);
            }
        }

        static void SearchContact()
        {
            Console.Write("Пошуковий запит (ім'я або номер): ");
            string query = Console.ReadLine();

            List<Contact> results = service.Search(query);
            if (results.Count == 0)
            {
                Console.WriteLine("Нічого не знайдено.");
                return;
            }

            Console.WriteLine("\n--- Результати пошуку ---");
            foreach (Contact c in results)
            {
                Console.WriteLine(c);
            }
        }

        static void DeleteContact()
        {
            Console.Write("Введіть ID контакту для видалення: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());

                if (service.Delete(id))
                    Console.WriteLine("Контакт видалено.");
                else
                    Console.WriteLine("Контакт з таким ID не знайдено.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: введіть числовий ID.");
            }
        }

        static void EditContact()
        {
            Console.Write("Введіть ID контакту для редагування: ");
            int id;
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: введіть числовий ID.");
                return;
            }

            Contact existing = service.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Контакт з таким ID не знайдено.");
                return;
            }

            Console.WriteLine("Поточні дані: " + existing);

            Console.Write("Нове ім'я (Enter — залишити поточне): ");
            string newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName)) newName = existing.Name;

            Console.Write("Нова адреса (Enter — залишити поточну): ");
            string newAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newAddress)) newAddress = existing.Address;

            try
            {
                service.UpdateById(id, newName, newAddress);
                Console.WriteLine("Контакт оновлено.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

static bool IsValidPhone(string phone)
        {
            string digits = phone.Replace("+", "");
            return digits.All(char.IsDigit) && digits.Length >= 10 && digits.Length <= 13;
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисніть Enter для продовження");
            Console.ReadLine();
        }
    }
}
