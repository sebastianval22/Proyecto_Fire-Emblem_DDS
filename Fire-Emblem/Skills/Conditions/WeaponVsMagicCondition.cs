using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class WeaponVsMagicCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        var isAttackingUnitMagic = roundFightController.AttackingUnit.Weapon == "Magic";
        var isDefendingUnitMagic = roundFightController.DefendingUnit.Weapon == "Magic";
        return (isAttackingUnitMagic && !isDefendingUnitMagic) || (!isAttackingUnitMagic && isDefendingUnitMagic);
    }
}