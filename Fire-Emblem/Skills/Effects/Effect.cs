using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects;

public abstract class Effect
{
    public abstract void Apply(Unit unit);
    public virtual void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
    }

}