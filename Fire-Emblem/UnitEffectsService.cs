namespace Fire_Emblem
{
    public class UnitEffectsService
    {
        public void ApplyEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                stat.ApplyEffects();
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
                stat.ApplyFirstAttackEffects();
            }
        }

        public void ApplyFollowUpAttackEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                stat.ApplyFollowUpAttackEffects();
            }
        }

        public void ResetActiveSkillsEffects(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                stat.ResetEffects();
            }
            unit.HasFirstAttackSkill = false;
            ResetDamageActiveSkillsEffects(unit);
        }
        private void ResetDamageActiveSkillsEffects(Unit unit)
        {
            unit.DamagePercentageReductionStat.Value = 1;
            unit.DamagePercentageReductionStat.FirstAttackValue = 1;
            unit.DamagePercentageReductionStat.FollowUpAttackValue = 1;
            unit.DamageAbsoluteReductionStat.Value = 0;
            unit.DamageAbsoluteReductionStat.FirstAttackValue = 0;
            unit.ExtraDamageStat.Value = 0;
            unit.ExtraDamageStat.FirstAttackValue = 0;
            unit.ExtraDamageStat.FollowUpAttackValue = 0;
        }
    }
}