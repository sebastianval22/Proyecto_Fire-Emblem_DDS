using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;

public class SelfExtraDamageBeforeCombatStartEffect : Effect, ISelfDamageEffect
{
    
    private int _extraDamageValue;
    
    public SelfExtraDamageBeforeCombatStartEffect(int extraDamageValue)
    {
        _extraDamageValue = extraDamageValue;
    }
    
    public override void Apply(Unit unit)
    {
        unit.DamageEffectStat.ExtraDamageBeforeCombatValue += _extraDamageValue;
        unit.CurrentHP = Math.Max(unit.CurrentHP - _extraDamageValue, 1);
    }
}