namespace Fire_Emblem.Skills.Effects
{
    public class ResistancePenaltyEffect : Effect, IPenaltyEffect
    {
        private int _penalty;

        public int Penalty
        {
            get => _penalty;
            protected set => _penalty = value;
        }

        public ResistancePenaltyEffect(int penalty)
        {
            _penalty = penalty;
        }

        public override void Apply(Unit rival)
        {
            rival.Resistance.Penalty -= _penalty;
        }
    }
}