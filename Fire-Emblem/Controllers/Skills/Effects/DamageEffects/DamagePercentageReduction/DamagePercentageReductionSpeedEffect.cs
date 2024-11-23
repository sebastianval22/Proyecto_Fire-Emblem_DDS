using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;
public class DamagePercentageReductionSpeedEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int unitSpeed = unit.Speed.Value - (unit.Speed.FirstAttackPenalty + unit.Speed.FirstAttackBonus);
        int rivalSpeed = rival.Speed.Value - (rival.Speed.FirstAttackPenalty + rival.Speed.FirstAttackBonus);
        var speedDifference = unitSpeed - rivalSpeed;
        var reduction = speedDifference * 0.04;
        reduction = Math.Min(reduction, 0.4);
        unit.DamageEffectStat.DamagePercentageReductionValue *=
            (1 - (reduction)*unit.DamageEffectStat.DamagePercentageReductionReductionValue);
    }
}