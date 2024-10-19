using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage.DamagePercentageReduction;

public class DamagePercentageReductionResistanceEffect :  Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        var resistanceDifference = (unit.Resistance.Value - (unit.Resistance.FirstAttackPenalty + unit.Resistance.FirstAttackBonus))  - (rival.Resistance.Value -(rival.Resistance.FirstAttackPenalty + rival.Resistance.FirstAttackBonus));
        var reduction = resistanceDifference * 0.04;
        reduction = Math.Min(reduction, 0.4);
        unit.DamagePercentageReductionStat.Value *= (1 - reduction);
    }
}

