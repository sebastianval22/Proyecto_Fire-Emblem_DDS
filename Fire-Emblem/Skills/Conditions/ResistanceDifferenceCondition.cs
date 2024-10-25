using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class ResistanceDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        int unitResistance = unit.Resistance.Value -
                             (unit.Resistance.FirstAttackPenalty + unit.Resistance.FirstAttackBonus);
        int rivalResistance = rival.Resistance.Value -
                              (rival.Resistance.FirstAttackPenalty + rival.Resistance.FirstAttackBonus);
        var resistanceDifference = unitResistance - rivalResistance;
        return resistanceDifference > 0;
    }
}