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
        int unitSpeed = unit.Speed.Value - (unit.Speed.FirstAttackPenalty + unit.Speed.FirstAttackBonus);
        int rivalSpeed = rival.Speed.Value - (rival.Speed.FirstAttackPenalty + rival.Speed.FirstAttackBonus);
        var speedDifference = unitSpeed - (rivalSpeed + _speedDifference);
        Console.WriteLine($"unit speed {unitSpeed} - rival speed {rivalSpeed} - speed difference {_speedDifference} = {speedDifference}");
        return speedDifference >= 0;
    }
}