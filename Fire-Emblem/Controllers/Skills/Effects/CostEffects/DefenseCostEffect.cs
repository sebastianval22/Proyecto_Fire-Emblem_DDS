using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.CostEffects
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