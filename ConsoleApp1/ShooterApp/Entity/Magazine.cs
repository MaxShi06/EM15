namespace ConsoleApp1.ShooterApp.Entity
{
    class Magazine
    {
        public int Id;
        public string Caliber;
        public int Bullets;

        public Magazine(int id, string caliber, int bullets)
        {
            Id = id;
            Caliber = caliber;
            Bullets = bullets;
        }
    }
}
