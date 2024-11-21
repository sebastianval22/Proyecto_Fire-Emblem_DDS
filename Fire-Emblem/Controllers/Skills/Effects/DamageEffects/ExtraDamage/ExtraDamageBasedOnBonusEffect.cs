using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;

public class ExtraDamageBasedOnBonusEffect : Effect, IDamageEffect
{
    
    private int _extraDamagePercentageValue;
    
    public ExtraDamageBasedOnBonusEffect(int extraDamagePercentageValue)
    {
        _extraDamagePercentageValue = extraDamagePercentageValue;
    }
    
    public override void Apply(Unit unit)
    {
        int totalBonus = 0;

        if (!unit.Attack.BonusNeutralized)
        {
            totalBonus += unit.Attack.Bonus;
        }

        if (!unit.Defense.BonusNeutralized)
        {
            totalBonus += unit.Defense.Bonus;
        }

        if (!unit.Speed.BonusNeutralized)
        {
            totalBonus += unit.Speed.Bonus;
        }

        if (!unit.Resistance.BonusNeutralized)
        {
            totalBonus += unit.Resistance.Bonus;
        }
        int extraDamage = Convert.ToInt32(Math.Floor((totalBonus * _extraDamagePercentageValue / 100.0)));
        unit.DamageEffectStat.ExtraDamageValue += extraDamage;
    }
}