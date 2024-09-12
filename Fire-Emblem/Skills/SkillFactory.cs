using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills;

public static class SkillFactory
{
    private static Skill CreateSkill(string skillName)
    {
        if (skillName == "Fair Fight")
        {
            return new Skill("Fair Fight", "Bonus")
            {
                Conditions = new List<Condition>
                {
                    new InitiatesCombatCondition(),
                    new HealthBelowCondition(50)
                },
                Effects = new List<Effect>
                {
                    new AttackBonusEffect(6)
                }
            };
        }
        else if (skillName == "HP +15"){
            return new Skill("HP +15", "Base Stats")
            {
                Effects = new List<Effect> { new Max15HPBonusEffect() }
            };
        }
        else if (skillName == "Resolve"){
            return new Skill("Resolve", "Bonus")
            {
                Effects = new List<Effect> { new DefenseBonusEffect(7), new ResistanceBonusEffect(7) },
                Conditions = new List<Condition> { new HealthBelowCondition(75) }
            };
        }
        else if (skillName == "Speed +5")
        {
            return new Skill("Speed +5", "Bonus")
            {
                Effects = new List<Effect> { new SpeedBonusEffect(5) }
            };
        }
        
        return null;
    }

    public static List<Skill> InitiateSkills(List<string> skillNames)
    {
        List<Skill> skills = new();
        foreach (var skillName in skillNames)
        {
            Skill skill = CreateSkill(skillName);
            if (skill != null)
            {
                skills.Add(skill);
            }
        }
        return skills;
    }
}