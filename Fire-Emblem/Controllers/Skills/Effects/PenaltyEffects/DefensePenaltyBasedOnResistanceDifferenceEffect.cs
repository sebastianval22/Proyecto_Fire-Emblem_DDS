using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects;

public class DefensePenaltyBasedOnResistanceDifferenceEffect : Effect
{

    private int _defensePenaltyPercentage;
    
    public DefensePenaltyBasedOnResistanceDifferenceEffect(int defensePenaltyPercentage)
    {
        _defensePenaltyPercentage = defensePenaltyPercentage;
    }
    
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int resistanceDifference = unit.Resistance.Value - rival.Resistance.Value;
        if (resistanceDifference < 0)
        {
            return;
        }
        int defensePenalty = Convert.ToInt32(Math.Floor(resistanceDifference * (_defensePenaltyPercentage / 100.0)));
        defensePenalty = int.Min(defensePenalty, _defensePenaltyPercentage/10);
        rival.Defense.Penalty -= defensePenalty;
    }
    
}