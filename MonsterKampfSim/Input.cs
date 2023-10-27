namespace MonsterKampfSim
{
    internal class Input
    {
        public Action<float, float> printInputError;
        public Action<float, float> printRangeInstruction;
        public Action printRaceError;
        public Action printStep1;
        public Action printStep2;
        public Action printStep3;
        public Action printStep4;
        public Action printStep5;
        private int stepID = 1;
        public float GetMonsterFloatInput(float _min, float _max)
        {
            while (true)
            {
                switch (stepID)
                {
                    case 1:
                        printStep1.Invoke();
                        stepID++;
                        break;
                    case 2:
                        printStep2.Invoke();
                        stepID++;
                        break;
                    case 3:
                        printStep3.Invoke();
                        stepID++;
                        break;
                    case 4:
                        printStep4.Invoke();
                        stepID = 1;
                        break;
                }
                printRangeInstruction.Invoke(_min, _max);
                var userInput = Console.ReadLine();
                if (float.TryParse(userInput, out var floatInput) && floatInput >= _min && floatInput <= _max)
                {
                    Console.Clear();
                    return floatInput;
                }
                else
                {
                    stepID--;
                    printInputError.Invoke(_min, _max);
                }
            }
        }
        public Game.EMonsterRace GetMonsterRaceInput(float _min, float _max)
        {
            while (true)
            {
                printStep5.Invoke();
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out var intInput) && intInput >= _min &&  intInput <= _max)
                {
                    Console.Clear();
                    switch (intInput)
                    {
                        case 1:
                            return Game.EMonsterRace.Ork;
                        case 2:
                            return Game.EMonsterRace.Troll;
                        case 3:
                            return Game.EMonsterRace.Goblin;
                    }

                }
                else
                {
                    Console.Clear();
                    printInputError.Invoke(_min, _max);
                }
            }
        }

        internal Game.EMonsterRace ChooseDifferentRace(Game.EMonsterRace _race)
        {
            while (true)
            {
                Console.Clear();
                printRaceError.Invoke();
                printStep5.Invoke();
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out var intInput) && intInput <= 3 && intInput >= 1 && intInput != (int)_race)
                {
                    return (Game.EMonsterRace)intInput;
                }
            }
        }

        public float GetAnyFloatInput(float _min, float _max)
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out var floatInput))
                {
                    return floatInput;
                }
                else
                {
                    printInputError.Invoke(_min, _max);
                }
            }
        }
    }
}
