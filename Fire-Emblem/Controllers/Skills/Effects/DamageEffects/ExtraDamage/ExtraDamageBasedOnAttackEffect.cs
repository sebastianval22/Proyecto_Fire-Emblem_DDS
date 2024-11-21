using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;

public class ExtraDamageBasedOnAttackEffect : Effect, IDamageEffect
{
    
    private readonly int _extraDamagePercentage;
    
    public ExtraDamageBasedOnAttackEffect(int extraDamagePercentage)
    {
        _extraDamagePercentage = extraDamagePercentage;
    }

    public override void Apply(Unit unit)
    {
        int extraDamage = Convert.ToInt32(Math.Floor((unit.Attack.Value * _extraDamagePercentage / 100.0)));
        unit.DamageEffectStat.ExtraDamageValue += extraDamage;
    }
    
}