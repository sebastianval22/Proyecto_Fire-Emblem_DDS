using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

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
