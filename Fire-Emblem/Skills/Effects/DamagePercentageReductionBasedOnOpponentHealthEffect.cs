namespace Fire_Emblem.Skills.Effects;

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

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        int reductionPercentage = Convert.ToInt32(Math.Floor((((double)rival.CurrentHP / rival.MaxHP)*100) * (_reductionPercentageValue / 100.0)));
        unit.DamagePercentageReductionStat.Value *= (1- reductionPercentage/100.0);        
    }
    
}