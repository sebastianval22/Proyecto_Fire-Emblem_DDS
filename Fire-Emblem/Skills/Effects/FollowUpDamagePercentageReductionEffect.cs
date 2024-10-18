namespace Fire_Emblem.Skills.Effects;

public class FollowUpDamagePercentageReductionEffect : Effect, IDamageEffect
{
    private int _reductionPercentage;
    public FollowUpDamagePercentageReductionEffect(int reductionPercentage)
    {
        _reductionPercentage = reductionPercentage;
    }

    public override void Apply(Unit unit)
    {
        unit.DamagePercentageReductionStat.FollowUpAttackValue *= (1 - _reductionPercentage / 100.0);
    }
}