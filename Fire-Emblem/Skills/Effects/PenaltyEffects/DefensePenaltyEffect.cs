namespace Fire_Emblem.Skills.Effects.PenaltyEffects
{
    public class DefensePenaltyEffect : Effect, IPenaltyEffect
    {
        
        private int _penalty;

        public int Penalty
        {
            get => _penalty;
            protected set => _penalty = value;
        }

        public DefensePenaltyEffect(int penalty)
        {
            _penalty = penalty;
        }

        public override void Apply(Unit rival)
        {
            rival.Defense.Penalty -= _penalty;
        }
    }
}