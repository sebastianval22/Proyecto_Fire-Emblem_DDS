using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage.ExtraDamage;
public class FirstAttackExtraDamageBasedOnAttackAndOpponentResistanceDifferenceEffect :  Effect
{
    int _extraDamagePercentageValue;
    public FirstAttackExtraDamageBasedOnAttackAndOpponentResistanceDifferenceEffect(int extraDamagePercentageValue)
    {
        _extraDamagePercentageValue = extraDamagePercentageValue;
    }
    public override void Apply(Unit unit)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        int extraDamage = Convert.ToInt32(Math.Floor((unit.Attack.Value - rival.Resistance.Value) *(_extraDamagePercentageValue/100.0))); 
        unit.ExtraDamageStat.FirstAttackValue += extraDamage;
        }
}