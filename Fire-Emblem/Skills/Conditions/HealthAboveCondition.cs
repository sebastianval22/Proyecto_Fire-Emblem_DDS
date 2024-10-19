using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class HealthAboveCondition : Condition
{
    private readonly double _thresholdPercentage;

    public HealthAboveCondition(double thresholdPercentage)
    {
        _thresholdPercentage = thresholdPercentage;

    }

    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        return Math.Round((double)unit.CurrentHP / unit.MaxHP, 2) >= (_thresholdPercentage / 100);
    }
}