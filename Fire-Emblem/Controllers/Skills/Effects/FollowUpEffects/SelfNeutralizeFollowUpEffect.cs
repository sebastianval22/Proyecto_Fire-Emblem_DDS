using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.FollowUpEffects;

public class SelfNeutralizeFollowUpEffect : Effect, ISelfNeutralizeFollowUpEffect
{
    public override void Apply(Unit unit)
    {
        unit.NeutralizeFollowUpEffects += 1;
    }
}