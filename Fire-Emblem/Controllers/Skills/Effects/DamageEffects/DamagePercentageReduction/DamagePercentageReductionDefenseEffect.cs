using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;

public class DamagePercentageReductionDefenseEffect : Effect
{
    
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int unitDefense = unit.Defense.Value -
                             (unit.Defense.FirstAttackPenalty + unit.Defense.FirstAttackBonus);
        int rivalDefense = rival.Defense.Value -
                              (rival.Defense.FirstAttackPenalty + rival.Defense.FirstAttackBonus);
        var defenseDifference = unitDefense - rivalDefense;
        var reduction = defenseDifference * 0.04;
        reduction = Math.Min(reduction, 0.4);
        unit.DamageEffectStat.DamagePercentageReductionValue *=
            (1 - (reduction)*unit.DamageEffectStat.DamagePercentageReductionReductionValue);
    }
    
}