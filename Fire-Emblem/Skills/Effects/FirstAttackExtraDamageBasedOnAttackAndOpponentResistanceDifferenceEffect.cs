namespace Fire_Emblem.Skills.Effects;

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

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        int extraDamage = Convert.ToInt32(Math.Floor((unit.Attack.Value - rival.Resistance.Value) *(_extraDamagePercentageValue/100.0))); 
        unit.ExtraDamageStat.FirstAttackValue += extraDamage;
        }
}