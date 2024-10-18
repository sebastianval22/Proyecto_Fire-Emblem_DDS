namespace Fire_Emblem.Skills.Effects;

public class ExtraDamageBasedOnOpponentAttackEffect : Effect
{
    private int _reductionPercentageValue;
    public ExtraDamageBasedOnOpponentAttackEffect(int reductionPercentageValue)
    {
        _reductionPercentageValue = reductionPercentageValue;
    }
    public override void Apply(Unit unit)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        int extraDamage = Convert.ToInt32(Math.Floor((rival.Attack.Value) * 0.15));
        unit.ExtraDamageStat.Value += extraDamage;
        
    }
}