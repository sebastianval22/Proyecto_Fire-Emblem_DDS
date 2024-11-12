using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.Damage.DamagePercentageReduction;

public class DamagePercentageReductionResistanceEffect :  Effect
{
    
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int unitResistance = unit.Resistance.Value -
                             (unit.Resistance.FirstAttackPenalty + unit.Resistance.FirstAttackBonus);
        int rivalResistance = rival.Resistance.Value -
                              (rival.Resistance.FirstAttackPenalty + rival.Resistance.FirstAttackBonus);
        var resistanceDifference = unitResistance - rivalResistance;
        var reduction = resistanceDifference * 0.04;
        reduction = Math.Min(reduction, 0.4);
        unit.DamageEffectStat.DamagePercentageReductionValue *= (1 - reduction);
    }
}

