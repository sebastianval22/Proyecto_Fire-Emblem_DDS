namespace Fire_Emblem.Skills.Effects;

public class ResistancePenaltyMinusHalfEffect : ResistancePenaltyEffect
{
    private readonly int _basePenalty;
    public ResistancePenaltyMinusHalfEffect(int basePenalty) : base(basePenalty)
    {
        _basePenalty = basePenalty;
    }

    public override void Apply(Unit unit)
    {
        Penalty = Convert.ToInt32(Math.Floor(unit.Resistance / 2.0));
    }
}