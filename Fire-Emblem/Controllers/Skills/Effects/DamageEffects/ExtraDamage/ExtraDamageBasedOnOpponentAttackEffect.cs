using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;

public class ExtraDamageBasedOnOpponentAttackEffect : Effect
{
    
    private readonly int _reductionPercentageValue;
    
    public ExtraDamageBasedOnOpponentAttackEffect(int reductionPercentageValue)
    {
        _reductionPercentageValue = reductionPercentageValue;
    }
    
    public override void Apply(Unit unit)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        var rivalRealAttack = rival.Attack.Value - (rival.Attack.FirstAttackPenalty + rival.Attack.FirstAttackBonus);
        int extraDamage = Convert.ToInt32(Math.Floor((rivalRealAttack) * (_reductionPercentageValue / 100.0)));
        unit.DamageEffectStat.ExtraDamageValue += extraDamage;
    }
}