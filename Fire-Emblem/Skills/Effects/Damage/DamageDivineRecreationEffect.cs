using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage;

public class DamageDivineRecreationEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        if (unit == roundFightController.AttackingUnit)
        {
            
            DamageController damageController = new DamageController();
            
            int normalDamage = damageController.CalculateDamageFirstAttackWithoutReduction(rival, unit);
            unit.DamageEffectStat.DamagePercentageReductionFirstAttackValue *= 0.7;
            int extraDamage = normalDamage - damageController.CalculateDamageFirstAttack(rival, unit);
            unit.DamageEffectStat.ExtraDamageFollowUpAttackValue += extraDamage;
            
        }
        else
        {
            DamageController damageController = new DamageController();
            
            int normalDamage = damageController.CalculateDamageFirstAttackWithoutReduction(rival, unit);
            unit.DamageEffectStat.DamagePercentageReductionFirstAttackValue *= 0.7;
            
            int extraDamage = normalDamage - damageController.CalculateDamageFirstAttack(rival, unit);
            unit.DamageEffectStat.ExtraDamageFirstAttackValue += extraDamage;
        }
        
    }
}