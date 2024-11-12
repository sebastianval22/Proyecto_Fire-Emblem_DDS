using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.BonusEffects
{
    public class DefenseBonusEffect : Effect, IBonusEffect
    {
        
        private int _bonus;

        public DefenseBonusEffect(int bonus)
        {
            _bonus = bonus;
        }

        public override void Apply(Unit unit)
        {
            unit.Defense.Bonus += _bonus;
        }
    }
}