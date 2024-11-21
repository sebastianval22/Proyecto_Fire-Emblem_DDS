using Fire_Emblem.Models;
using Fire_Emblem.Controllers.Skills;

namespace Fire_Emblem.Controllers.Strategies
{
    public class StrategyApplySkillsPriority
    {
        
        private readonly UnitController _unitController = new UnitController();
        private readonly StrategyApplyDamageEffectsPriority _strategyApplyDamageEffectsPriority;
        private readonly SkillsController _skillsController;

        public StrategyApplySkillsPriority(RoundFightController roundFightController)
        {
            _skillsController = new SkillsController(roundFightController);
            _strategyApplyDamageEffectsPriority = new StrategyApplyDamageEffectsPriority(roundFightController);
        }

        public void ApplySkills(Unit attackingUnit, Unit defendingUnit)
        {
            ApplySkills(attackingUnit, SkillPriority.FirstPrioritySkillTypes);
            ApplySkills(defendingUnit, SkillPriority.FirstPrioritySkillTypes);
            ApplyEffectsFirstPrioritySkills(attackingUnit, defendingUnit);
            ApplySecondPrioritySkills(attackingUnit, defendingUnit);
        }
    
        private void ApplySkills(Unit unit, NameList prioritySkillTypes)
        {
            foreach (Skill unitSkill in unit.Skills.Reverse())
            {
                UpdateActiveSkillEffects(unit, unitSkill, prioritySkillTypes);
            }
        }
        
        private void UpdateActiveSkillEffects(Unit unit, Skill unitSkill, NameList prioritySkillTypes)
        {
            if (prioritySkillTypes.Contains(unitSkill.SkillType))
            {
                _skillsController.UpdateActiveSkillEffects(unitSkill, unit);
            }
        }
        
        private void ApplyEffectsFirstPrioritySkills(Unit attackingUnit, Unit defendingUnit)
        {
            _unitController.ApplyEffects(attackingUnit);
            _unitController.ApplyEffects(defendingUnit);
        }

        private void ApplySecondPrioritySkills(Unit attackingUnit, Unit defendingUnit)
        {
            _strategyApplyDamageEffectsPriority.ApplyDamageEffects(attackingUnit, defendingUnit);
            ApplySkills(attackingUnit, SkillPriority.SecondPrioritySkillTypes);
            ApplySkills(defendingUnit, SkillPriority.SecondPrioritySkillTypes);
        }
        
        public void ApplyAfterCombatSkills(Unit attackingUnit, Unit defendingUnit)
        {
            ApplySkills(attackingUnit, SkillPriority.AfterCombatSkillTypes);
            ApplySkills(defendingUnit, SkillPriority.AfterCombatSkillTypes);
        }
    }
}