using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects;

public class FirstDefensePenaltyMinusHalfEffect : DefensePenaltyEffect
{
    
    private readonly int _basePenalty;
    
    public FirstDefensePenaltyMinusHalfEffect(int basePenalty) : base(basePenalty)
    {
        _basePenalty = basePenalty;
    }
    
    public override void Apply(Unit rival)
    {
        Penalty = Convert.ToInt32(Math.Floor(rival.Defense.Value / 2.0));
        rival.Defense.FirstAttackPenalty -= Penalty;
    }
}