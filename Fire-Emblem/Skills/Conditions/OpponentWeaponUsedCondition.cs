using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class OpponentWeaponUsedCondition : Condition
{
    private readonly string _opponentWeaponRequired;
    
    public OpponentWeaponUsedCondition(string opponentWeaponRequired)
    {
        _opponentWeaponRequired = opponentWeaponRequired;
    }
    
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        return rival.Weapon == _opponentWeaponRequired;
    }
}