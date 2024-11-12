using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class SpeedDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        int unitSpeed = unit.Speed.Value - (unit.Speed.FirstAttackPenalty + unit.Speed.FirstAttackBonus);
        int rivalSpeed = rival.Speed.Value - (rival.Speed.FirstAttackPenalty + rival.Speed.FirstAttackBonus);
        var speedDifference = unitSpeed - rivalSpeed;
        return speedDifference > 0;
    }
}