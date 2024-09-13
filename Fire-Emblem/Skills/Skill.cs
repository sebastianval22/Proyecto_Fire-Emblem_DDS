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

    public void ApplyEffects(Unit unit, RoundFight roundFight)
    {
        if (Conditions.All(condition => condition.IsMet(unit, roundFight)))
        {
            var attackBonus = 0;
            var defenseBonus = 0;
            var speedBonus = 0;
            var ResistanceBonus = 0;

            foreach (var effect in Effects)
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
                        Console.WriteLine($"{unit.Name} obtiene Spd+{bonusEffect.Bonus}");
                    }
                    else if (effect is ResistanceBonusEffect)
                    {
                        ResistanceBonus += bonusEffect.Bonus;
                    }
                }
                else
                {
                    Console.WriteLine($"{unit.Name} obtiene Spd+2");
                    Console.WriteLine($"{unit.Skills[0].Name}");
                    effect.Apply(unit);
                }
            }

            if (attackBonus > 0)
            {
                unit.Attack += attackBonus;
                EffectLogger.ShowEffect($"{unit.Name} obtiene Atk+{attackBonus}");
            }
            if (defenseBonus > 0)
            {
                unit.Defence += defenseBonus;
                EffectLogger.ShowEffect($"{unit.Name} obtiene Def+{defenseBonus}");
            }
            if (speedBonus > 0)
            {
                unit.Speed += speedBonus;
                EffectLogger.ShowEffect($"{unit.Name} obtiene Spd+{speedBonus}");
            }
            if (ResistanceBonus > 0)
            {
                unit.Resistance += ResistanceBonus;
                EffectLogger.ShowEffect($"{unit.Name} obtiene Res+{ResistanceBonus}");
            }
        }
    }
}