namespace Fire_Emblem.Skills.Effects;

public class DamageAbsoluteReductionEffect : Effect, IDamageEffect
{
    public int _reductionValue;
    public DamageAbsoluteReductionEffect(int reductionAmount)
    {
        _reductionValue = reductionAmount;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageAbsoluteReductionStat.Value += _reductionValue;
    }


}