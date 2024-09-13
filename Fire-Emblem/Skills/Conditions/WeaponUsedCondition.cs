namespace Fire_Emblem.Skills.Conditions;

public class WeaponUsedCondition : Condition
{

    private readonly string _weaponRequired;

    public WeaponUsedCondition(string weaponRequired)
    {
        _weaponRequired = weaponRequired;
    }

    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        return unit.Weapon == _weaponRequired;
    }
}