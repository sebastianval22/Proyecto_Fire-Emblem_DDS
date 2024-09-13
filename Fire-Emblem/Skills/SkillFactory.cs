using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Skills;

public static class SkillFactory
{
    private static Skill CreateSkill(string skillName)
    {
        switch (skillName)
        {
            case "Fair Fight":
                return new Skill("Fair Fight", "Bonus")
                {
                    Conditions = new List<Condition>
                    {
                        new InitiatesCombatCondition(),
                        new HealthBelowCondition(50)
                    },
                    Effects = new List<Effect>
                    {
                        new AttackBonusEffect(6)
                    }
                };
            case "HP +15":
                return new Skill("HP +15", "Base Stats")
                {
                    Effects = new List<Effect> { new Max15HPBonusEffect() }
                };
            case "Resolve":
                return new Skill("Resolve", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(7), new ResistanceBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthBelowCondition(75) }
                };
            case "Speed +5":
                return new Skill("Speed +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5) }
                };
            case "Armored Blow":
                return new Skill("Armored Blow", "Bonus")
                {
                    Conditions = new List<Condition> { new InitiatesCombatCondition() },
                    Effects = new List<Effect> { new DefenseBonusEffect(8) }
                };
            case "Will to Win":
                return new Skill("Will to Win", "Bonus")
                {
                    Conditions = new List<Condition> { new HealthBelowCondition(50) },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
            case "Single-Minded":
                return new Skill("Single-Minded", "Bonus")
                {
                    Conditions = new List<Condition> { new RecentOpponentCondition() },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
            case "Ignis":
                return new Skill("Ignis", "First Attack Bonus")
                {
                    Effects = new List<Effect> { new FirstAttackBonusEffect(50) }
                };
            case "Perceptive":
                var additionalBonusPerSpeed = new Dictionary<string, int>
                {
                    { "Bonus", 1 },
                    { "Per Speed", 4 }
                };
                return new Skill("Perceptive", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusWithAdditionalEffect(12,additionalBonusPerSpeed) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Tome Precision":
                return new Skill("Tome Precision", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> {new WeaponUsedCondition("Magic")}
                };
            case "Attack +6":
                return new Skill("Attack +6", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) }
                };
            case "Defense +5":
                return new Skill("Defense +5", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(5) }
                };
            case "Wrath":
                var additionalAttackBonusPerHPLost = new Dictionary<string, int>
                {
                    { "Bonus", 1 },
                    { "Per HP", 1 }
                };
                var additionalSpeedBonusPerHP = new Dictionary<string, int>
                {
                    { "Bonus", 1 },
                    { "Per HP", 1 }
                };
                return new Skill("Wrath", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusPerHPLostEffect(0, additionalAttackBonusPerHPLost,30), 
                        new SpeedBonusPerHPLostEffect(0, additionalSpeedBonusPerHP, 30) },
                };
            case "Resistance":
                return new Skill("Resistance", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(5) }
                };
            case "Atk/Def +5":
                return new Skill("Atk/Def +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new DefenseBonusEffect(5) }
                };
            case "Atk/Res +5":
                return new Skill("Atk/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new ResistanceBonusEffect(5) }
                };
            case "Spd/Res +5":
                return new Skill("Spd/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5), new ResistanceBonusEffect(5) }
                };
            case "Deadly Blade":
                return new Skill("Deadly Blade", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8), new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword"), new InitiatesCombatCondition() }
                };
            case "Death Blow":
                return new Skill("Death Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Darting Blow":
                return new Skill("Armored Blow", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Warding Blow":
                return new Skill("Warding Blow", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Swift Sparrow":
                return new Skill("Swift Sparrow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Sturdy Blow":
                return new Skill("Sturdy Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Mirror Strike":
                return new Skill("Mirror Strike", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Steady Blow":
                return new Skill("Steady Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Swift Strike":
                return new Skill("Swift Strike", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Bracing Blow":
                return new Skill("Bracing Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
            case "Brazen Atk/Spd":
                return new Skill("Brazen Atk/Spd", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new SpeedBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
            case "Brazem Atk/Def":
                return new Skill("Brazen Atk/Def", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
            case "Brazen Atk/Res":
                return new Skill("Brazen Atk/Res", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
            case "Brazen Spd/Def":
                return new Skill("Brazen Spd/Def", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
            case "Brazen Spd/Res":
                return new Skill("Brazen Spd/Res", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
            case "Brazen Def/Res":
                return new Skill("Brazen Def/Res", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
            case "Fire Boost":
                return new Skill("Fire Boost", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
            default:
                return null;
        }
    }


    public static List<Skill> InitiateSkills(List<string> skillNames)
    {
        List<Skill> skills = new();
        foreach (var skillName in skillNames)
        {
            Skill skill = CreateSkill(skillName);
            if (skill != null)
            {
                skills.Add(skill);
            }
        }
        return skills;
    }
}