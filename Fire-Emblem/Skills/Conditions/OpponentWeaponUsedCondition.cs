namespace Fire_Emblem.Skills.Conditions;

public class OpponentWeaponUsedCondition : Condition
{
    private readonly string _opponentWeaponRequired;
    
    public OpponentWeaponUsedCondition(string opponentWeaponRequired)
    {
        _opponentWeaponRequired = opponentWeaponRequired;
    }
    
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        return rival.Weapon == _opponentWeaponRequired;
    }
}