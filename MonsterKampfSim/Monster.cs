namespace MonsterKampfSim
{
    public abstract class Monster
    {

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

        public Game.EMonsterRace MonsterRace;
        protected string monsterName;
        public string MonsterName => monsterName;
        public delegate void DamagePrintHandler(Monster _monster, float _actualDamage);
        public event DamagePrintHandler DamagePrint;
        public delegate void HPPrintHandler(Monster _monster);
        public event HPPrintHandler HPPrint;

        public Monster(float _hp, float _ap, float _dp, float _s)
        {
            hp = _hp;
            ap = _ap;
            dp = _dp;
            s = _s;

        }


        public virtual void Attack(Monster _creatureToHit)
        {
            _creatureToHit.TakeDamage(ap);

        }

        //TODO: Dictionary<EMonsterStats, float> anlegen
        //public void ChangeStat(EMonsterStats _statToChange, float _value)
        //{
        //    switch (_statToChange)
        //    {
        //        case EMonsterStats.hp:
        //            hp = _value;
        //            break;
        //        case EMonsterStats.ap:
        //            ap = _value;
        //            break;
        //        case EMonsterStats.dp:
        //            dp = _value;
        //            break;
        //        case EMonsterStats.s:
        //            s = _value;
        //            break;

        //    }
        //}

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
    }
}
