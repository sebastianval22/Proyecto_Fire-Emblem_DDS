using Fire_Emblem.Models;
using Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects;

public class DamagePercentageReductionReductionEffect : Effect, IPenaltyEffect
{
    
    private int _damagePercentageReduction;

    public DamagePercentageReductionReductionEffect(int damagePercentageReduction)
    {
        _damagePercentageReduction = damagePercentageReduction;
    }

    public override void Apply(Unit unit)
    {
        double reductionFactor = (_damagePercentageReduction / 100.0);
        unit.DamageEffectStat.DamagePercentageReductionReductionValue *= reductionFactor;
    }
}