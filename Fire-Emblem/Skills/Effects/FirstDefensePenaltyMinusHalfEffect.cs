namespace Fire_Emblem.Skills.Effects;

public class FirstDefensePenaltyMinusHalfEffect : DefensePenaltyEffect
{
    private readonly int _basePenalty;
    public FirstDefensePenaltyMinusHalfEffect(int basePenalty) : base(basePenalty)
    {
        _basePenalty = basePenalty;
    }
    public override void Apply(Unit rival)
    {
        Penalty = Convert.ToInt32(Math.Floor(rival.Defence / 2.0));
        rival.ActiveSkillsEffects["FirstAttackDefensePenalty"] -= Penalty;
    }
}