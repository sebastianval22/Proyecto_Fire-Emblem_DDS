using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class AttackAndOpponentResistanceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        int unitAttack = unit.Attack.Value - (unit.Attack.FirstAttackPenalty + unit.Attack.FirstAttackBonus);
        int rivalResistance = rival.Resistance.Value -
                              (rival.Resistance.FirstAttackPenalty + rival.Resistance.FirstAttackBonus);
        var attackResistanceDifference = unitAttack - rivalResistance;
        return attackResistanceDifference > 0;
    }
}