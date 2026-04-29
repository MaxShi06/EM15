namespace ConsoleApp1.Code2
{
    internal class Game
    {
        private static int _nextId = 1;

        public Game(int homeTeamId, int awayTeamId, string stadium, int homeScore, int awayScore)
        {
            Id = _nextId++;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            Stadium = stadium;
            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        public int Id { get; private set; }
        public int HomeTeamId { get; private set; }
        public int AwayTeamId { get; private set; }
        public string Stadium { get; private set; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public string GetResult()
        {
            return HomeScore + ":" + AwayScore;
        }
    }
}
