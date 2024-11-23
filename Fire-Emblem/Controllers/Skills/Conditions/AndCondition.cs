using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions
{
    public class AndCondition : Condition
    {
        private readonly List<Condition> _conditions;

        public AndCondition(List<Condition> conditions)
        {
            _conditions = conditions;
        }

        public override bool IsMet(Unit unit, RoundFightController roundFightController)
        {
            return _conditions.All(condition => condition.IsMet(unit, roundFightController));
        }
    }
}