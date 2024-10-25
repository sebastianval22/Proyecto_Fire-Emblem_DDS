using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class OpponentFullHealthCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        return rival.CurrentHP == rival.MaxHP;
    }
}