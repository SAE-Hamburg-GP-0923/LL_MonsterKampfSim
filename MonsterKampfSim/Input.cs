namespace MonsterKampfSim
{
    internal class Input
    {
        #region actions and help variables
        public Action<float, float> PrintInputError;
        public Action<float, float> PrintRangeInstruction;
        public Action PrintRaceError;
        public Action PrintStep1;
        public Action PrintStep2;
        public Action PrintStep3;
        public Action PrintStep4;
        public Action PrintStep5;
        private int stepID = 1;
        #endregion

        //Func to gain float input for monster stats
        public float GetMonsterFloatInput(float _min, float _max)
        {
            while (true)
            {
                //switch is used to print correct UI text for each stat
                switch (stepID)
                {
                    case 1:
                        PrintStep1.Invoke();
                        stepID++;
                        break;
                    case 2:
                        PrintStep2.Invoke();
                        stepID++;
                        break;
                    case 3:
                        PrintStep3.Invoke();
                        stepID++;
                        break;
                    case 4:
                        PrintStep4.Invoke();
                        stepID = 1;
                        break;
                }
                PrintRangeInstruction.Invoke(_min, _max);
                var userInput = Console.ReadLine();
                if (float.TryParse(userInput, out var floatInput) && floatInput >= _min && floatInput <= _max)
                {
                    Console.Clear();
                    return floatInput;
                }
                else
                {
                    stepID--;
                    PrintInputError.Invoke(_min, _max);
                }
            }
        }
        public int GetMonsterRaceInput(float _min, float _max)
        {
            while (true)
            {
                PrintStep5.Invoke();
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out var intInput) && intInput >= _min && intInput <= _max)
                {
                    Console.Clear();
                    return intInput;
                }
                else
                {
                    Console.Clear();
                    PrintInputError.Invoke(_min, _max);
                }
            }
        }

        /// <summary>
        /// Func to change the race of the given monster
        /// </summary>
        /// <param name="_race"></param>
        /// <returns></returns>
        public Game.EMonsterRace ChooseDifferentRace(Game.EMonsterRace _race)
        {
            while (true)
            {
                Console.Clear();
                PrintRaceError.Invoke();
                PrintStep5.Invoke();
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
                    PrintInputError.Invoke(_min, _max);
                }
            }
        }
    }
}
