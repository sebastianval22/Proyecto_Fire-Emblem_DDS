using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.FollowUpEffects;

public class GuaranteedFollowUpEffect : Effect, IGuaranteeFollowUpEffect
{
    public override void Apply(Unit unit)
    {
        unit.GuaranteedFollowUpEffects += 1;
    }
}