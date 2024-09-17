using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; set; }
    public string SkillType { get; set; }
    public List<Condition> Conditions { get; set; } = new List<Condition>();
    public List<Effect> Effects { get; set; } = new List<Effect>();

    private Unit _rival;

    public Skill(string name, string skillType)
    {
        Name = name;
        SkillType = skillType;
    }
    public void ActivateBaseStatsSkillEffects(Unit unit)
    {
        foreach (var effect in Effects)
        {
            effect.Apply(unit);
        }
    }
    public void UpdateActiveSkillEffects(Unit unit, RoundFight roundFight)
    {
        _rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        if (Conditions.All(condition => condition.IsMet(unit, roundFight)))
        {
            foreach (var effect in Effects)
            {
                if (SkillType == "First Attack")
                {
                    ApplyFirstAttackEffect(effect, unit);
                }
                else if (SkillType == "Bonus" || SkillType == "Penalty")
                {
                    ApplyRegularEffect(effect, unit);
                    effect.ApplySpecificEffect(unit, roundFight);  // If the Bonus/Penalty effect has a specific effect, apply it
                }
                else  if (SkillType != "Base Stats")
                {
                    effect.Apply(unit);
                    effect.ApplySpecificEffect(unit, roundFight);
                }
            }
        }
    }

    private void ApplyFirstAttackEffect(Effect effect, Unit unit)
    {
        if (effect is IBonusEffect bonusEffect)
        {
            effect.Apply(unit);
            if (effect is AttackBonusEffect)
            {
                unit.ActiveSkillsEffects["FirstAttackAttackBonus"] += bonusEffect.Bonus;
            }
            else if (effect is DefenseBonusEffect)
            {
                unit.ActiveSkillsEffects["FirstAttackDefenseBonus"] += bonusEffect.Bonus;
            }
            else if (effect is ResistanceBonusEffect)
            {
                unit.ActiveSkillsEffects["FirstAttackResistanceBonus"] += bonusEffect.Bonus;
            }
        }
        else if (effect is IPenaltyEffect penaltyEffect)
        {
            effect.Apply(_rival);
            if (effect is AttackPenaltyEffect)
            {
                unit.ActiveSkillsEffects["FirstAttackAttackPenalty"] -= penaltyEffect.Penalty;
            }
            else if (effect is DefensePenaltyEffect)
            {
                unit.ActiveSkillsEffects["FirstAttackDefensePenalty"] -= penaltyEffect.Penalty;
            }
            else if (effect is ResistancePenaltyEffect)
            {
                unit.ActiveSkillsEffects["FirstAttackResistancePenalty"] -= penaltyEffect.Penalty;
            }
        }
    }

    private void ApplyRegularEffect(Effect effect, Unit unit)
    {
        if (effect is IBonusEffect bonusEffect)
        {
            effect.Apply(unit);
            if (effect is AttackBonusEffect)
            {
                unit.ActiveSkillsEffects["AttackBonus"] += bonusEffect.Bonus;
            }
            else if (effect is DefenseBonusEffect)
            {
                unit.ActiveSkillsEffects["DefenseBonus"] += bonusEffect.Bonus;
            }
            else if (effect is SpeedBonusEffect)
            {
                unit.ActiveSkillsEffects["SpeedBonus"] += bonusEffect.Bonus;
            }
            else if (effect is ResistanceBonusEffect)
            {
                Console.WriteLine("Applying ResistanceBonusEffect");
                unit.ActiveSkillsEffects["ResistanceBonus"] += bonusEffect.Bonus;
            }
        }
        else if (effect is IPenaltyEffect penaltyEffect)
        {
            effect.Apply(_rival);
            if (effect is AttackPenaltyEffect)
            {
                unit.ActiveSkillsEffects["AttackPenalty"] -= penaltyEffect.Penalty;
            }
            else if (effect is DefensePenaltyEffect)
            {
                unit.ActiveSkillsEffects["DefensePenalty"] -= penaltyEffect.Penalty;
            }
            else if (effect is SpeedPenaltyEffect)
            {
                unit.ActiveSkillsEffects["SpeedPenalty"] -= penaltyEffect.Penalty;
            }
            else if (effect is ResistancePenaltyEffect)
            {
                unit.ActiveSkillsEffects["ResistancePenalty"] -= penaltyEffect.Penalty;
            }
        }
    }
}