using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage.DamagePercentageReduction;
public class DamagePercentageReductionSpeedEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        var speedDifference = (unit.Speed.Value - (unit.Speed.FirstAttackPenalty + unit.Speed.FirstAttackBonus))  - (rival.Speed.Value -(rival.Speed.FirstAttackPenalty + rival.Speed.FirstAttackBonus));
        var reduction = speedDifference * 0.04;
        reduction = Math.Min(reduction, 0.4);
        unit.DamagePercentageReductionStat.Value *= (1 - reduction);
    }
}