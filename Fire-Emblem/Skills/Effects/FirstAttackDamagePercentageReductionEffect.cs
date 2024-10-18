namespace Fire_Emblem.Skills.Effects;

public class FirstAttackDamagePercentageReductionEffect : Effect, IDamageEffect
{
    private int _reductionPercentage;
    public FirstAttackDamagePercentageReductionEffect(int reductionPercentage)
    {
        _reductionPercentage = reductionPercentage;
    }
    public override void Apply(Unit unit)
    {
        unit.DamagePercentageReductionStat.FirstAttackValue *= (1 - _reductionPercentage / 100.0);
    }
    
}