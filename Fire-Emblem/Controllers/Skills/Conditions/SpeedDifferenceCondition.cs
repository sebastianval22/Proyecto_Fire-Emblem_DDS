using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class SpeedDifferenceCondition : Condition
{
    private readonly int _speedDifference;
    public SpeedDifferenceCondition(int speedDifference)
    {
        _speedDifference = speedDifference;
    }
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int unitSpeed = unit.Speed.Value;
        int rivalSpeed = rival.Speed.Value;
        var speedDifference = unitSpeed - (rivalSpeed + _speedDifference);
        return speedDifference >= 0;
    }
}