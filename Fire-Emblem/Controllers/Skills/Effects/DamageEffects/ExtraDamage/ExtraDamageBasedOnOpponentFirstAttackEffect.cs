using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;

public class ExtraDamageBasedOnOpponentFirstAttackEffect : Effect
{
    
    private readonly int _reductionPercentageValue;
    
    public ExtraDamageBasedOnOpponentFirstAttackEffect(int reductionPercentageValue)
    {
        _reductionPercentageValue = reductionPercentageValue;
    }
    
    public override void Apply(Unit unit)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        DamageController damageController = new DamageController();
        damageController.InitializeCombatants(rival, unit);
        int normalDamage = damageController.CalculateDamageFirstAttackWithoutReduction(rival, unit);
        int extraDamage = Convert.ToInt32(Math.Floor(normalDamage * (_reductionPercentageValue / 100.0)));
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