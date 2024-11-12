using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects;

public class FirstResistancePenaltyMinusHalfEffect : ResistancePenaltyEffect
{
    
    private readonly int _basePenalty;
    
    public FirstResistancePenaltyMinusHalfEffect(int basePenalty) : base(basePenalty)
    {
        _basePenalty = basePenalty;
    }

    public override void Apply(Unit rival)
    {
        Penalty = Convert.ToInt32(Math.Floor(rival.Resistance.Value / 2.0));
        rival.Resistance.FirstAttackPenalty -= Penalty;
    }
}