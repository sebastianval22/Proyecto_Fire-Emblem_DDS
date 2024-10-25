namespace Fire_Emblem.Skills.Effects.BonusEffects
{
    public class ResistanceBonusEffect : Effect, IBonusEffect
    {
        
        private  readonly int _bonus;

        public ResistanceBonusEffect(int bonus)
        {
            _bonus = bonus;
        }

        public override void Apply(Unit unit)
        {
            unit.Resistance.Bonus += _bonus;
        }
    }
}