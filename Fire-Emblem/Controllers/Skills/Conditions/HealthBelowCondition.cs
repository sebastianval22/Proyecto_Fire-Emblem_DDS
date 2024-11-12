using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class HealthBelowCondition : Condition
{
    private readonly double _thresholdPercentage;

    public HealthBelowCondition(double thresholdPercentage)
    {
        _thresholdPercentage = thresholdPercentage;

    }

    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        var thresholdHP = unit.MaxHP * (_thresholdPercentage / 100);
        int truncatedThresholdHP = Convert.ToInt32(Math.Floor(thresholdHP));
        return unit.CurrentHP <= truncatedThresholdHP;
    }
}