namespace MonsterKampfSim
{
    public abstract class Monster
    {
        #region variables & events
        public enum EMonsterStats
        {
            hp = 1,
            ap = 2,
            dp = 3,
            s = 4,
        }
        protected float hp;
        public float HP
        {
            get { return hp; }
            protected set
            {
                if (hp != value)
                {
                    hp = value;
                    HPPrint.Invoke(this);
                }

            }
        }
        protected float ap;
        public float Ap => ap;
        protected float dp;
        public float DP => dp;
        protected float s;
        public float S => s;

        protected Game.EMonsterRace monsterRace;
        public Game.EMonsterRace MonsterRace => monsterRace;
        protected string monsterName;
        public string MonsterName => monsterName;
        public delegate void DamagePrintHandler(Monster _monster, float _actualDamage);
        public event DamagePrintHandler DamagePrint;
        public delegate void HPPrintHandler(Monster _monster);
        public event HPPrintHandler HPPrint;
        #endregion

        public Monster(float _hp, float _ap, float _dp, float _s)
        {
            hp = _hp;
            ap = _ap;
            dp = _dp;
            s = _s;

        }

        #region generic monster functions to be overridden or used
        public virtual void Attack(Monster _creatureToHit)
        {
            _creatureToHit.TakeDamage(ap);

        }

        public virtual void TakeDamage(float _damageTaken, bool _isCritical = false)
        {
            float actualDamage;
            if (_isCritical)
            {
                actualDamage = MathF.Max(_damageTaken * 2 - dp, 0);
            }
            else
            {
                actualDamage = MathF.Max(_damageTaken - dp, 0);
            }
            DamagePrint.Invoke(this, actualDamage);
            HP = MathF.Max(0, HP - actualDamage);
        }
        #endregion
    }
}
