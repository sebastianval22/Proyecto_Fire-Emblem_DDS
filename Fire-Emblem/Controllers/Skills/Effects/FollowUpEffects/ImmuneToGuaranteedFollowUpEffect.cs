using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.FollowUpEffects;

public class ImmuneToGuaranteedFollowUpEffect : Effect, INeutralizeFollowUpEffect
{
    public override void Apply(Unit unit)
    {
        unit.IsImmuneToGuaranteedFollowUpEffects = true;
    }
}