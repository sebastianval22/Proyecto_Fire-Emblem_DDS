using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.Damage.ExtraDamage;
public class ExtraDamageBasedOnOpponentDefenseEffect : Effect
{
    
    private readonly int _percentage;
    
    public ExtraDamageBasedOnOpponentDefenseEffect(int percentage)
    {
        _percentage = percentage;
    }
    
    public override void Apply(Unit unit)
    {

    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        var rivalRealDefense = rival.Defense.Value - (rival.Defense.FirstAttackPenalty + rival.Defense.FirstAttackBonus);
        var extraDamage = Convert.ToInt32(Math.Floor((rivalRealDefense * _percentage) / 100.0));
        unit.DamageEffectStat.ExtraDamageValue += extraDamage;
    }
}