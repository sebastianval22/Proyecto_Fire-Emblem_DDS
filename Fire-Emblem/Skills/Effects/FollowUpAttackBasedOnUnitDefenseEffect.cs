namespace Fire_Emblem.Skills.Effects;

public class FollowUpAttackBasedOnUnitDefenseEffect : Effect
{
    public override void Apply(Unit unit)
    {

    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        var unitDefense150 = 1.5 * unit.Defence;
        int attackEffect = Convert.ToInt32(Math.Floor(unitDefense150 - unit.Attack));
        
        if (attackEffect> 0)
        {
            unit.ActiveSkillsEffects["FollowUpAttackAttackBonus"] += attackEffect;
        }
        else
        {
            unit.ActiveSkillsEffects["FollowUpAttackAttackPenalty"] += attackEffect;
        }
    }
}
