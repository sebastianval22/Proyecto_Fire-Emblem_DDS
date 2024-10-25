using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class OpponentHealthAboveCondition : Condition
{
    private readonly double _thresholdPercentage;

    public OpponentHealthAboveCondition(double thresholdPercentage)
    {
        _thresholdPercentage = thresholdPercentage;

    }
    
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        return Math.Round((double)rival.CurrentHP / rival.MaxHP, 2) >= (_thresholdPercentage / 100);
    }
}