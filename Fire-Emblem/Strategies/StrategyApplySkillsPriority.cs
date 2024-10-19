using Fire_Emblem.Controllers;
using Fire_Emblem.Skills;

namespace Fire_Emblem.Strategies
{
    public class StrategyApplySkillsPriority
    {
        private RoundFightController _roundFightController;
        private StrategyApplyDamageEffectsPriority _strategyApplyDamageEffectsPriority;

        public StrategyApplySkillsPriority(RoundFightController roundFightController)
        {
            _roundFightController = roundFightController;
            _strategyApplyDamageEffectsPriority = new StrategyApplyDamageEffectsPriority(_roundFightController);
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
            attackingUnit.ApplyEffects();
            defendingUnit.ApplyEffects();

        }
        private void ApplyNonDamageSkills(Unit unit)
        {
            foreach (Skill unitSkill in unit.Skills.Reverse<Skill>())
            {
                UpdateActiveSkillEffects(unit, unitSkill);
            }
            

        }
        private void UpdateActiveSkillEffects(Unit attackingUnit, Skill unitSkill)
        {
            if (unitSkill.SkillData.SkillType != "Damage")
            {
                unitSkill.UpdateActiveSkillEffects(attackingUnit, _roundFightController);
            }
        }
        

        private void ApplyDamageSkills(Unit attackingUnit, Unit defendingUnit)

        {
            _strategyApplyDamageEffectsPriority.ApplyDamageEffects(attackingUnit, defendingUnit);
        }
        
        
    }
}