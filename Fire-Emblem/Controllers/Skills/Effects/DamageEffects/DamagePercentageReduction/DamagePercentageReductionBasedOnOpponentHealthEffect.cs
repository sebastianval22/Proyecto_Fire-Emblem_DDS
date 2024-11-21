using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;
public class DamagePercentageReductionBasedOnOpponentHealthEffect : Effect
{
    
    private readonly int _reductionPercentageValue;
    
    public DamagePercentageReductionBasedOnOpponentHealthEffect(int reductionPercentageValue)
    {
        _reductionPercentageValue = reductionPercentageValue;
    }
    
    public override void Apply(Unit unit)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        double rivalHealthPercentage = (double)rival.CurrentHP / rival.MaxHP * 100;
        double reductionFactor = _reductionPercentageValue / 100.0;
        int reductionPercentage = Convert.ToInt32(Math.Floor(rivalHealthPercentage * reductionFactor));
        unit.DamageEffectStat.DamagePercentageReductionValue *= (1- reductionPercentage/100.0);
    }
}