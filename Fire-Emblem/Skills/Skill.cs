using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; set; }
    public string SkillType { get; set; }
    public List<Condition> Conditions { get; set; } = new List<Condition>();
    public List<Effect> Effects { get; set; } = new List<Effect>();

    public Skill(string name, string skillType)
    {
        Name = name;
        SkillType = skillType;
    }

    public void AddCondition(Condition condition)
    {
        Conditions.Add(condition);
    }

    public void AddEffect(Effect effect)
    {
        Effects.Add(effect);
    }

    public Dictionary<string, int> ObtainEffects(Unit unit, RoundFight roundFight)
    {
        var attackBonus = 0;
        var defenseBonus = 0;
        var speedBonus = 0;
        var resistanceBonus = 0;
        var attackPenalty = 0;
        var defensePenalty = 0;
        var speedPenalty = 0;
        var resistancePenalty = 0;
        var firstAttackAttackBonus = 0;
        var firstAttackDefenseBonus = 0;
        var firstAttackResistanceBonus = 0;
        var firstAttackAttackPenalty = 0;
        var firstAttackDefensePenalty = 0;
        var firstAttackResistancePenalty = 0;
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        if (Conditions.All(condition => condition.IsMet(unit, roundFight)))
        {
            
            foreach (var effect in Effects)
            {
                if (SkillType == "First Attack")
                {
                    if (effect is IBonusEffect bonusEffect)
                    {
                        effect.Apply(unit);
                        if (effect is AttackBonusEffect)
                        {
                            firstAttackAttackBonus += bonusEffect.Bonus;
                        }
                        else if (effect is DefenseBonusEffect)
                        {
                            firstAttackDefenseBonus += bonusEffect.Bonus;
                        }
                        else if (effect is ResistanceBonusEffect)
                        {
                            firstAttackResistanceBonus += bonusEffect.Bonus;
                        }
                    }
                    else if (effect is IPenaltyEffect penaltyEffect)
                    {
                        effect.Apply(rival);
                        if (effect is AttackPenaltyEffect)
                        {
                            firstAttackAttackPenalty -= penaltyEffect.Penalty;
                        }
                        else if (effect is DefensePenaltyEffect)
                        {
                            firstAttackDefensePenalty -= penaltyEffect.Penalty;
                        }
                        else if (effect is ResistancePenaltyEffect)
                        {
                            firstAttackResistancePenalty -= penaltyEffect.Penalty;
                        }
                    }
                }
                else if (SkillType == "Bonus" || SkillType == "Penalty")
                {
                    if (effect is IBonusEffect bonusEffect)
                    {
                        effect.Apply(unit);
                        if (effect is AttackBonusEffect)
                        {
                            attackBonus += bonusEffect.Bonus;
                        }
                        else if (effect is DefenseBonusEffect)
                        {
                            defenseBonus += bonusEffect.Bonus;
                        }
                        else if (effect is SpeedBonusEffect)
                        {
                            speedBonus += bonusEffect.Bonus;
                        }
                        else if (effect is ResistanceBonusEffect)
                        {
                            resistanceBonus += bonusEffect.Bonus;
                        }
                    }
                    else if (effect is IPenaltyEffect penaltyEffect)
                    {
                        effect.Apply(rival);
                        if (effect is AttackPenaltyEffect)
                        {
                            attackPenalty -= penaltyEffect.Penalty;
                        }
                        else if (effect is DefensePenaltyEffect)
                        {
                            defensePenalty -= penaltyEffect.Penalty;
                        }
                        else if (effect is SpeedPenaltyEffect)
                        {
                            speedPenalty -= penaltyEffect.Penalty;
                        }
                        else if (effect is ResistancePenaltyEffect)
                        {
                            resistancePenalty -= penaltyEffect.Penalty;
                        }
                    }
                }
                
                else 
                {
                    effect.Apply(unit);
                }
            }
            
        }
        Console.WriteLine($"{Name} has been applied to {unit.Name} with the following effects: {attackPenalty}, {firstAttackDefensePenalty}, {resistancePenalty}");
        return new Dictionary<string, int>
            {
                {"AttackBonus", attackBonus},
                {"DefenseBonus", defenseBonus},
                {"SpeedBonus", speedBonus},
                {"ResistanceBonus", resistanceBonus},
                {"AttackPenalty", attackPenalty},
                {"DefensePenalty", defensePenalty},
                {"SpeedPenalty", speedPenalty},
                {"ResistancePenalty", resistancePenalty},
                {"FirstAttackAttackBonus", firstAttackAttackBonus},
                {"FirstAttackDefenseBonus", firstAttackDefenseBonus},
                {"FirstAttackResistanceBonus", firstAttackResistanceBonus},
                {"FirstAttackAttackPenalty", firstAttackAttackPenalty},
                {"FirstAttackDefensePenalty", firstAttackDefensePenalty},
                {"FirstAttackResistancePenalty", firstAttackResistancePenalty}
            };
    }
}
    

    