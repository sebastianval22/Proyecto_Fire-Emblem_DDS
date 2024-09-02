using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills;

public abstract class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Condition> Conditions { get; set; } = new List<Condition>();
    public List<Effect> Effects { get; set; } = new List<Effect>();

    public void ApplyEffects(Unit unit)
    {
        if (Conditions.All(condition => condition.IsMet(unit)))
        {
            foreach (var effect in Effects)
            {
                effect.Apply(unit);
            }
        }
    }
}