using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.FollowUpEffects;

public class ImmuneToNeutralizeFollowUpEffect : Effect, ISelfNeutralizeFollowUpEffect
{
    
    public override void Apply(Unit unit)
    {
        unit.IsImmuneToNeutralizeFollowUpEffects = true;
    }
}