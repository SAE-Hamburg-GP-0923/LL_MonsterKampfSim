namespace MonsterKampfSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(false, 10);
            game.GameInit();
        }
    }
}