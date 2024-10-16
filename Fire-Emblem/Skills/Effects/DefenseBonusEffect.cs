namespace Fire_Emblem.Skills.Effects
{
    public class DefenseBonusEffect : Effect, IBonusEffect
    {
        private int _bonus;

        public int Bonus
        {
            get => _bonus;
            protected set => _bonus = value;
        }

        public DefenseBonusEffect(int bonus)
        {
            _bonus = bonus;
        }

        public override void Apply(Unit unit)
        {
            unit.Defense.Bonus += _bonus;
        }
    }
}