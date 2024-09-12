using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills;

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
    
    public void AddCondition(Condition condition)
    {
        Conditions.Add(condition);
    }
    
    public void AddEffect(Effect effect)
    {
        Effects.Add(effect);
    }
    
    public void ApplyEffects(Unit unit, RoundFight roundFight)
    {
        if (Conditions.All(condition => condition.IsMet(unit, roundFight)))
        {
            foreach (var effect in Effects)
            {
                effect.Apply(unit);
            }
        }
    }
}