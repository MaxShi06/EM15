using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Code2
{
    class GameListService
    {
        private List<Game> _games = new List<Game>();

        public void AddGame(int homeTeamId, int awayTeamId, string stadium, int homeScore, int awayScore, TeamListService teamService)
        {
            Game game = new Game(homeTeamId, awayTeamId, stadium, homeScore, awayScore);
            _games.Add(game);

            Team home = teamService.GetTeamById(homeTeamId);
            Team away = teamService.GetTeamById(awayTeamId);

            if (home == null || away == null) return;

            if (homeScore > awayScore)
            {
                home.AddPoints(3); 
            }
            else if (homeScore < awayScore)
            {
                away.AddPoints(3); 
            }
            else
            {
                home.AddPoints(1);
                away.AddPoints(1);
            }
        }

        public List<Game> GetAllGames()
        {
            return _games;
        }

        public Game GetGameById(int id)
        {
            return _games.FirstOrDefault(g => g.Id == id);
        }

        public bool DeleteGameById(int id)
        {
            Game game = GetGameById(id);
            if (game == null) return false;

            _games.Remove(game);
            return true;
        }
    }
}
