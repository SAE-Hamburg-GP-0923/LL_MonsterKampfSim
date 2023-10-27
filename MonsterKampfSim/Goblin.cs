namespace MonsterKampfSim
{
    internal class Goblin : Monster
    {
        Random random = new Random();
        public Action activateDodgeSkill;
        public Goblin(float _hp, float _ap, float _dp, float _s) : base(_hp, _ap, _dp, _s)
        {
            monsterName = "Goblin";
            MonsterRace = Game.EMonsterRace.Goblin;
        }
        public override void Attack(Monster _creatureToHit)
        {
            base.Attack(_creatureToHit);
        }
        public override void TakeDamage(float _damageTaken, bool _isCritical = false)
        {
            int triggerChance = random.Next(1, 11);
            if (triggerChance == 1 && !_isCritical)
            {
                activateDodgeSkill.Invoke();
            }
            else
            {
            base.TakeDamage(_damageTaken);
            }
        }
    }
}
