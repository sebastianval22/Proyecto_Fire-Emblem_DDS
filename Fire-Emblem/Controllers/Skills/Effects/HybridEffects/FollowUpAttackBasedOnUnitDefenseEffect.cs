using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.HybridEffects;

public class FollowUpAttackBasedOnUnitDefenseEffect : Effect
{
    public override void Apply(Unit unit)
    {

    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        var unitDefense150 = 1.5 * unit.Defense.Value;
        int attackEffect = Convert.ToInt32(Math.Floor(unitDefense150 - unit.Attack.Value));
        
        if (attackEffect> 0)
        {
            unit.Attack.FollowUpAttackBonus+= attackEffect;
        }
        else
        {
            unit.Attack.FollowUpAttackPenalty += attackEffect;
        }
    }
}
