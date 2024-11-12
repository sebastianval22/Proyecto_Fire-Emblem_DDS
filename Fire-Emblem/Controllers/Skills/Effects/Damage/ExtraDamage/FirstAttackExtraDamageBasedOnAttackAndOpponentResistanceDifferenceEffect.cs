using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.Damage.ExtraDamage;
public class FirstAttackExtraDamageBasedOnAttackAndOpponentResistanceDifferenceEffect :  Effect
{
    
    private readonly int _extraDamagePercentageValue;
    
    public FirstAttackExtraDamageBasedOnAttackAndOpponentResistanceDifferenceEffect(int extraDamagePercentageValue)
    {
        _extraDamagePercentageValue = extraDamagePercentageValue;
    }
    
    public override void Apply(Unit unit)
    {
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int unitAttack = unit.Attack.Value - (unit.Attack.FirstAttackPenalty + unit.Attack.FirstAttackBonus);
        int rivalResistance = rival.Resistance.Value - (rival.Resistance.FirstAttackPenalty + rival.Resistance.FirstAttackBonus);
        var attackResistanceDifference = unitAttack - rivalResistance;
        int extraDamage = Convert.ToInt32(Math.Floor((attackResistanceDifference) *(_extraDamagePercentageValue/100.0))); 
        unit.DamageEffectStat.ExtraDamageFirstAttackValue += extraDamage;
        }
}