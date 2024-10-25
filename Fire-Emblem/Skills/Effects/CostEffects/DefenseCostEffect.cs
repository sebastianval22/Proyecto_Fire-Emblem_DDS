namespace Fire_Emblem.Skills.Effects.CostEffects
{
    public class DefenseCostEffect : Effect, ICostEffect
    {
        
        private int _cost;

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