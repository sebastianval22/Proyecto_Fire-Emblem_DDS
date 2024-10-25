namespace Fire_Emblem.Skills.Effects.CostEffects
{
    public class AttackCostEffect : Effect, ICostEffect
    {
        
        private int _cost;

        public int Cost
        {
            get => _cost;
            protected set => _cost = value;
        }

        public AttackCostEffect(int cost)
        {
            _cost = cost;
        }

        public override void Apply(Unit unit)
        {
            unit.Attack.Penalty -= Cost;
        }
    }
}
