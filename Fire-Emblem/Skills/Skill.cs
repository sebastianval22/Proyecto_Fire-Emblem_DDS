using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

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

    public void UpdateActiveSkillEffects(Unit unit, RoundFight roundFight)
    {
        if (SkillData.Conditions.All(condition => condition.IsMet(unit, roundFight)))
        {
            ApplyEffects(unit, roundFight);
        }
    }

    private void ApplyEffects(Unit unit, RoundFight roundFight)
    {
        foreach (var effect in SkillData.Effects)
        {
            ApplyEffectBasedOnType(effect, unit, roundFight);
        }
    }

    private void ApplyEffectBasedOnType(Effect effect, Unit unit, RoundFight roundFight)
    {
        if (SkillData.SkillType != "Base Stats")
        {
            ApplyEffect(effect, unit, roundFight);
        }
    }

    private void ApplyEffect(Effect effect, Unit unit, RoundFight roundFight)
    {
        Unit rival = GetRival(unit, roundFight);

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
            effect.ApplySpecificEffect(unit, roundFight);
            Console.WriteLine("BIENNN");
        }
    }
    


    private Unit GetRival(Unit unit, RoundFight roundFight)
    {
        return unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
    }
}