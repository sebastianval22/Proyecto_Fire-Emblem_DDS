namespace Fire_Emblem.Skills.Effects;

public class DamagePercentageReductionSpeedEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        var speedDifference = unit.Speed.Value - rival.Speed.Value;
        var reduction = speedDifference * 0.04;
        reduction = Math.Min(reduction, 0.4);
        unit.DamagePercentageReductionStat.Value *= (1 - reduction);
    }
}