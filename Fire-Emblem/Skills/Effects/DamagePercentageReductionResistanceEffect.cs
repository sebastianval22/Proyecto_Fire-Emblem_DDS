namespace Fire_Emblem.Skills.Effects;

public class DamagePercentageReductionResistanceEffect :  Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        var resistanceDifference = unit.Resistance.Value - rival.Resistance.Value;
        var reduction = resistanceDifference * 0.04;
        reduction = Math.Min(reduction, 0.4);
        unit.DamagePercentageReductionStat.Value *= (1 - reduction);
    }
}

