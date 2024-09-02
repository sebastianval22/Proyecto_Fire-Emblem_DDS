using Fire_Emblem.Skills.BonusSkills;

namespace Fire_Emblem.Skills;

public static class SkillFactory
{
    public static Skill CreateSkill(string skillName)
    {
        return skillName switch
        {
            "Fair Fight" => new FairFightSkill(),
            "Atk/Def +5" => new AtkDefPlus5Skill(),
            _ => throw new ArgumentException("Unknown skill name", nameof(skillName))
        };
    }
}