using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;

public class FirstAttackDamagePercentageReductionResistanceEffect : Effect
{
    
    private int _reductionPercentageValue;
    
    public FirstAttackDamagePercentageReductionResistanceEffect(int reductionPercentageValue)
    {
        _reductionPercentageValue = reductionPercentageValue;
    }
    
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
        var reduction = resistanceDifference * (_reductionPercentageValue / 1000.00);
        reduction = Math.Min(reduction, (_reductionPercentageValue / 100.00));
        unit.DamageEffectStat.DamagePercentageReductionFirstAttackValue *=
            (1 - (reduction)*unit.DamageEffectStat.DamagePercentageReductionReductionValue);
    }
}