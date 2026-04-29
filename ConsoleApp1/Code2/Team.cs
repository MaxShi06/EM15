using System;

namespace ConsoleApp1.Code2
{
    internal class Team
    {
        private static int _nextId = 1;

        private string _name;
        private string _country;

        public Team(string name, string country)
        {
            Id = _nextId++;
            Name = name;
            Country = country;
            Points = 0;
        }

        public int Id { get; private set; }
        public int Points { get; private set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва не може бути пустою.");
                _name = value;
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Країна не може бути пустою.");
                _country = value;
            }
        }

        public void AddPoints(int points)
        {
            Points += points;
        }

    }
}
