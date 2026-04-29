using System;
using System.Collections.Generic;

namespace ConsoleApp1.Code2
{
    internal class TeamListService
    {
        private List<Team> _teams = new List<Team>();

        public void AddTeam(string name, string country)
        {
            Team team = new Team(name, country);
            _teams.Add(team);
        }

        public bool EditTeamById(int id, string name, string country)
        {
            Team team = GetTeamById(id);
            if (team == null) return false;

            team.Name = name;
            team.Country = country;
            return true;
        }

        public List<Team> GetAllTeams()
        {
            return _teams;
        }

        public Team GetTeamById(int id)
        {
            foreach (Team t in _teams)
            {
                if (t.Id == id)
                    return t;
            }
            return null;
        }

        public bool DeleteTeamId(int id)
        {
            Team team = GetTeamById(id);
            if (team == null) return false;

            _teams.Remove(team);
            return true;
        }

        public List<Team> SearchTeams(string name)
        {
            List<Team> result = new List<Team>();
            foreach (Team t in _teams)
            {
                if (t.Name.ToLower().Contains(name.ToLower()))
                    result.Add(t);
            }
            return result;
        }

        public void GetStats(int id, GameListService gameService)
        {
            Team team = GetTeamById(id);
            if (team == null)
            {
                Console.WriteLine("Команду не знайдено.");
                return;
            }

            int wins = 0, draws = 0, losses = 0;

            foreach (Game game in gameService.GetAllGames())
            {
                bool isHome = game.HomeTeamId == id;
                bool isAway = game.AwayTeamId == id;

                if (!isHome && !isAway) continue;

                if (game.HomeScore == game.AwayScore)
                {
                    draws++;
                }
                else if (isHome && game.HomeScore > game.AwayScore)
                {
                    wins++;
                }
                else if (isAway && game.AwayScore > game.HomeScore)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }

            Console.WriteLine("Команда:  " + team.Name);
            Console.WriteLine("Очки:     " + team.Points);
            Console.WriteLine("Перемоги: " + wins);
            Console.WriteLine("Нічиї:    " + draws);
            Console.WriteLine("Поразки:  " + losses);
        }

        public Team GetLeader()
        {
            if (_teams.Count == 0) return null;

            Team leader = _teams[0];
            for (int i = 1; i < _teams.Count; i++)
            {
                if (_teams[i].Points > leader.Points)
                    leader = _teams[i];
            }
            return leader;
        }
    }
}
