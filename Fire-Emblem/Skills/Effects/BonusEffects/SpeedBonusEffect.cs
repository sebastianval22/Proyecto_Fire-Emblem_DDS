namespace Fire_Emblem.Skills.Effects.BonusEffects
{
    public class SpeedBonusEffect : Effect, IBonusEffect
    {
        private int _bonus;

        public int Bonus
        {
            get => _bonus;
            protected set => _bonus = value;
        }

        public SpeedBonusEffect(int bonus)
        {
            _bonus = bonus;
        }

        public override void Apply(Unit unit)
        {
            unit.Speed.Bonus += _bonus;
        }
    }
}