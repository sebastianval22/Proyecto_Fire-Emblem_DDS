using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects;

public class ExtraAndAbsoluteReductionDamageBasedOnResistanceEffect : Effect
{
    
    private int _extraDamagePercentage;
    
    public ExtraAndAbsoluteReductionDamageBasedOnResistanceEffect(int extraDamagePercentage)
    {
        _extraDamagePercentage = extraDamagePercentage;
    }

    public override void Apply(Unit rival)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int resistanceDifference = unit.Resistance.Value - rival.Resistance.Value;
        if (resistanceDifference < 0)
        {
            return;
        }
        int extraDamage = Convert.ToInt32(Math.Floor(resistanceDifference * (_extraDamagePercentage / 100.0)));
        extraDamage = int.Min(extraDamage, _extraDamagePercentage/10);
        unit.DamageEffectStat.ExtraDamageValue += extraDamage;
        unit.DamageEffectStat.DamageAbsoluteReductionValue += extraDamage;
    }
}