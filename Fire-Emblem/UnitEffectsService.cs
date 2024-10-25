using Fire_Emblem.Controllers;

namespace Fire_Emblem
{
    
    public class UnitEffectsService
    {
        
        private readonly StatController _statController = new StatController();
        
        public void ApplyEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                _statController.ApplyEffects(stat);
            }

            if (HasFirstAttackEffects(unit))
            {
                SaveAttributes(unit);
                ApplyFirstAttackEffects(unit);
                unit.HasFirstAttackSkill = true;
            }
        }
        
        public void SaveAttributes(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                stat.SaveValue();
            }
        }
        
        private bool HasFirstAttackEffects(Unit unit)
        {
            return unit.Stats.Any(stat => stat.FirstAttackBonus != 0 || stat.FirstAttackPenalty != 0);
        }

        private void ApplyFirstAttackEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                _statController.ApplyFirstAttackEffects(stat); 
            }
        }

        public void ApplyFollowUpAttackEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                _statController.ApplyFollowUpAttackEffects(stat);
            }
        }

        public void ResetActiveSkillsEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                _statController.ResetEffects(stat);
            }
            unit.HasFirstAttackSkill = false;
            ResetDamageActiveSkillsEffects(unit);
        }
        
        private void ResetDamageActiveSkillsEffects(Unit unit)
        {
            unit.DamageEffectStat.DamagePercentageReductionValue = 1;
            unit.DamageEffectStat.DamagePercentageReductionFirstAttackValue = 1;
            unit.DamageEffectStat.DamagePercentageReductionFollowUpAttackValue = 1;
            unit.DamageEffectStat.DamageAbsoluteReductionValue = 0;
            unit.DamageEffectStat.DamageAbsoluteReductionFirstAttackValue = 0;
            unit.DamageEffectStat.ExtraDamageValue = 0;
            unit.DamageEffectStat.ExtraDamageFirstAttackValue = 0;
            unit.DamageEffectStat.ExtraDamageFollowUpAttackValue = 0;
        }
    }
}