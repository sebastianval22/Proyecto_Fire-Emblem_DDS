using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage.DamagePercentageReduction;
public class DamagePercentageReductionBasedOnOpponentHealthEffect : Effect
{
    private int _reductionPercentageValue;
    public DamagePercentageReductionBasedOnOpponentHealthEffect(int reductionPercentageValue)
    {
        _reductionPercentageValue = reductionPercentageValue;
    }
    public override void Apply(Unit unit)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        int reductionPercentage = Convert.ToInt32(Math.Floor((((double)rival.CurrentHP / rival.MaxHP)*100) * (_reductionPercentageValue / 100.0)));
        unit.DamagePercentageReductionStat.Value *= (1- reductionPercentage/100.0);        
    }
    
}