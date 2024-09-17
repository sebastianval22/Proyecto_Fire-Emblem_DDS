using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; set; }
    public string SkillType { get; set; }
    public List<Condition> Conditions { get; set; } = new List<Condition>();
    public List<Effect> Effects { get; set; } = new List<Effect>();
    
    private Unit _unit;
    private Unit _rival;

    public Skill(string name, string skillType)
    {
        Name = name;
        SkillType = skillType;
    }
    public void ActivateBaseStatsSkillEffects(Unit unit)
    {
        foreach (var effect in Effects)
        {
            effect.Apply(unit);
        }
    }
    public void UpdateActiveSkillEffects(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        if (Conditions.All(condition => condition.IsMet(unit, roundFight)))
        {
            foreach (var effect in Effects)
            {
                if (SkillType != "Base Stats")
                {
                    if (effect is IPenaltyEffect)
                    {
                        effect.Apply(rival);
                    }
                    else if (effect is IBonusEffect)
                    {
                        effect.Apply(unit);
                    }
                    else if (effect is ICostEffect)
                    {
                        effect.Apply(unit);
                    }
                    else if (effect is INeutralizeBonus)
                    {
                        effect.Apply(rival);
                    }
                    else if (effect is INeutralizePenalty)
                    {
                        effect.Apply(unit);
                    }
                    else
                    {
                        effect.ApplySpecificEffect(unit, roundFight);
                    }
                    
                }
            }
        }
    }

   
}