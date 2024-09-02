using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills.BonusSkills;

public class FairFightSkill : Skill
{
    string Name { get; set; }
    public FairFightSkill()
    {
        Name = "Fair Fight";
        Conditions.Add(new InitiatesCombatCondition());
        Effects.Add(new AttackBonusEffect(6));
    } 
}