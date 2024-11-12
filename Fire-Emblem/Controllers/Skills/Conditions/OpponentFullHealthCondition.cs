using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class OpponentFullHealthCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        return rival.CurrentHP == rival.MaxHP;
    }
}