using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class RecentOpponentCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        if (unit == roundFightController.AttackingUnit)
        {
            return unit.RecentOpponent == roundFightController.DefendingUnit;
        }
        else
        {
            return unit.RecentOpponent == roundFightController.AttackingUnit;
        }
    }
}