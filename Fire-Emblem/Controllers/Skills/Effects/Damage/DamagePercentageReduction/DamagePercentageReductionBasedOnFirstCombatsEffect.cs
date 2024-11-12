using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.Damage.DamagePercentageReduction;

public class DamagePercentageReductionBasedOnFirstCombatsEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }
        
    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        
        if (unit.HasHadFirstCombatStarting == false && unit == roundFightController.AttackingUnit ) 
        {
            unit.DamageEffectStat.DamagePercentageReductionValue *= 0.4;
        }
        else if  (unit.HasHadFirstCombatNotStarting == false && unit == roundFightController.DefendingUnit)
        {
            unit.DamageEffectStat.DamagePercentageReductionValue *= 0.4;
        }
        else
        {
            unit.DamageEffectStat.DamagePercentageReductionValue *= 0.7;
        }
    }
}