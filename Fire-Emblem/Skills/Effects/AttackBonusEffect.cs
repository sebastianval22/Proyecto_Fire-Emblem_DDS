namespace Fire_Emblem.Skills.Effects
{
    public class AttackBonusEffect : Effect, IBonusEffect
    {
        private int _bonus;

        protected int Bonus
        {
            get => _bonus;
            set => _bonus = value;
           
        }

        public AttackBonusEffect(int bonus)
        {
            _bonus = bonus;
        }

        public override void Apply(Unit unit)
        {
            unit.Attack.Bonus += _bonus;
        }
    }
}