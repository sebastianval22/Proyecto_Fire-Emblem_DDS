namespace Fire_Emblem.Skills.Effects.Damage.DamagePercentageReduction;

public class FirstAttackDamagePercentageReductionEffect : Effect, IDamageEffect
{
    private int _reductionPercentage;
    public FirstAttackDamagePercentageReductionEffect(int reductionPercentage)
    {
        _reductionPercentage = reductionPercentage;
    }
    public override void Apply(Unit unit)
    {
        unit.DamageEffectStat.DamagePercentageReductionFirstAttackValue *= (1 - _reductionPercentage / 100.0);
    }
    
}