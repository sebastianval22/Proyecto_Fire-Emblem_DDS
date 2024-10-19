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
        var attackResistanceDifference = (unit.Attack.Value - (unit.Attack.FirstAttackPenalty + unit.Attack.FirstAttackBonus))  - (rival.Resistance.Value -(rival.Resistance.FirstAttackPenalty + rival.Resistance.FirstAttackBonus));

        int extraDamage = Convert.ToInt32(Math.Floor((attackResistanceDifference) *(_extraDamagePercentageValue/100.0))); 
        unit.ExtraDamageStat.FirstAttackValue += extraDamage;
        }
}