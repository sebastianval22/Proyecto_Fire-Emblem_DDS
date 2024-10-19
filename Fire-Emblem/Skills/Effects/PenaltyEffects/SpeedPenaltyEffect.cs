namespace Fire_Emblem.Skills.Effects.PenaltyEffects
{
    public class SpeedPenaltyEffect : Effect, IPenaltyEffect
    {
        private int _penalty;

        public int Penalty
        {
            get => _penalty;
            protected set => _penalty = value;
        }

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