namespace MonsterKampfSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // bool is for debug functions, int is max round count before a draw occurs
            Game game = new Game(false, 10);
            game.GameInit();
        }
    }
}