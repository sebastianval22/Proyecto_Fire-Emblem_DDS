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
            ApplyNonDamageSkills(attackingUnit);
            ApplyNonDamageSkills(defendingUnit);
            ApplyEffectsNonDamageSkills(attackingUnit, defendingUnit);
            ApplyDamageSkills(attackingUnit, defendingUnit);
        }

        private void ApplyEffectsNonDamageSkills(Unit attackingUnit, Unit defendingUnit)
        {
            _unitController.ApplyEffects(attackingUnit);
            _unitController.ApplyEffects(defendingUnit);
        }

        private void ApplyNonDamageSkills(Unit unit)
        {
            foreach (Skill unitSkill in unit.Skills.Reverse())
            {
                UpdateActiveSkillEffects(unit, unitSkill);
            }
        }

        private void UpdateActiveSkillEffects(Unit unit, Skill unitSkill)
        {
            if (!SkillPriority.FirstPrioritySkillTypes.Contains(unitSkill.SkillType))
            {
                _skillsController.UpdateActiveSkillEffects(unitSkill, unit);
            }
        }

        private void ApplyDamageSkills(Unit attackingUnit, Unit defendingUnit)
        {
            _strategyApplyDamageEffectsPriority.ApplyDamageEffects(attackingUnit, defendingUnit);
        }
    }
}