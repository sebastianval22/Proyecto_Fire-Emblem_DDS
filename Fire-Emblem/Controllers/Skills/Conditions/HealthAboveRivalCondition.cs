using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

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