using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class InitiatesCombatCondition : Condition
{
    
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        return unit == roundFightController.AttackingUnit;
    }
}