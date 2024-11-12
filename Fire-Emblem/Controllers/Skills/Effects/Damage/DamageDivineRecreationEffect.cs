using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.Damage;

public class DamageDivineRecreationEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        DamageController damageController = new DamageController();
        damageController.InitializeCombatants(rival, unit);
        int normalDamage = damageController.CalculateDamageFirstAttackWithoutReduction(rival, unit);
        unit.DamageEffectStat.DamagePercentageReductionFirstAttackValue *= 0.7;
        int extraDamage = normalDamage - damageController.CalculateDamageFirstAttack(rival, unit);

        if (unit == roundFightController.AttackingUnit)
        {
            unit.DamageEffectStat.ExtraDamageFollowUpAttackValue += extraDamage;
        }
        else
        {
            unit.DamageEffectStat.ExtraDamageFirstAttackValue += extraDamage;
        }
    }
    
}