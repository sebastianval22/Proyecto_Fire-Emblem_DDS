using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.AttackDenialEffects;

public class CounterAndFollowUpAttackDenialEffect : Effect, IAttackDenialEffect
{
    public override void Apply(Unit unit)
    {
        unit.CanCounterAttack = false;
        unit.CanFollowUpAttack = false;
    }
}