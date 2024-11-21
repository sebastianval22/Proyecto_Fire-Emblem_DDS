using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.BonusEffects;

public class AttackPercentageBonusBasedOnSpeedEffect : Effect, IBonusEffect
{

    private int _speedPercentageBonus;
    
    public AttackPercentageBonusBasedOnSpeedEffect(int speedPercentageBonus)
    {
        _speedPercentageBonus = speedPercentageBonus;
    }
    
    public override void Apply(Unit unit)
    {
        unit.Attack.Bonus += Convert.ToInt32(Math.Floor(unit.Speed.Value * _speedPercentageBonus / 100.00));
    }
    
}