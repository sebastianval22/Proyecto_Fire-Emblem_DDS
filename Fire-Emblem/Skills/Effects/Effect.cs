using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects;

public abstract class Effect
{
    public abstract void Apply(Unit unit);
    
    public virtual void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
    }
    
    protected Unit GetRival(Unit unit, RoundFightController roundFightController)
    {
        Unit attackingUnit = roundFightController.AttackingUnit;
        Unit defendingUnit = roundFightController.DefendingUnit;
        return unit == attackingUnit ? defendingUnit : attackingUnit;
    }
}