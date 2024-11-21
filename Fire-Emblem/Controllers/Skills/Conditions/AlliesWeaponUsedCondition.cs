using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class AlliesWeaponUsedCondition : Condition
{
    private string _weapon;
    
    public AlliesWeaponUsedCondition(string weapon)
    {
        _weapon = weapon;
    }
    
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        foreach (Unit ally in unit.UnitAllies)
        {
            if (ally.Weapon == _weapon) 
            {
                return true;
            }
        }
        return false;
    }
    
    

}