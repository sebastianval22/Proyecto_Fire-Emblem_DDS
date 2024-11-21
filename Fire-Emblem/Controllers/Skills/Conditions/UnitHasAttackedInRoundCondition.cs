using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class UnitHasAttackedInRoundCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        return unit.HasAttackedInRound;
    }
    
}