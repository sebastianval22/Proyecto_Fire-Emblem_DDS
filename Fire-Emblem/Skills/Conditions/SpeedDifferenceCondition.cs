using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class SpeedDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        var speedDifference = (unit.Speed.Value - (unit.Speed.FirstAttackPenalty + unit.Speed.FirstAttackBonus))  - (rival.Speed.Value -(rival.Speed.FirstAttackPenalty + rival.Speed.FirstAttackBonus));

        return speedDifference > 0;
    }
}