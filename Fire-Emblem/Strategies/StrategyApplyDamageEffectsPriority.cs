using Fire_Emblem.Skills;
using Fire_Emblem.Controllers;

namespace Fire_Emblem.Strategies;

public class StrategyApplyDamageEffectsPriority
{
    private RoundFightController _roundFightController;
    public StrategyApplyDamageEffectsPriority(RoundFightController roundFightController)
    {
        _roundFightController = roundFightController;
    }
    public void ApplyDamageEffects(Unit attackingUnit, Unit defendingUnit)

    {
        foreach (Skill unitSkill in attackingUnit.Skills.Reverse<Skill>())
        {
            ApplyFirstDamageEffects(attackingUnit ,unitSkill);
        }
        foreach (Skill unitSkill in defendingUnit.Skills.Reverse<Skill>())
        {
            ApplyFirstDamageEffects(defendingUnit ,unitSkill);
        }
        foreach (Skill unitSkill in defendingUnit.Skills.Reverse<Skill>())
        {
            ApplySecondDamageEffects(defendingUnit, unitSkill);
        }
        foreach (Skill unitSkill in attackingUnit.Skills.Reverse<Skill>())
        {
            ApplySecondDamageEffects(attackingUnit, unitSkill);
        }
        
    }
        
    private void ApplyFirstDamageEffects(Unit unit, Skill unitSkill)
    {
        if (unitSkill.SkillData.SkillType == "Damage" && unitSkill.SkillData.Name != "Divine Recreation Damage")
        {
            Console.WriteLine($"Activando skill {unitSkill.SkillData.Name}");
            unitSkill.UpdateActiveSkillEffects(unit, _roundFightController);
        }
    }
    private void ApplySecondDamageEffects(Unit unit, Skill unitSkill)
    {
        if (unitSkill.SkillData.SkillType == "Damage" && unitSkill.SkillData.Name == "Divine Recreation Damage")
        {
            Console.WriteLine($"Activando skill {unitSkill.SkillData.Name}");
            unitSkill.UpdateActiveSkillEffects(unit, _roundFightController);
        }
    }
}