namespace Fire_Emblem.Skills.Effects;

public class FirstResistancePenaltyMinusHalfEffect : ResistancePenaltyEffect
{
    private readonly int _basePenalty;
    public FirstResistancePenaltyMinusHalfEffect(int basePenalty) : base(basePenalty)
    {
        _basePenalty = basePenalty;
    }

    public override void Apply(Unit rival)
    {
        Penalty = Convert.ToInt32(Math.Floor(rival.Resistance / 2.0));
        rival.ActiveSkillsEffects["FirstAttackResistancePenalty"] -= Penalty;
    }
}