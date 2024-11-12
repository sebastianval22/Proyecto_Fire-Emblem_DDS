using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects
{
    public class SpeedPenaltyEffect : Effect, IPenaltyEffect
    {
        
        private int _penalty;

        public SpeedPenaltyEffect(int penalty)
        {
            _penalty = penalty;
        }

        public override void Apply(Unit rival)
        {
            rival.Speed.Penalty -= _penalty;
        }
    }
}