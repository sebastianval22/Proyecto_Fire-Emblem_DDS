using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;

public class SelfExtraDamageAfterCombatEffect : Effect, ISelfDamageEffect
{
    
    private int _extraDamageValue;
    
    public SelfExtraDamageAfterCombatEffect(int extraDamageValue)
    {
        _extraDamageValue = extraDamageValue;
    }

    public override void Apply(Unit unit)
    {
        unit.HpEffectStat.ExtraHpAfterCombatValue -= _extraDamageValue;
    }
}