namespace MonsterKampfSim
{
    internal class Troll : Monster
    {
        private float maxHP;
        public Action activateHealSkill;
        public Troll(float _hp, float _ap, float _dp, float _s) : base(_hp, _ap, _dp, _s)
        {
            monsterName = "Troll";
            MonsterRace = Game.EMonsterRace.Troll;
            maxHP = _hp;
        }
        public override void Attack(Monster _creatureToHit)
        {
            base.Attack(_creatureToHit);
        }
        public override void TakeDamage(float _damageTaken, bool _isCritical = false)
        {
            base.TakeDamage(_damageTaken);
            if (HP > 0)
            {
                activateHealSkill.Invoke();
                SelfHeal();
            }
        }

        private void SelfHeal()
        {
            float healValue = maxHP * 0.05f;
            HP = MathF.Min(maxHP, HP + healValue);
        }
    }
}
