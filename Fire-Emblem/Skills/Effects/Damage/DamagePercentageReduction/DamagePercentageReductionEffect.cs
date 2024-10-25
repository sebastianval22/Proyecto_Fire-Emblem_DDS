namespace Fire_Emblem.Skills.Effects.Damage.DamagePercentageReduction;

public class DamagePercentageReductionEffect : Effect, IDamageEffect
{
    
    private readonly int _reductionPercentage;
    
    public DamagePercentageReductionEffect(int reductionPercentage)
    {

        _reductionPercentage = reductionPercentage;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageEffectStat.DamagePercentageReductionValue *= (1-_reductionPercentage/100.0);
    }
}