namespace Fire_Emblem.Skills.Effects;

public class ExtraDamageEffect : Effect, IDamageEffect
{
    private int _extraDamage;
    public ExtraDamageEffect(int extraDamage)
    {
        _extraDamage = extraDamage;
    }
    public override void Apply(Unit unit)
    {
        unit.ExtraDamageStat.Value += _extraDamage;
    }
}