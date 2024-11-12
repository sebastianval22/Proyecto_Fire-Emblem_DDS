using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class InitiatesCombatCondition : Condition
{
    
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        return unit == roundFightController.AttackingUnit;
    }
}