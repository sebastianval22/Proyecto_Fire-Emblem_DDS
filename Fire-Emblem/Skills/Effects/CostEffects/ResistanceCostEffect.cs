namespace Fire_Emblem.Skills.Effects.CostEffects
{
    public class ResistanceCostEffect : Effect, ICostEffect
    {
        
        private int _cost;
        
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