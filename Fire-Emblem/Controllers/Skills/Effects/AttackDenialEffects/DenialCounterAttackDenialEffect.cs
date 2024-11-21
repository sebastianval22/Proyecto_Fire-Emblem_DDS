using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.AttackDenialEffects;

public class DenialCounterAttackDenialEffect : Effect, IDenialOfAttackDenialEffect
{
    public override void Apply(Unit unit)
    {
        unit.HasDenialOfAttackDenialEffect = true;
    }
}