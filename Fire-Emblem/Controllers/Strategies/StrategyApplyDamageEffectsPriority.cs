using Fire_Emblem.Controllers.Skills;
using Fire_Emblem.Models;


namespace Fire_Emblem.Controllers.Strategies
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
            ApplyEffects(defendingUnit, ApplyFirstDamageEffects);
            ApplyEffects(attackingUnit, ApplyFirstDamageEffects);
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
            if (IsDamageSkillType(unitSkill) && IsNotFirstPrioritySkill(unitSkill))
            {
                _skillsController.UpdateActiveSkillEffects(unitSkill, unit);
            }
        }

        private void ApplySecondDamageEffects(Unit unit, Skill unitSkill)
        {
            if (IsDamageSkillType(unitSkill) && IsFirstPrioritySkill(unitSkill))
            {
                _skillsController.UpdateActiveSkillEffects(unitSkill, unit);
            }
        }

        private bool IsDamageSkillType(Skill unitSkill)
        {
            return unitSkill.SkillType == "Damage";
        }

        private bool IsNotFirstPrioritySkill(Skill unitSkill)
        {
            return !SkillPriority.FirstPrioritySkills.Contains(unitSkill.Name);
        }

        private bool IsFirstPrioritySkill(Skill unitSkill)
        {
            return SkillPriority.FirstPrioritySkills.Contains(unitSkill.Name);
        }
    }
}