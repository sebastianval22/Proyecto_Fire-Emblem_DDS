using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;

public class DamagePercentageReductionBasedOnFirstCombatsEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }
        
    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        
        if (unit.HasHadFirstCombatStarting == false && unit == roundFightController.AttackingUnit ) 
        {
            unit.DamageEffectStat.DamagePercentageReductionValue *=
                1- (0.6 * unit.DamageEffectStat.DamagePercentageReductionReductionValue);
        }
        else if  (unit.HasHadFirstCombatNotStarting == false && unit == roundFightController.DefendingUnit)
        {
            unit.DamageEffectStat.DamagePercentageReductionValue *=
                1- (0.6 * unit.DamageEffectStat.DamagePercentageReductionReductionValue);
        }
        else
        {
            unit.DamageEffectStat.DamagePercentageReductionValue *=
                1- (0.3 * unit.DamageEffectStat.DamagePercentageReductionReductionValue);
        }
    }
}