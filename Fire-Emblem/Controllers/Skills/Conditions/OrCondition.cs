using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions
{
    public class OrCondition : Condition
    {
        private readonly List<Condition> _conditions;

        public OrCondition(List<Condition> conditions)
        {
            _conditions = conditions;
        }

        public override bool IsMet(Unit unit, RoundFightController roundFightController)
        {
            return _conditions.Any(condition => condition.IsMet(unit, roundFightController));
        }
    }
}