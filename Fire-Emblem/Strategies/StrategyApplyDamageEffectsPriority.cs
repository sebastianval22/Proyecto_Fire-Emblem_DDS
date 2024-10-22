using Fire_Emblem.Skills;
using Fire_Emblem.Controllers;

namespace Fire_Emblem.Strategies
{
    public class StrategyApplyDamageEffectsPriority
    {
        private readonly SkillsController _skillsController;

        public StrategyApplyDamageEffectsPriority(RoundFightController roundFightController)
        {
            _skillsController = new SkillsController(roundFightController);
        }

        public void ApplyDamageEffects(Unit attackingUnit, Unit defendingUnit)
        {
            ApplyEffects(attackingUnit, ApplyFirstDamageEffects);
            ApplyEffects(defendingUnit, ApplyFirstDamageEffects);
            ApplyEffects(defendingUnit, ApplySecondDamageEffects);
            ApplyEffects(attackingUnit, ApplySecondDamageEffects);
        }

        private void ApplyEffects(Unit unit, Action<Unit, Skill> applyEffect)
        {
            foreach (Skill unitSkill in unit.Skills.Reverse<Skill>())
            {
                applyEffect(unit, unitSkill);
            }
        }

        private void ApplyFirstDamageEffects(Unit unit, Skill unitSkill)
        {
            if (SkillPriority.FirstPrioritySkillTypes.Contains(unitSkill.SkillType) && !SkillPriority.FirstPrioritySkills.Contains(unitSkill.Name))
            {
                _skillsController.UpdateActiveSkillEffects(unitSkill, unit);
            }
        }

        private void ApplySecondDamageEffects(Unit unit, Skill unitSkill)
        {
            if (SkillPriority.FirstPrioritySkillTypes.Contains(unitSkill.SkillType) && SkillPriority.FirstPrioritySkills.Contains(unitSkill.Name))
            {
                _skillsController.UpdateActiveSkillEffects(unitSkill, unit);
            }
        }
    }
}