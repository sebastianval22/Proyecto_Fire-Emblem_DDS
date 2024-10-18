namespace Fire_Emblem.Skills.Effects;

public class DamagePercentageReductionBasedOnFirstCombatsEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }
        
    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        
        if (unit.HasHadFirstCombatStarting == false && unit == roundFight.AttackingUnit ) 
        {
            unit.DamagePercentageReductionStat.Value *= 0.4;
        }
        else if  (unit.HasHadFirstCombatNotStarting == false && unit == roundFight.DefendingUnit)
        {
            unit.DamagePercentageReductionStat.Value = 0.4;
        }
        else
        {
            unit.DamagePercentageReductionStat.Value *= 0.7;
        }
    }

        
}