namespace Fire_Emblem.Skills.Conditions;

public class WeaponVsMagicCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        var isAttackingUnitMagic = roundFight.AttackingUnit.Weapon == "Magic";
        var isDefendingUnitMagic = roundFight.DefendingUnit.Weapon == "Magic";

        return (isAttackingUnitMagic && !isDefendingUnitMagic) || (!isAttackingUnitMagic && isDefendingUnitMagic);
    }
}