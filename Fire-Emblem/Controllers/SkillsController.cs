using Fire_Emblem.Skills;
using Fire_Emblem.Skills.Effects;
using Fire_Emblem.Skills.Effects.Damage;
using Fire_Emblem.Skills.Effects.BonusEffects;
using Fire_Emblem.Skills.Effects.PenaltyEffects;
using Fire_Emblem.Skills.Effects.NeutralizeEffects;
using Fire_Emblem.Skills.Effects.CostEffects;

namespace Fire_Emblem.Controllers
{
    public class SkillsController
    {
        private readonly RoundFightController _roundFightController;

        public SkillsController(RoundFightController roundFightController)
        {
            _roundFightController = roundFightController;
        }
        
        public void ActivateBaseStatsSkillEffects(Skill skill, Unit unit)
        {
            foreach (var effect in skill.Effects)
            {
                effect.Apply(unit);
            }
        }

        public void UpdateActiveSkillEffects(Skill skill, Unit unit)
        {
            if (skill.Conditions.All(condition => condition.IsMet(unit, _roundFightController)))
            {
                ApplyEffects(skill, unit);
            }
        }

        private void ApplyEffects(Skill skill, Unit unit)
        {
            foreach (var effect in skill.Effects)
            {
                ApplyEffectBasedOnType(skill, effect, unit);
            }
        }

        private void ApplyEffectBasedOnType(Skill skill, Effect effect, Unit unit)
        {
            if (skill.SkillType != "Base Stats")
            {
                ApplyEffect(effect, unit);
            }
        }

        private void ApplyEffect(Effect effect, Unit unit)
        {
            Unit rival = GetRival(unit, _roundFightController);

            if (effect is IPenaltyEffect or INeutralizeBonus)
            {
                effect.Apply(rival);
            }
            else if (effect is IBonusEffect or ICostEffect or INeutralizePenalty or ISelfNeutralizeBonus)
            {
                effect.Apply(unit);
            }
            else if (effect is IDamageEffect)
            {
                effect.Apply(unit);
            }
            else
            {
                effect.ApplySpecificEffect(unit, _roundFightController);
            }
        }

        private Unit GetRival(Unit unit, RoundFightController roundFightController)
        {
            Unit attackingUnit = roundFightController.AttackingUnit;
            Unit defendingUnit = roundFightController.DefendingUnit;
            return unit == attackingUnit ? defendingUnit : attackingUnit;
        }
    }
}
