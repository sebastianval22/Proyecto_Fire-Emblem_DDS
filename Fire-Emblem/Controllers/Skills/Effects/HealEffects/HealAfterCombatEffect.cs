using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.HealEffects;

public class HealAfterCombatEffect : Effect, IHealEffect
{
    
    private int _healValue;
    
    public HealAfterCombatEffect(int healValue)
    {
        _healValue = healValue;
    }

    public override void Apply(Unit unit)
    {
        unit.HpEffectStat.ExtraHpAfterCombatValue += _healValue;
    }
    
}