using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;

public class FirstAttackDamagePercentageReductionEffect : Effect, IDamageEffect
{
    
    private readonly int _reductionPercentage;
    
    public FirstAttackDamagePercentageReductionEffect(int reductionPercentage)
    {
        _reductionPercentage = reductionPercentage;
    }
    
    public override void Apply(Unit unit)
    {
        double reductionFactor = (1 - (_reductionPercentage / 100.0) * unit.DamageEffectStat.DamagePercentageReductionReductionValue);
        unit.DamageEffectStat.DamagePercentageReductionFirstAttackValue *= reductionFactor;
    }

}