using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects
{
    public class AttackPenaltyEffect : Effect, IPenaltyEffect
    {
        
        private readonly int _penalty;

        public AttackPenaltyEffect(int penalty)
        {
            _penalty = penalty;
        }

        public override void Apply(Unit unit)
        {
            unit.Attack.Penalty -= _penalty;
        }
    }
}