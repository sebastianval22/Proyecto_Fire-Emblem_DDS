using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class DefenseDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int unitDefense = unit.Defense.Value - (unit.Defense.FirstAttackPenalty + unit.Defense.FirstAttackBonus);
        int rivalDefense = rival.Defense.Value - (rival.Defense.FirstAttackPenalty + rival.Defense.FirstAttackBonus);
        var defenseDifference = unitDefense - rivalDefense;
        return defenseDifference >= 0;
    }
}