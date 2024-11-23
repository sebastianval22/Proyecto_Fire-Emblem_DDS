using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class SpeedAndDefenseDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int unitSpeedAndDefense = unit.Speed.Value + unit.Defense.Value;
        int rivalSpeedAndDefense = rival.Speed.Value + rival.Defense.Value;
        var speedDefenseDifference = unitSpeedAndDefense - rivalSpeedAndDefense;
        return speedDefenseDifference > 0;
    }
}