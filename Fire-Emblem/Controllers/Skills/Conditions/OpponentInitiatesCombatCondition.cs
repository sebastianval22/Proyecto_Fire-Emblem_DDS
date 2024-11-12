using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class OpponentInitiatesCombatCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        return rival == roundFightController.AttackingUnit;
    }
}