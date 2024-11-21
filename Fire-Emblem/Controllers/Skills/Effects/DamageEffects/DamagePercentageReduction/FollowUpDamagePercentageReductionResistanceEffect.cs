using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;

public class FollowUpDamagePercentageReductionResistanceEffect : Effect
{
    
    private readonly int _reductionPercentage;
    
    public FollowUpDamagePercentageReductionResistanceEffect(int reductionPercentage)
    {
        _reductionPercentage = reductionPercentage;
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
        var reduction = resistanceDifference * (_reductionPercentage / 1000.00);
        reduction = Math.Min(reduction, (_reductionPercentage / 100.00));
        unit.DamageEffectStat.DamagePercentageReductionFollowUpAttackValue *= (1 - reduction);
    }
}