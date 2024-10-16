namespace Fire_Emblem.Skills.Effects
{
    public class ResistanceBonusEffect : Effect, IBonusEffect
    {
        private int _bonus;

        public int Bonus
        {
            get => _bonus;
            protected set => _bonus = value;
        }

        public ResistanceBonusEffect(int bonus)
        {
            _bonus = bonus;
        }

        public override void Apply(Unit unit)
        {
            unit.Resistance.Bonus += _bonus;
        }
    }
}