using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Controllers;
using Fire_Emblem.Skills.Effects;
using Fire_Emblem.Skills.Effects.PenaltyEffects;
using Fire_Emblem.Skills.Effects.BonusEffects;
using Fire_Emblem.Skills.Effects.NeutralizeEffects;
using Fire_Emblem.Skills.Effects.Damage;
using Fire_Emblem.Skills.Effects.CostEffects;

namespace Fire_Emblem.Skills;

public class Skill
{
    private readonly SkillData _skillData;

    public SkillData SkillData
    {
        get => _skillData;
    }

    public Skill(SkillData skillData)
    {
        _skillData = skillData;
    }

    public void ActivateBaseStatsSkillEffects(Unit unit)
    {
        foreach (var effect in SkillData.Effects)
        {
            effect.Apply(unit);
        }
    }

    public void UpdateActiveSkillEffects(Unit unit, RoundFightController roundFightController)
    {
        if (SkillData.Conditions.All(condition => condition.IsMet(unit, roundFightController)))
        {
            ApplyEffects(unit, roundFightController);
        }
    }

    private void ApplyEffects(Unit unit, RoundFightController roundFightController)
    {
        foreach (var effect in SkillData.Effects)
        {
            ApplyEffectBasedOnType(effect, unit, roundFightController);
        }
    }

    private void ApplyEffectBasedOnType(Effect effect, Unit unit, RoundFightController roundFightController)
    {
        if (SkillData.SkillType != "Base Stats")
        {
            ApplyEffect(effect, unit, roundFightController);
        }
    }

    private void ApplyEffect(Effect effect, Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);

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
            effect.ApplySpecificEffect(unit, roundFightController);
        }
    }
    


    private Unit GetRival(Unit unit, RoundFightController roundFightController)
    {
        return unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
    }
}