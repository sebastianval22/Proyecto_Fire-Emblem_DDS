using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class AttackAndOpponentResistanceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        var attackResistanceDifference = (unit.Attack.Value - (unit.Attack.FirstAttackPenalty + unit.Attack.FirstAttackBonus))  - (rival.Resistance.Value -(rival.Resistance.FirstAttackPenalty + rival.Resistance.FirstAttackBonus));

        return attackResistanceDifference > 0;
    }
}