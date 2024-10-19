using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public abstract class Condition
{
    public abstract bool IsMet(Unit unit, RoundFightController roundFightController);
}
