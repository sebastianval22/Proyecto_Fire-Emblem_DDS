using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills.BonusSkills;

public class AtkDefPlus5Skill : Skill
{
    public AtkDefPlus5Skill()
    {
        Name = "Atk/Def +5";
        Effects.Add(new AttackBonusEffect(5));
        Effects.Add(new DefenseBonusEffect(5));
    }
}