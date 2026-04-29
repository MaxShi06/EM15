using System;
using System.Collections.Generic;

namespace ConsoleApp1.Code2
{
     internal class Program
    {
        static TeamListService teamService = new TeamListService();
        static GameListService gameService = new GameListService();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== Турнірна таблиця ===");
                Console.WriteLine("1 - Додати команду");
                Console.WriteLine("2 - Редагувати команду");
                Console.WriteLine("3 - Видалити команду");
                Console.WriteLine("4 - Знайти команду");
                Console.WriteLine("5 - Статистика команди");
                Console.WriteLine("6 - Лідер турніру");
                Console.WriteLine("--- Ігри ---");
                Console.WriteLine("7 - Додати гру");
                Console.WriteLine("8 - Переглянути всі ігри");
                Console.WriteLine("9 - Видалити гру");
                Console.WriteLine("0 - Вийти");
                Console.Write("Вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddTeam(); break;
                    case "2": EditTeam(); break;
                    case "3": DeleteTeam(); break;
                    case "4": SearchTeam(); break;
                    case "5": TeamStats(); break;
                    case "6": ShowLeader(); break;
                    case "7": AddGame(); break;
                    case "8": ShowAllGames(); break;
                    case "9": DeleteGame(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір."); break;
                }

                Console.WriteLine("\nНатисніть Enter для продовження...");
                Console.ReadLine();
            }
        }

        static void AddTeam()
        {
            Console.Write("Назва команди: ");
            string name = Console.ReadLine();

            Console.Write("Країна: ");
            string country = Console.ReadLine();

            try
            {
                teamService.AddTeam(name, country);
                Console.WriteLine("Команду додано.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

        static void EditTeam()
        {
            ShowAllTeams();
            Console.Write("ID команди: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Нова назва: ");
                string name = Console.ReadLine();

                Console.Write("Нова країна: ");
                string country = Console.ReadLine();

                if (teamService.EditTeamById(id, name, country))
                    Console.WriteLine("Оновлено.");
                else
                    Console.WriteLine("Команду не знайдено.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірний ID.");
            }
        }

        static void DeleteTeam()
        {
            ShowAllTeams();
            Console.Write("ID команди для видалення: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());

                if (teamService.DeleteTeamId(id))
                    Console.WriteLine("Видалено.");
                else
                    Console.WriteLine("Команду не знайдено.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірний ID.");
            }
        }

        static void SearchTeam()
        {
            Console.Write("Назва для пошуку: ");
            string name = Console.ReadLine();

            List<Team> results = teamService.SearchTeams(name);

            if (results.Count == 0)
            {
                Console.WriteLine("Нічого не знайдено.");
                return;
            }

            foreach (Team t in results)
                Console.WriteLine("[" + t.Id + "] " + t.Name + " (" + t.Country + ") — " + t.Points + " очок");
        }

        static void TeamStats()
        {
            ShowAllTeams();
            Console.Write("ID команди: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                teamService.GetStats(id, gameService);
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірний ID.");
            }
        }

        static void ShowLeader()
        {
            Team leader = teamService.GetLeader();
            if (leader == null)
                Console.WriteLine("Команд ще немає.");
            else
                Console.WriteLine("Лідер: [" + leader.Id + "] " + leader.Name + " — " + leader.Points + " очок");
        }

        static void AddGame()
        {
            ShowAllTeams();
            try
            {
                Console.Write("ID господарів: ");
                int homeId = Convert.ToInt32(Console.ReadLine());

                Console.Write("ID гостей: ");
                int awayId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Стадіон: ");
                string stadium = Console.ReadLine();

                Console.Write("Рахунок господарів: ");
                int homeScore = Convert.ToInt32(Console.ReadLine());

                Console.Write("Рахунок гостей: ");
                int awayScore = Convert.ToInt32(Console.ReadLine());

                gameService.AddGame(homeId, awayId, stadium, homeScore, awayScore, teamService);
                Console.WriteLine("Гру додано.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірний ввід.");
            }
        }

        static void ShowAllGames()
        {
            List<Game> games = gameService.GetAllGames();
            if (games.Count == 0)
            {
                Console.WriteLine("Ігор ще немає.");
                return;
            }

            foreach (Game g in games)
                Console.WriteLine("[" + g.Id + "] Команда " + g.HomeTeamId + " vs Команда " + g.AwayTeamId + " | " + g.GetResult() + " | " + g.Stadium);
        }

        static void DeleteGame()
        {
            ShowAllGames();
            Console.Write("ID гри для видалення: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());

                if (gameService.DeleteGameById(id))
                    Console.WriteLine("Видалено.");
                else
                    Console.WriteLine("Гру не знайдено.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірний ID.");
            }
        }

        static void ShowAllTeams()
        {
            List<Team> teams = teamService.GetAllTeams();
            if (teams.Count == 0)
            {
                Console.WriteLine("Команд ще немає.");
                return;
            }

            Console.WriteLine("\n--- Команди ---");
            foreach (Team t in teams)
                Console.WriteLine("[" + t.Id + "] " + t.Name + " (" + t.Country + ") — " + t.Points + " очок");
        }
    }
}
