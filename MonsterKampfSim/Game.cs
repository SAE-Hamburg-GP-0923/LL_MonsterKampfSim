namespace MonsterKampfSim
{
    public class Game
    {
        #region Private variables
        private bool debug;
        private bool gameRunning = true;
        private Monster monster1;
        private Monster monster2;
        private Input userInput;
        private UI text;
        private delegate void EndGamePrintHandler(Monster _winningMonster, int _roundCount);
        private event EndGamePrintHandler endGamePrint;
        private delegate void ChangeStatHandler(Monster _monsterToChangeStatsOn);
        private Action startGame;
        private Action endGameDraw;
        private int roundCount;
        private int maxRoundCount;
        #endregion

        // Enum to make monster race readable
        public enum EMonsterRace
        {
            Ork = 1,
            Troll = 2,
            Goblin = 3,
        }

        public Game(bool _debug, int _maxRoundCount)
        {
            debug = _debug;
            maxRoundCount = _maxRoundCount;
        }

        // Start game function
        public void GameInit()
        {
            userInput = new Input();
            text = new UI();
            text.RegisterInput(userInput);
            text.PrintInstructions();
            monster1 = CreateMonster();
            text.RegisterMonsters(monster1);
            text.PrintNextMonsterText();
            monster2 = CreateMonster();
            text.RegisterMonsters(monster2);
            startGame += text.StartGame;
            endGamePrint += text.PrintEndGame;
            endGameDraw += text.PrintEndGameDraw;
            if (monster1.S >= monster2.S)
            {
                GameUpdate(monster1, monster2);
            }
            else if (monster2.S > monster1.S)
            {
                GameUpdate(monster2, monster1);
            }
        }

        // Fight logic
        private void GameUpdate(Monster _firstMonster, Monster _secondMonster)
        {
            startGame.Invoke();
            while (gameRunning && roundCount < maxRoundCount)
            {
                if (_firstMonster.HP > 0 && _secondMonster.HP > 0)
                {
                    roundCount++;
                    _firstMonster.Attack(_secondMonster);
                    CheckVictoryCondition(_firstMonster, _secondMonster);
                    if (!gameRunning) break;
                    _secondMonster.Attack(_firstMonster);
                    CheckVictoryCondition(_firstMonster, _secondMonster);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            endGameDraw.Invoke();
        }

        private void CheckVictoryCondition(Monster _firstMonster, Monster _secondMonster)
        {
            if (_firstMonster.HP <= 0)
            {
                gameRunning = false;
                endGamePrint.Invoke(_secondMonster, roundCount);
            }
            else if (_secondMonster.HP <= 0)
            {
                gameRunning = false;
                endGamePrint.Invoke(_firstMonster, roundCount);
            }
        }
        private Monster CreateMonster()
        {
            int raceInput;
            do
            {
                raceInput = userInput.GetMonsterRaceInput(1, 3);

            } while (monster1 != null && (EMonsterRace)raceInput == monster1.MonsterRace);
            switch ((EMonsterRace)raceInput)
            {
                case EMonsterRace.Ork:
                    return new Ork(userInput.GetMonsterFloatInput(1, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100));
                case EMonsterRace.Troll:
                    return new Troll(userInput.GetMonsterFloatInput(1, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100));
                case EMonsterRace.Goblin:
                    return new Goblin(userInput.GetMonsterFloatInput(1, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
