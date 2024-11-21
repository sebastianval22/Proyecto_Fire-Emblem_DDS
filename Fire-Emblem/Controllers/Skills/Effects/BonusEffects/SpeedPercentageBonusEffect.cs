using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.BonusEffects;

public class SpeedPercentageBonusEffect : Effect, IBonusEffect
{
        private int _speedPercentageBonus;
        
        public SpeedPercentageBonusEffect(int speedPercentageBonus)
        {
            _speedPercentageBonus = speedPercentageBonus;
        }
        
        public override void Apply(Unit unit)
        {
            unit.Speed.Bonus += Convert.ToInt32(Math.Floor(unit.Speed.Value * _speedPercentageBonus / 100.00));
        }
        
}