using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage.ExtraDamage;
public class ExtraDamageBasedOnOpponentDefenseEffect : Effect
{
    private int _percentage;
    public ExtraDamageBasedOnOpponentDefenseEffect(int percentage)
    {
        _percentage = percentage;
    }
    public override void Apply(Unit unit)
    {

    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        var rivalRealDefense = rival.Defense.Value - (rival.Defense.FirstAttackPenalty + rival.Defense.FirstAttackBonus);
        var extraDamage = Convert.ToInt32(Math.Floor((rivalRealDefense * _percentage) / 100.0));
        unit.ExtraDamageStat.Value += extraDamage;
    }
}