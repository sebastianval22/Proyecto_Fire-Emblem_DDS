using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage.DamagePercentageReduction;
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
        unit.DamageEffectStat.DamagePercentageReductionValue *= (1 - reduction);
    }
}