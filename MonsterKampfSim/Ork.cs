namespace MonsterKampfSim
{
    internal class Ork : Monster
    {
        Random random = new Random();
        public Ork(float _hp, float _ap, float _dp, float _s) : base(_hp, _ap, _dp, _s)
        {
            monsterName = "Ork";
            MonsterRace = Game.EMonsterRace.Ork;
        }

        public override void Attack(Monster _creatureToHit)
        {
            int triggerChance = random.Next(1, 21);
            if (triggerChance == 1)
            {
                _creatureToHit.TakeDamage(ap * 2);
            }
            else
            {
                base.Attack(_creatureToHit);
            }
        }
        public override void TakeDamage(float _damageTaken, bool _isCritical = false)
        {
            base.TakeDamage(_damageTaken);
        }

    }
}
