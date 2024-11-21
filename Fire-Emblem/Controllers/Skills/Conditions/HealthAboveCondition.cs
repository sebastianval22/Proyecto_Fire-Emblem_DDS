using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class HealthAboveCondition : Condition
{
    private readonly double _thresholdPercentage;

    public HealthAboveCondition(double thresholdPercentage)
    {
        _thresholdPercentage = thresholdPercentage;

    }

    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        return Math.Round((double)unit.BeforeRoundHP / unit.MaxHP, 2) >= (_thresholdPercentage / 100);
    }
}