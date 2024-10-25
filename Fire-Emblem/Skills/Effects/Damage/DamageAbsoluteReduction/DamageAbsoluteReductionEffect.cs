namespace Fire_Emblem.Skills.Effects.Damage.DamageAbsoluteReduction;

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