using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects;

public class ExtraAndAbsoluteReductionDamageBasedOnDefenseEffect : Effect
{
 
    private int _extraDamagePercentage;
    
    public ExtraAndAbsoluteReductionDamageBasedOnDefenseEffect(int extraDamagePercentage)
    {
        _extraDamagePercentage = extraDamagePercentage;
    }

    public override void Apply(Unit rival)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int defenseDifference = unit.Defense.Value - rival.Defense.Value;
        if (defenseDifference < 0)
        {
            return;
        }
        int extraDamage = Convert.ToInt32(Math.Floor(defenseDifference * (_extraDamagePercentage / 100.0)));
        extraDamage = int.Min(extraDamage, _extraDamagePercentage/10);
        unit.DamageEffectStat.ExtraDamageValue += extraDamage;
        unit.DamageEffectStat.DamageAbsoluteReductionValue += extraDamage;
    }
}