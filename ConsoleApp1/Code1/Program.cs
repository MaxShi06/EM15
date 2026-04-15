using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, string> contacts = new Dictionary<string, string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
            Console.WriteLine("1 - Робота зі словами");
            Console.WriteLine("2 - Контакти");
            Console.WriteLine("0 - Вихід");
            Console.Write("Вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WordsProgram();
                    break;

                case "2":
                    ContactsProgram();
                    break;

                case "0":
                    return;
            }
        }
    }

    // 1
    static void WordsProgram()
    {
        Console.WriteLine("Введи речення:");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))//IsNullOrWhiteSpace Перевіряє, чи рядок пустий або містить тільки пробіли
        {
            Console.WriteLine("Помилка: рядок пустий");
            return;
        }

        string[] wordsArray = input.Split(' ');
        List<string> wordsList = new List<string>();

        for (int i = 0; i < wordsArray.Length; i++)
        {
            if (wordsArray[i] != "")
            {
                wordsList.Add(wordsArray[i]);
            }
        }

        Console.WriteLine("Слова:");

        for (int i = 0; i < wordsList.Count; i++)
        {
            Console.WriteLine(wordsList[i]);
        }
    }

    //  2
    static void ContactsProgram()
    {
        while (true)
        {
            Console.WriteLine("\n1-Додати 2-Редагувати 3-Видалити 4-Пошук 5-Показати 0-Назад");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": Add(); break;
                case "2": Edit(); break;
                case "3": Delete(); break;
                case "4": Search(); break;
                case "5": Show(); break;
                case "0": return;
            }
        }
    }

    static void Add()
    {
        Console.Write("Ім’я: ");
        string name = Console.ReadLine();

        Console.Write("Телефон: ");
        string phone = Console.ReadLine();

        if (name.Length >= 2 && phone.Length >= 10 && phone.Length <= 12)
        {
            contacts[name] = phone;
            Console.WriteLine("Додано");
        }
        else
        {
            Console.WriteLine("Невірні дані");
        }
    }

    static void Edit()
    {
        Console.Write("Ім’я контакту: ");
        string name = Console.ReadLine();

        if (contacts.ContainsKey(name))
        {
            Console.Write("Новий номер: ");
            string phone = Console.ReadLine();
            contacts[name] = phone;
            Console.WriteLine("Оновлено");
        }
        else
        {
            Console.WriteLine("Не знайдено");
        }
    }

    static void Delete()
    {
        Console.Write("Ім’я: ");
        string name = Console.ReadLine();

        if (contacts.Remove(name))
        {
            Console.WriteLine("Видалено");
        }
        else
        {
            Console.WriteLine("Не знайдено");
        }
    }

    static void Search()
    {
        Console.Write("Пошук: ");
        string query = Console.ReadLine();

        foreach (var c in contacts)
        {
            if (c.Key.Contains(query))
            {
                Console.WriteLine(c.Key + " - " + c.Value);
            }
        }
    }

    static void Show()
    {
        foreach (var c in contacts)
        {
            Console.WriteLine(c.Key + " - " + c.Value);
        }
    }
}