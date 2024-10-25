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
        Unit rival = GetRival(unit, roundFightController); 
        return rival.Weapon == _opponentWeaponRequired;
    }
}