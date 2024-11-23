using Fire_Emblem.Models;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controllers
{
    
    public class UnitEffectsService
    {
        private readonly StatController _statController = new StatController();
        private readonly UnitAttributesService _attributesService = new UnitAttributesService();
        public void ApplyEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                _statController.ApplyEffects(stat);
            }

            if (HasFirstAttackEffects(unit))
            {
                _attributesService.SaveAttributes(unit);
                ApplyFirstAttackEffects(unit);
                unit.HasFirstAttackSkill = true;
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
        
        public void ApplyHPEffects(Unit unit, int damage)
        {
            int extraHp = Convert.ToInt32(Math.Floor(unit.HpEffectStat.ExtraHpValueFromDamage * damage));
            unit.CurrentHP = Math.Min(unit.MaxHP, unit.CurrentHP + extraHp);
            EffectView.ShowHpChange(unit, extraHp);
        }
        public void ApplyExtraHPAfterCombatEffects(Unit unit)
        {
            int extraHp = unit.HpEffectStat.ExtraHpAfterCombatValue;
            unit.CurrentHP = Math.Min(unit.MaxHP, unit.CurrentHP + extraHp);
            if (unit.CurrentHP <= 0)
            {
                unit.CurrentHP = 1;
            }
            EffectView.ShowHpChangeAfterCombat(unit);
        }

        public void ResetActiveSkillsEffects(Unit unit)
        {
            ResetStatEffects(unit);
            ResetUnitFlags(unit);
            ResetFollowUpEffects(unit);
            ResetDamageActiveSkillsEffects(unit);
            ResetHPActiveSkillsEffects(unit);
        }

        private void ResetStatEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                _statController.ResetEffects(stat);
            }
        }

        private void ResetUnitFlags(Unit unit)
        {
            unit.HasFirstAttackSkill = false;
            unit.CanCounterAttack = true;
            unit.CanFollowUpAttack = true;
            unit.HasDenialOfAttackDenialEffect = false;
            unit.HasAttackedInRound = false;
            unit.HasFollowedUpInRound = false;
        }

        private void ResetFollowUpEffects(Unit unit)
        {
            unit.GuaranteedFollowUpEffects = 0;
            unit.NeutralizeFollowUpEffects = 0;
            unit.IsImmuneToNeutralizeFollowUpEffects = false;
            unit.IsImmuneToGuaranteedFollowUpEffects = false;
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
            unit.DamageEffectStat.ExtraDamageBeforeCombatValue = 0;
            unit.DamageEffectStat.DamagePercentageReductionReductionValue = 1;
        }

        private void ResetHPActiveSkillsEffects(Unit unit)
        {
            unit.HpEffectStat.ExtraHpValueFromDamage = 0;
            unit.HpEffectStat.ExtraHpAfterCombatValue = 0;
        }
    }
}