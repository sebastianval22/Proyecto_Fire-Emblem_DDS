using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.HealEffects;

public class HealBasedOnDamageEffect : Effect, IHealEffect
{
    private int _percentageHealAmount;

    public HealBasedOnDamageEffect(int percentageHealAmount)
    {
        _percentageHealAmount = percentageHealAmount;
    }
    
    public override void Apply(Unit unit)
    {
        unit.HpEffectStat.ExtraHpValueFromDamage += (_percentageHealAmount/100.00);
    }
}