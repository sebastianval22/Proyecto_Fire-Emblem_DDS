namespace Fire_Emblem.Skills.Effects;

public class DefensePenaltyMinusHalfEffect : DefensePenaltyEffect
{
    private readonly int _basePenalty;
    public DefensePenaltyMinusHalfEffect(int basePenalty) : base(basePenalty)
    {
        _basePenalty = basePenalty;
    }
    public override void Apply(Unit unit)
    {
        Penalty = Convert.ToInt32(Math.Floor(unit.Defence / 2.0));
    }
}