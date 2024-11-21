using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;

public class FollowUpDamagePercentageReductionEffect : Effect, IDamageEffect
{
    
    private readonly int _reductionPercentage;
    
    public FollowUpDamagePercentageReductionEffect(int reductionPercentage)
    {
        _reductionPercentage = reductionPercentage;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageEffectStat.DamagePercentageReductionFollowUpAttackValue *= (1 - _reductionPercentage / 100.0);
    }
}