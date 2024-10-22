namespace Fire_Emblem.Skills.Effects.Damage.ExtraDamage;
public class ExtraDamageEffect : Effect, IDamageEffect
{
    private int _extraDamage;
    public ExtraDamageEffect(int extraDamage)
    {
        _extraDamage = extraDamage;
    }
    public override void Apply(Unit unit)
    {
        unit.DamageEffectStat.ExtraDamageValue += _extraDamage;
    }
}