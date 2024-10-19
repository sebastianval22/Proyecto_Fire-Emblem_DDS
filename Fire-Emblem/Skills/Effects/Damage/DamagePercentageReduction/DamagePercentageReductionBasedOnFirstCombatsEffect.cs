using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage.DamagePercentageReduction;

public class DamagePercentageReductionBasedOnFirstCombatsEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }
        
    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        
        if (unit.HasHadFirstCombatStarting == false && unit == roundFightController.AttackingUnit ) 
        {
            unit.DamagePercentageReductionStat.Value *= 0.4;
        }
        else if  (unit.HasHadFirstCombatNotStarting == false && unit == roundFightController.DefendingUnit)
        {
            unit.DamagePercentageReductionStat.Value = 0.4;
        }
        else
        {
            unit.DamagePercentageReductionStat.Value *= 0.7;
        }
    }

        
}