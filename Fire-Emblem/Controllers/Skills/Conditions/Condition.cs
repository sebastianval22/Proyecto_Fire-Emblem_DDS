using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public abstract class Condition
{
    public abstract bool IsMet(Unit unit, RoundFightController roundFightController);
    
    protected Unit GetRival(Unit unit, RoundFightController roundFightController)
    {
        Unit attackingUnit = roundFightController.AttackingUnit;
        Unit defendingUnit = roundFightController.DefendingUnit;
        return unit == attackingUnit ? defendingUnit : attackingUnit;
    }
}
