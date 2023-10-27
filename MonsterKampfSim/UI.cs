namespace MonsterKampfSim
{
    internal class UI
    {
        public void PrintErrorMessage(float _min, float _max)
        {
            Console.Clear();
            Console.WriteLine("Bitte gebe einen vernünftigen Wert ein!");
            Console.WriteLine($"Alle Werte dürfen nur zwischen {_min} und {_max} liegen!");
        }

        public void PrintInputHP()
        {
            Console.WriteLine("Bitte gebe zuerst die HP des Monsters ein!");
        }
        public void PrintInputAP()
        {
            Console.WriteLine("Bitte gebe die Angriffspunkte des Monsters ein!");
        }

        public void PrintInputDP()
        {
            Console.WriteLine("Bitte gebe die Verteidigungspunkte des Monsters ein!");
        }

        public void PrintInputS()
        {
            Console.WriteLine("Bitte gebe die Geschwindigkeit des Monsters ein!");
        }

        public void PrintInputRace()
        {
            Console.WriteLine("Bitte wähle die Rasse des Monsters!");
            Console.WriteLine("[1] = Ork");
            Console.WriteLine("[2] = Troll");
            Console.WriteLine("[3] = Goblin");
        }

        public void PrintNextMonsterText()
        {
            Console.WriteLine("Nun gebe erneut alle Werte ein. Diesesmal für das zweite Monster!");
        }

        public void PrintChooseDifferentRace()
        {
            Console.WriteLine("Die Monster dürfen nicht die gleiche Rasse haben! Bitte versuche es erneut!");
        }

        public void PrintEndGame(Monster _winningMonster, int _roundCount)
        {
            //Console.Clear();
            Console.WriteLine($"Der {_winningMonster.MonsterName} hat nach {_roundCount} Runden gewonnen!");
        }

        public void PrintHP(Monster _monster)
        {
            Console.WriteLine($"{_monster.MonsterName} hat noch {_monster.HP} Leben!");
        }

        public void PrintDamage(Monster _monster, float _actualDamage)
        {
            Console.WriteLine($"Der {_monster.MonsterName} hat {_actualDamage} Punkte Schaden bekommen!");
        }

        public void PrintChangeStat(Monster _monster)
        {
            Console.WriteLine("Deine Monster würden sich unendlich lange bekämpfen! Bitte gebe einen neuen Angriffswert ein der höher ist als die Verteidigung des ersten Monsters!");
            Console.WriteLine($"Das erste Monster hat {_monster.DP} Verteidigung!");
        }
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Alle Werte sind in Ordnung! Drücke eine beliebige Taste zum beginnen der Simulation!");
            Console.WriteLine("Die Simulation basiert auf Runden! Um die nächste Runde auszuführen drücke eine beliebige Taste nachdem die aktuellen Lebenswerte erschienen sind!");
            Console.ReadKey();
            Console.Clear();
        }
        public void PrintInstructions()
        {
            Console.WriteLine("Willkommen bei dieser kleinen Monster Kampf Simulation!");
            Console.WriteLine("Im folgenden definierst du die folgenden Werte für beide Monster!");
            Console.WriteLine("HP = Lebenspunkte");
            Console.WriteLine("AP = Angriffspunkte");
            Console.WriteLine("DP = Verteidigungspunkte");
            Console.WriteLine("S = Geschwindigkeit");
            Console.WriteLine("Sollten beide Monster gleich viel Geschwindigkeit haben, beginnt das erste welches du erstellt hast.");
            Console.WriteLine("Drücke nun eine beliebige Taste um zu beginnen!");
            Console.ReadKey();
            Console.Clear();

        }

        public void PrintRangeInstruction(float _min, float _max)
        {
            Console.WriteLine($"Der Wert muss zwischen {_min} und {_max} liegen!");
        }

        //public void PrintHPError()
        //{
        //    Console.WriteLine("Oh! Du hast einem oder beiden Monstern 0 Lebenspunkte gegeben!");
        //    Console.WriteLine("Ein Monster ohne Lebenspunkte ist ein totes Monster.");
        //    Console.WriteLine("Wir haben den Wert des/der betroffenen Monster/s auf 1 gesetzt!");
        //    Console.WriteLine("Bitt achte in Zukunft darauf, keine toten Monster zu erstellen!");
        //    Console.ReadKey();
        //}
    }
}
