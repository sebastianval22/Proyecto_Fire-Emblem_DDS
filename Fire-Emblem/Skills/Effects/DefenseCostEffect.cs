namespace Fire_Emblem.Skills.Effects
{
    public class DefenseCostEffect : Effect, ICostEffect
    {
        private int _cost;

        public int Cost
        {
            get => _cost;
            protected set => _cost = value;
        }

        public DefenseCostEffect(int cost)
        {
            _cost = cost;
        }

        public override void Apply(Unit unit)
        {
            unit.Defense.Penalty -= _cost;
        }
    }
}