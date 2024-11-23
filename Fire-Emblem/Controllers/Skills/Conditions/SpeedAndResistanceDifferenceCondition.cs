using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class SpeedAndResistanceDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int unitSpeedAndResistance = unit.Speed.Value + unit.Resistance.Value;
        int rivalSpeedAndResistance = rival.Speed.Value + rival.Resistance.Value;
        var speedResistanceDifference = unitSpeedAndResistance - rivalSpeedAndResistance;
        return speedResistanceDifference > 0;
    }
}