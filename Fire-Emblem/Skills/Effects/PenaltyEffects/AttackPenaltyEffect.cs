namespace Fire_Emblem.Skills.Effects.PenaltyEffects
{
    public class AttackPenaltyEffect : Effect, IPenaltyEffect
    {
        private int _penalty;

        public int Penalty
        {
            get => _penalty;
            protected set => _penalty = value;
        }

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