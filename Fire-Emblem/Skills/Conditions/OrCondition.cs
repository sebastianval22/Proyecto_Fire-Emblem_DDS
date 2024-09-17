namespace Fire_Emblem.Skills.Conditions
{
    public class OrCondition : Condition
    {
        private readonly List<Condition> _conditions;

        public OrCondition(List<Condition> conditions)
        {
            _conditions = conditions;
        }

        public override bool IsMet(Unit unit, RoundFight roundFight)
        {
            return _conditions.Any(condition => condition.IsMet(unit, roundFight));
        }
    }
}