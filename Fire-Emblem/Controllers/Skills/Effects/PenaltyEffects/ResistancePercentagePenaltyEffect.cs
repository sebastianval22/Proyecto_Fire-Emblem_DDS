using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects;

public class ResistancePercentagePenaltyEffect : Effect
{
    public int _resistancePercentagePenalty { get; }
    
    public ResistancePercentagePenaltyEffect(int resistancePercentagePenalty)
    {
        _resistancePercentagePenalty = resistancePercentagePenalty;
    }

    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);        
        int resistancePenalty = Convert.ToInt32(Math.Floor(rival.Resistance.Value * (_resistancePercentagePenalty/100.0)));
        rival.Resistance.Penalty -= resistancePenalty;
    }
}