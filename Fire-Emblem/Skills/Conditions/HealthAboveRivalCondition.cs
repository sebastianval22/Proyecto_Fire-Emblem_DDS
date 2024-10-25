using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class HealthAboveRivalCondition : Condition
{
    private readonly int _thresholdAbove;
    public HealthAboveRivalCondition(int thresholdAbove)
    {
        _thresholdAbove = thresholdAbove;
    }
    
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        return unit.CurrentHP >= rival.CurrentHP + _thresholdAbove;
    }
}