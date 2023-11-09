namespace MonsterKampfSim
{
    internal class Troll : Monster
    {
        private float maxHP;
        public Action ActivateHealSkill;
        public Troll(float _hp, float _ap, float _dp, float _s) : base(_hp, _ap, _dp, _s)
        {
            monsterName = "Troll";
            monsterRace = Game.EMonsterRace.Troll;
            maxHP = _hp;
        }
        public override void Attack(Monster _creatureToHit)
        {
            base.Attack(_creatureToHit);
        }
        public override void TakeDamage(float _damageTaken, bool _isCritical = false)
        {
            base.TakeDamage(_damageTaken);
            if (HP > 0 && HP < maxHP)
            {
                ActivateHealSkill.Invoke();
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
