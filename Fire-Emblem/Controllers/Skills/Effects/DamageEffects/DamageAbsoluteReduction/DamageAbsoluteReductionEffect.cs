using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamageAbsoluteReduction;

public class DamageAbsoluteReductionEffect : Effect, IDamageEffect
{
    
    private readonly int _reductionValue;
    
    public DamageAbsoluteReductionEffect(int reductionAmount)
    {
        _reductionValue = reductionAmount;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageEffectStat.DamageAbsoluteReductionValue += _reductionValue;
    }
}