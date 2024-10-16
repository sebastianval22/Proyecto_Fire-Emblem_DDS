namespace Fire_Emblem.Skills.Effects
{
    public class ResistanceCostEffect : Effect, ICostEffect
    {
        private int _cost;

        public int Cost
        {
            get => _cost;
            protected set => _cost = value;
        }

        public ResistanceCostEffect(int cost)
        {
            _cost = cost;
        }

        public override void Apply(Unit unit)
        {
            unit.Resistance.Penalty -= _cost;
        }
    }
}