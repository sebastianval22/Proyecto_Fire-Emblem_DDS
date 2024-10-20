using Fire_Emblem.Skills;
using Fire_Emblem.Controllers;

namespace Fire_Emblem.Strategies;

public class StrategyApplyDamageEffectsPriority
{
    private readonly SkillsController _skillsController;
    public StrategyApplyDamageEffectsPriority(RoundFightController roundFightController)
    {
        _skillsController = new SkillsController(roundFightController);
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
        if (unitSkill.SkillType == "Damage" && unitSkill.Name != "Divine Recreation Damage")
        {
            _skillsController.UpdateActiveSkillEffects(unitSkill, unit);
        }
    }
    private void ApplySecondDamageEffects(Unit unit, Skill unitSkill)
    {
        if (unitSkill.SkillType == "Damage" && unitSkill.Name == "Divine Recreation Damage")
        {
            _skillsController.UpdateActiveSkillEffects(unitSkill, unit);
        }
    }
}