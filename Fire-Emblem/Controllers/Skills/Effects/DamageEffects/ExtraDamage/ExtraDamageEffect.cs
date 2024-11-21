using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;
public class ExtraDamageEffect : Effect, IDamageEffect
{
    
    private readonly int _extraDamage;
    
    public ExtraDamageEffect(int extraDamage)
    {
        _extraDamage = extraDamage;
    }
    
    public override void Apply(Unit unit)
    {
        unit.DamageEffectStat.ExtraDamageValue += _extraDamage;
    }
}