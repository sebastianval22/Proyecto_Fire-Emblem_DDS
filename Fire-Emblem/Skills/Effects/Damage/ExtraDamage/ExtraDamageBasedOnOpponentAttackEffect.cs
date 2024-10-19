using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage.ExtraDamage;

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

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        int extraDamage = Convert.ToInt32(Math.Floor((rival.Attack.Value) * 0.15));
        unit.ExtraDamageStat.Value += extraDamage;
        
    }
}