using Fire_Emblem.Controllers.Skills.Conditions;
using Fire_Emblem.Controllers.Skills.Effects;

namespace Fire_Emblem.Models;

public class Skill
{
    public string Name { get; set; }
    public string SkillType { get; set; }
    public List<Condition> Conditions { get; set; } = new List<Condition>();
    public List<Effect> Effects { get; set; } = new List<Effect>();

    public Skill(string name, string skillType)
    {
        Name = name;
        SkillType = skillType;
    }
}