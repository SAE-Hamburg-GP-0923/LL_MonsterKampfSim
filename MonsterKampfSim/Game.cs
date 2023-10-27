namespace MonsterKampfSim
{
    internal class Game
    {
        private bool debug;
        private bool gameRunning = true;
        private Monster monster1;
        private Monster monster2;
        private Input userInput;
        private UI text;
        private delegate void EndGamePrintHandler(Monster _winningMonster, int _roundCount);
        private event EndGamePrintHandler endGamePrint;
        private delegate void ChangeStatHandler(Monster _monsterToChangeStatsOn);
        private event ChangeStatHandler changeMonsterStat;
        private Action startGame;
        private int roundCount;

        public enum EMonsterRace
        {
            Ork = 1,
            Troll = 2,
            Goblin = 3,
        }

        public Game(bool _debug)
        {
            debug = _debug;
        }

        public void GameInit()
        {
            userInput = new Input();
            text = new UI();
            text.PrintInstructions();
            userInput.printStep1 += text.PrintInputHP;
            userInput.printStep2 += text.PrintInputAP;
            userInput.printStep3 += text.PrintInputDP;
            userInput.printStep4 += text.PrintInputS;
            userInput.printStep5 += text.PrintInputRace;
            userInput.printRaceError += text.PrintChooseDifferentRace;
            userInput.printInputError += text.PrintErrorMessage;
            userInput.printRangeInstruction += text.PrintRangeInstruction;
            monster1 = new Monster(userInput.GetMonsterFloatInput(1, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterRaceInput(1,3));
            text.PrintNextMonsterText();
            monster2 = new Monster(userInput.GetMonsterFloatInput(1, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterFloatInput(0, 100), userInput.GetMonsterRaceInput(1,3));
            changeMonsterStat += text.PrintChangeStat;
            //printHPError += text.PrintHPError;
            CheckInvalidStats();
            monster1.HPPrint += text.PrintHP;
            monster2.HPPrint += text.PrintHP;
            monster1.DamagePrint += text.PrintDamage;
            monster2.DamagePrint += text.PrintDamage;
            endGamePrint += text.PrintEndGame;
            startGame += text.StartGame;
            if (monster1.S >= monster2.S)
            {
                GameUpdate(monster1, monster2);
            }
            else if (monster2.S > monster1.S)
            {
                GameUpdate(monster2, monster1);
            }
        }

        private void GameUpdate(Monster _firstMonster, Monster _secondMonster)
        {
            startGame.Invoke();
            while (gameRunning)
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

        private void CheckInvalidStats()
        {
            bool invalidStats = true;
            while (invalidStats)
            {
                if (monster1.Race == monster2.Race)
                {
                    var changedMonsterRace = userInput.ChooseDifferentRace(monster2.Race);
                    monster2.ChangeRace(changedMonsterRace);

                }
                else if (monster1.Ap <= monster2.DP && monster2.Ap <= monster1.DP)
                {
                    changeMonsterStat.Invoke(monster1);
                    var changedMonsterStat = userInput.GetAnyFloatInput(0,100);
                    monster2.ChangeStat(Monster.EMonsterStats.ap, changedMonsterStat);

                }
                //else if (monster1.HP <= 0 || monster2.HP <= 0)
                //{
                //    printHPError.Invoke();
                //    monster1.ChangeStat(Monster.EMonsterStats.hp, MathF.Max(1, monster1.HP));
                //    monster2.ChangeStat(Monster.EMonsterStats.hp, MathF.Max(1, monster2.HP));
                //}
                else
                {
                    invalidStats = false;
                }
            }
        }

    }
}
