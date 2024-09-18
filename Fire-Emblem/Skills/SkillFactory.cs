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
                        new InitiatesCombatCondition()
                    },
                    Effects = new List<Effect>
                    {
                        new AttackBonusEffect(6),
                        new AttackBonusOpponentEffect(6)
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
                return new Skill("Ignis", "First Attack")
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
            case "Resistance +5":
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
            case "Brazen Atk/Def":
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
            case  "Wind Boost":
                return new Skill("Wind Boost", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
            case  "Earth Boost":
                return new Skill("Earth Boost", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
            case "Water Boost":
                return new Skill("Water Boost", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
            case "Chaos Style":
                return new Skill("Chaos Style", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(3) },
                    Conditions = new List<Condition> {new InitiatesCombatCondition(), new WeaponVsMagicCondition() }
                };
            case "Blinding Flash":
                return new Skill("Blinding Flash", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(4) },
                    Conditions = new List<Condition> {new InitiatesCombatCondition() }
                };
            case "Not *Quite*":
                return new Skill("Not *Quite*", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(4) },
                    Conditions = new List<Condition> {new OpponentInitiatesCombatCondition() }
                };
            case "Stunning Smile":
                return new Skill("Stunning Smile", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(8) },
                    Conditions = new List<Condition> {new OpponentGenderCondition("Male") }
                };
            case "Disarming Sigh":
                return new Skill("Disarming Sigh", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
            case "Charmer":
                return new Skill("Charmer", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(3), new AttackPenaltyEffect(3) },
                    Conditions = new List<Condition> { new RecentOpponentCondition()}
                };
            case "Luna":
                return new Skill("Luna", "First Attack")
                {
                    Effects = new List<Effect> { new FirstDefensePenaltyMinusHalfEffect(0), new FirstResistancePenaltyMinusHalfEffect(0) }
                };
            case "Belief in Love":
                return new Skill("Belief in Love", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new DefensePenaltyEffect(5) },
                    Conditions = new List<Condition> {  new OrCondition(new List<Condition> 
                        {new OpponentInitiatesCombatCondition(),  new OpponentHP100Condition()})
                    } 
                };
            case "Beorc's Blessing":
                return new Skill("Beorc's Blessing", "Neutralization")
                {
                    Effects = new List<Effect> { new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect() },
                };
            case "Agnea's Arrow":
                return new Skill("Agnea's Arrow", "Neutralization")
                {
                    Effects = new List<Effect> { new NeutralizeDefensePenaltyEffect(), new NeutralizeAttackPenaltyEffect(), new NeutralizeResistancePenaltyEffect(), new NeutralizeSpeedPenaltyEffect() },
                };
            case "Soulblade":
                return new Skill("Soulblade", "Hybrid")
                {
                    Effects = new List<Effect> { new OpponentDefenseResistanceAverageEffect() },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
            case "Sandstorm":
                return new Skill("Sandstorm", "Hybrid")
                {
                    Effects = new List<Effect> { new FollowUpAttackBasedOnUnitDefenseEffect() }
                };
            case "Sword Agility":
                return new Skill("Sword Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
            case "Lance Power":
                return new Skill("Lance Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Lance") }
                };
            case "Sword Power":
                return new Skill("Sword Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10)},
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
            case "Bow Focus":
                return new Skill("Bow Focus", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Bow") }
                };
            case "Lance Agility":
                return new Skill("Lance Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Lance") }
                };
            case "Axe Power":
                return new Skill("Axe Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Axe") }
                };
            case "Bow Agility":
                return new Skill("Bow Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Bow") }
                };
            case "Sword Focus":
                return new Skill("Sword Focus", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
            case "Close Def":
                return new Skill("Close Def", "Hybrid")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(8), new ResistanceBonusEffect(8), new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect()},
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition(), new OrCondition(new List<Condition>
                        {new OpponentWeaponUsedCondition("Sword"), new OpponentWeaponUsedCondition("Lance"), new OpponentWeaponUsedCondition("Axe") }) }
                };
            case "Distant Def":
                return new Skill("Distant Def", "Hybrid")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(8), new ResistanceBonusEffect(8), new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect()},
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition(), new OrCondition(new List<Condition>
                        {new OpponentWeaponUsedCondition("Magic"), new OpponentWeaponUsedCondition("Bow") }) }
                };
            case "Lull Atk/Spd":
                return new Skill("Lull Atk/Spd", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(3), new SpeedPenaltyEffect(3), new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect() }
                };
            case "Lull Atk/Def":
                return new Skill("Lull Atk/Def", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(3), new DefensePenaltyEffect(3), new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect() }
                };
            case "Lull Atk/Res":
                return new Skill("Lull Atk/Res", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(3), new ResistancePenaltyEffect(3), new NeutralizeAttackBonusEffect(), new NeutralizeResistanceBonusEffect() }
                };
            case "Lull Spd/Def":
                return new Skill("Lull Spd/Def", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(3), new DefensePenaltyEffect(3), new NeutralizeSpeedBonusEffect(), new NeutralizeDefenseBonusEffect() }
                };
            case "Lull Spd/Res":
                return new Skill("Lull Spd/Res", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(3), new ResistancePenaltyEffect(3), new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect() }
                };
            case "Lull Def/Res":
                return new Skill("Lull Def/Res", "Hybrid")
                {
                    Effects = new List<Effect> { new DefensePenaltyEffect(3), new ResistancePenaltyEffect(3), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect() }
                };
            case "Fort. Def/Res":
                return new Skill("Fort. Def/Res", "Hybrid")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6),  new AttackCostEffect(2)}
                };
            case "Life and Death":
                return new Skill("Life and Death", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseCostEffect(5), new ResistanceCostEffect(5), new SpeedBonusEffect(6) }
                };
            case "Solid Ground":
                return new Skill("Solid Ground", "Hybrid")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new AttackBonusEffect(6), new ResistanceCostEffect(5) }
                };
            case "Still Water":
                return new Skill("Still Water", "Hybrid")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(6), new AttackBonusEffect(6), new DefenseCostEffect(5) }
                };
            case "Dragonskin":
                return new Skill("DragonSkin", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6),new DefenseBonusEffect(6), new ResistanceBonusEffect(6), new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect(), new NeutralizeSpeedBonusEffect() },
                    Conditions = new List<Condition> { new OrCondition(new List<Condition> {new OpponentInitiatesCombatCondition(), new OpponentHealthAboveCondition(75)}) }
                };
            case "Light and Dark":
                return new Skill("Light and Dark", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new SpeedPenaltyEffect(5), new DefensePenaltyEffect(5), new ResistancePenaltyEffect(5), new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeAttackPenaltyEffect(), new NeutralizeDefensePenaltyEffect(), new NeutralizeResistancePenaltyEffect(), new NeutralizeSpeedPenaltyEffect() },
                 
                };
            default:
                return new Skill(skillName, "Unknown");
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