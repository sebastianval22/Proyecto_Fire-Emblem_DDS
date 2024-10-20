using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;
using Fire_Emblem.Skills.Effects.PenaltyEffects;
using Fire_Emblem.Skills.Effects.BonusEffects;
using Fire_Emblem.Skills.Effects.NeutralizeEffects;
using Fire_Emblem.Skills.Effects.Damage;
using Fire_Emblem.Skills.Effects.CostEffects;
using Fire_Emblem.Skills.Effects.Damage.DamageAbsoluteReduction;
using Fire_Emblem.Skills.Effects.Damage.DamagePercentageReduction;
using Fire_Emblem.Skills.Effects.HybridEffects;
using Fire_Emblem.Skills.Effects.Damage.ExtraDamage;

namespace Fire_Emblem.Skills;

public static class SkillFactory
{
    private static List<Skill> CreateSkill(string skillName)
    {
        List<Skill> skills = new();
        switch (skillName)
        { 
            case "Fair Fight":
                var fairFightSkill = new Skill("Fair Fight", "Bonus")
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
                skills.Add((fairFightSkill));
                break; 
            case "HP +15":
                var hp15Skill = new Skill("HP +15", "Base Stats")
                {
                    Effects = new List<Effect> { new Max15HPBonusEffect() }
                };
                skills.Add((hp15Skill));
                break;

            case "Resolve":
                var resolveSkill = new Skill("Resolve", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(7), new ResistanceBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthBelowCondition(75) }
                };
                skills.Add((resolveSkill));
                break;

            case "Speed +5":
                var speed5Skill = new Skill("Speed +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5) }
                };
                skills.Add((speed5Skill));
                break;

            case "Armored Blow":
                var armoredBlowSkill = new Skill("Armored Blow", "Bonus")
                {
                    Conditions = new List<Condition> { new InitiatesCombatCondition() },
                    Effects = new List<Effect> { new DefenseBonusEffect(8) }
                };
                skills.Add((armoredBlowSkill));
                break;

            case "Will to Win":
                var willToWinSkill = new Skill("Will to Win", "Bonus")
                {
                    Conditions = new List<Condition> { new HealthBelowCondition(50) },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
                skills.Add((willToWinSkill));
                break;

            case "Single-Minded":
                var singleMindedSkill = new Skill("Single-Minded", "Bonus")
                {
                    Conditions = new List<Condition> { new RecentOpponentCondition() },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
                skills.Add((singleMindedSkill));
                break;

            case "Ignis":
                var ignisSkill = new Skill("Ignis", "First Attack")
                {
                    Effects = new List<Effect> { new FirstAttackBonusEffect(50) }
                };
                skills.Add((ignisSkill));
                break;

            case "Perceptive":
                var additionalBonusPerSpeed = new Dictionary<string, int>
                {
                    { "Bonus", 1 },
                    { "Per Speed", 4 }
                };
                var perceptiveSkill = new Skill("Perceptive", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusWithAdditionalEffect(12, additionalBonusPerSpeed) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((perceptiveSkill));
                break;

            case "Tome Precision":
                var tomePrecisionSkill = new Skill("Tome Precision", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Magic") }
                };
                skills.Add((tomePrecisionSkill));
                break;

            case "Attack +6":
                var attack6Skill = new Skill("Attack +6", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) }
                };
                skills.Add((attack6Skill));
                break;

            case "Defense +5":
                var defense5Skill = new Skill("Defense +5", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(5) }
                };
                skills.Add((defense5Skill));
                break;

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
                var wrathSkill = new Skill("Wrath", "Bonus")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackBonusPerHPLostEffect(0, additionalAttackBonusPerHPLost, 30), 
                        new SpeedBonusPerHPLostEffect(0, additionalSpeedBonusPerHP, 30) 
                    }
                };
                skills.Add((wrathSkill));
                break;

            case "Resistance +5":
                var resistance5Skill = new Skill("Resistance +5", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(5) }
                };
                skills.Add((resistance5Skill));
                break;

            case "Atk/Def +5":
                var atkDef5Skill = new Skill("Atk/Def +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new DefenseBonusEffect(5) }
                };
                skills.Add((atkDef5Skill));
                break;

            case "Atk/Res +5":
                var atkRes5Skill = new Skill("Atk/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new ResistanceBonusEffect(5) }
                };
                skills.Add((atkRes5Skill));
                break;

            case "Spd/Res +5":
                var spdRes5Skill = new Skill("Spd/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5), new ResistanceBonusEffect(5) }
                };
                skills.Add((spdRes5Skill));
                break;

            case "Deadly Blade":
                var deadlyBladeSkill = new Skill("Deadly Blade", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8), new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword"), new InitiatesCombatCondition() }
                };
                skills.Add((deadlyBladeSkill));
                break;

            case "Death Blow":
                var deathBlowSkill = new Skill("Death Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((deathBlowSkill));
                break;

            case "Darting Blow":
                var dartingBlowSkill = new Skill("Darting Blow", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((dartingBlowSkill));
                break;

            case "Warding Blow":
                var wardingBlowSkill = new Skill("Warding Blow", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((wardingBlowSkill));
                break;

            case "Swift Sparrow":
                var swiftSparrowSkill = new Skill("Swift Sparrow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((swiftSparrowSkill));
                break;

            case "Sturdy Blow":
                var sturdyBlowSkill = new Skill("Sturdy Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((sturdyBlowSkill));
                break;

            case "Mirror Strike":
                var mirrorStrikeSkill = new Skill("Mirror Strike", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((mirrorStrikeSkill));
                break;

            case "Steady Blow":
                var steadyBlowSkill = new Skill("Steady Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((steadyBlowSkill));
                break;

            case "Swift Strike":
                var swiftStrikeSkill = new Skill("Swift Strike", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((swiftStrikeSkill));
                break;

            case "Bracing Blow":
                var bracingBlowSkill = new Skill("Bracing Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((bracingBlowSkill));
                break;

            case "Brazen Atk/Spd":
                var brazenAtkSpdSkill = new Skill("Brazen Atk/Spd", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new SpeedBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add((brazenAtkSpdSkill));
                break;

            case "Brazen Atk/Def":
                var brazenAtkDefSkill = new Skill("Brazen Atk/Def", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add((brazenAtkDefSkill));
                break;

            case "Brazen Atk/Res":
                var brazenAtkResSkill = new Skill("Brazen Atk/Res", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add((brazenAtkResSkill));
                break;

            case "Brazen Spd/Def":
                var brazenSpdDefSkill = new Skill("Brazen Spd/Def", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add((brazenSpdDefSkill));
                break;

            case "Brazen Spd/Res":
                var brazenSpdResSkill = new Skill("Brazen Spd/Res", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add((brazenSpdResSkill));
                break;

            case "Brazen Def/Res":
                var brazenDefResSkill = new Skill("Brazen Def/Res", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add((brazenDefResSkill));
                break;

            case "Fire Boost":
                var fireBoostSkill = new Skill("Fire Boost", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.Add((fireBoostSkill));
                break;

            case "Wind Boost":
                var windBoostSkill = new Skill("Wind Boost", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.Add((windBoostSkill));
                break;

            case "Earth Boost":
                var earthBoostSkill = new Skill("Earth Boost", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.Add((earthBoostSkill));
                break;

            case "Water Boost":
                var waterBoostSkill = new Skill("Water Boost", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.Add((waterBoostSkill));
                break;

            case "Chaos Style":
                var chaosStyleSkill = new Skill("Chaos Style", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(3) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition(), new WeaponVsMagicCondition() }
                };
                skills.Add((chaosStyleSkill));
                break;

            case "Blinding Flash":
                var blindingFlashSkill = new Skill("Blinding Flash", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(4) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((blindingFlashSkill));
                break;

            case "Not *Quite*":
                var notQuiteSkill = new Skill("Not *Quite*", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(4) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((notQuiteSkill));
                break;

            case "Stunning Smile":
                var stunningSmileSkill = new Skill("Stunning Smile", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
                skills.Add((stunningSmileSkill));
                break;

            case "Disarming Sigh":
                var disarmingSighSkill = new Skill("Disarming Sigh", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
                skills.Add((disarmingSighSkill));
                break;

            case "Charmer":
                var charmerSkill = new Skill("Charmer", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(3), new AttackPenaltyEffect(3) },
                    Conditions = new List<Condition> { new RecentOpponentCondition() }
                };
                skills.Add((charmerSkill));
                break;

            case "Luna":
                var lunaSkill = new Skill("Luna", "First Attack")
                {
                    Effects = new List<Effect> { new FirstDefensePenaltyMinusHalfEffect(0), new FirstResistancePenaltyMinusHalfEffect(0) }
                };
                skills.Add((lunaSkill));
                break;

            case "Belief in Love":
                var beliefInLoveSkill = new Skill("Belief in Love", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new DefensePenaltyEffect(5) },
                    Conditions = new List<Condition> { new OrCondition(new List<Condition> { new OpponentInitiatesCombatCondition(), new OpponentFullHealthCondition() }) }
                };
                skills.Add((beliefInLoveSkill));
                break;

            case "Beorc's Blessing":
                var beorcsBlessingSkill = new Skill("Beorc's Blessing", "Neutralization")
                {
                    Effects = new List<Effect> { new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect() }
                };
                skills.Add((beorcsBlessingSkill));
                break;


            case "Agnea's Arrow":
                var agneasArrowSkill = new Skill("Agnea's Arrow", "Neutralization")
                {
                    Effects = new List<Effect> { new NeutralizeDefensePenaltyEffect(), new NeutralizeAttackPenaltyEffect(), new NeutralizeResistancePenaltyEffect(), new NeutralizeSpeedPenaltyEffect() }
                };
                skills.Add((agneasArrowSkill));
                break;

            case "Soulblade":
                var soulbladeSkill = new Skill("Soulblade", "Hybrid")
                {
                    Effects = new List<Effect> { new OpponentDefenseResistanceAverageEffect() },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.Add((soulbladeSkill));
                break;

            case "Sandstorm":
                var sandstormSkill = new Skill("Sandstorm", "Hybrid")
                {
                    Effects = new List<Effect> { new FollowUpAttackBasedOnUnitDefenseEffect() }
                };
                skills.Add((sandstormSkill));
                break;

            case "Sword Agility":
                var swordAgilitySkill = new Skill("Sword Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.Add((swordAgilitySkill));
                break;
            
            case "Lance Power":
                var lancePowerSkill = new Skill("Lance Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Lance") }
                };
                skills.Add((lancePowerSkill));
                break;

            case "Sword Power":
                var swordPowerSkill = new Skill("Sword Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.Add((swordPowerSkill));
                break;

            case "Bow Focus":
                var bowFocusSkill = new Skill("Bow Focus", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Bow") }
                };
                skills.Add((bowFocusSkill));
                break;

            case "Lance Agility":
                var lanceAgilitySkill = new Skill("Lance Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Lance") }
                };
                skills.Add((lanceAgilitySkill));
                break;

            case "Axe Power":
                var axePowerSkill = new Skill("Axe Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Axe") }
                };
                skills.Add((axePowerSkill));
                break;

            case "Bow Agility":
                var bowAgilitySkill = new Skill("Bow Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Bow") }
                };
                skills.Add((bowAgilitySkill));
                break;

            case "Sword Focus":
                var swordFocusSkill = new Skill("Sword Focus", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.Add((swordFocusSkill));
                break;

            case "Close Def":
                var closeDefSkill = new Skill("Close Def", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new DefenseBonusEffect(8), new ResistanceBonusEffect(8),
                        new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect(),
                        new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect()
                    },
                    Conditions = new List<Condition> 
                    { 
                        new OpponentInitiatesCombatCondition(), 
                        new OrCondition(new List<Condition> 
                        { 
                            new OpponentWeaponUsedCondition("Sword"), 
                            new OpponentWeaponUsedCondition("Lance"), 
                            new OpponentWeaponUsedCondition("Axe") 
                        }) 
                    }
                };
                skills.Add((closeDefSkill));
                break;

            case "Distant Def":
                var distantDefSkill = new Skill("Distant Def", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new DefenseBonusEffect(8), new ResistanceBonusEffect(8), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect(),
                        new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect()
                    },
                    Conditions = new List<Condition> 
                    { 
                        new OpponentInitiatesCombatCondition(), 
                        new OrCondition(new List<Condition> 
                        { 
                            new OpponentWeaponUsedCondition("Magic"), 
                            new OpponentWeaponUsedCondition("Bow") 
                        }) 
                    }
                };
                skills.Add((distantDefSkill));
                break;


           case "Lull Atk/Spd":
                var lullAtkSpdSkill = new Skill("Lull Atk/Spd", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackPenaltyEffect(3), new SpeedPenaltyEffect(3), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect() 
                    }
                };
                skills.Add((lullAtkSpdSkill));
                break;

            case "Lull Atk/Def":
                var lullAtkDefSkill = new Skill("Lull Atk/Def", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackPenaltyEffect(3), new DefensePenaltyEffect(3), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect() 
                    }
                };
                skills.Add((lullAtkDefSkill));
                break;

            case "Lull Atk/Res":
                var lullAtkResSkill = new Skill("Lull Atk/Res", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackPenaltyEffect(3), new ResistancePenaltyEffect(3), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeResistanceBonusEffect() 
                    }
                };
                skills.Add((lullAtkResSkill));
                break;

            case "Lull Spd/Def":
                var lullSpdDefSkill = new Skill("Lull Spd/Def", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new SpeedPenaltyEffect(3), new DefensePenaltyEffect(3), 
                        new NeutralizeSpeedBonusEffect(), new NeutralizeDefenseBonusEffect() 
                    }
                };
                skills.Add((lullSpdDefSkill));
                break;

            case "Lull Spd/Res":
                var lullSpdResSkill = new Skill("Lull Spd/Res", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new SpeedPenaltyEffect(3), new ResistancePenaltyEffect(3), 
                        new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect() 
                    }
                };
                skills.Add((lullSpdResSkill));
                break;

            case "Lull Def/Res":
                var lullDefResSkill = new Skill("Lull Def/Res", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new DefensePenaltyEffect(3), new ResistancePenaltyEffect(3), 
                        new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect() 
                    }
                };
                skills.Add((lullDefResSkill));
                break;

            case "Fort. Def/Res":
                var fortDefResSkill = new Skill("Fort. Def/Res", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new DefenseBonusEffect(6), new ResistanceBonusEffect(6), 
                        new AttackCostEffect(2) 
                    }
                };
                skills.Add((fortDefResSkill));
                break;

            case "Life and Death":
                var lifeAndDeathSkill = new Skill("Life and Death", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackBonusEffect(6), new DefenseCostEffect(5), 
                        new ResistanceCostEffect(5), new SpeedBonusEffect(6) 
                    }
                };
                skills.Add((lifeAndDeathSkill));
                break;

            case "Solid Ground":
                var solidGroundSkill = new Skill("Solid Ground", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new DefenseBonusEffect(6), new AttackBonusEffect(6), 
                        new ResistanceCostEffect(5) 
                    }
                };
                skills.Add((solidGroundSkill));
                break;

            case "Still Water":
                var stillWaterSkill = new Skill("Still Water", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new ResistanceBonusEffect(6), new AttackBonusEffect(6), 
                        new DefenseCostEffect(5) 
                    }
                };
                skills.Add((stillWaterSkill));
                break;

            case "Dragonskin":
                var dragonskinSkill = new Skill("Dragonskin", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackBonusEffect(6), new SpeedBonusEffect(6), 
                        new DefenseBonusEffect(6), new ResistanceBonusEffect(6), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), 
                        new NeutralizeResistanceBonusEffect(), new NeutralizeSpeedBonusEffect() 
                    },
                    Conditions = new List<Condition> 
                    { 
                        new OrCondition(new List<Condition> 
                        { 
                            new OpponentInitiatesCombatCondition(), 
                            new OpponentHealthAboveCondition(75) 
                        }) 
                    }
                };
                skills.Add((dragonskinSkill));
                break;

            case "Light and Dark":
                var lightAndDarkSkill = new Skill("Light and Dark", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackPenaltyEffect(5), new SpeedPenaltyEffect(5), 
                        new DefensePenaltyEffect(5), new ResistancePenaltyEffect(5), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), 
                        new NeutralizeResistanceBonusEffect(), new NeutralizeSpeedBonusEffect(), 
                        new NeutralizeAttackPenaltyEffect(), new NeutralizeDefensePenaltyEffect(), 
                        new NeutralizeResistancePenaltyEffect(), new NeutralizeSpeedPenaltyEffect() 
                    }
                };
                skills.Add((lightAndDarkSkill));
                break;

            case "Dragon Wall":
                var dragonWallSkill = new Skill("Dragon Wall", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionResistanceEffect() },
                    Conditions = new List<Condition> { new ResistanceDifferenceCondition() }
                };
                skills.Add((dragonWallSkill));
                break;

            case "Dodge":
                var dodgeSkill = new Skill("Dodge", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition() }
                };
                skills.Add((dodgeSkill));
                break;

            case "Golden Lotus":
                var goldenLotusSkill = new Skill("Golden Lotus", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(50) },
                    Conditions = new List<Condition> 
                    { 
                        new OrCondition(new List<Condition> 
                        { 
                            new OpponentWeaponUsedCondition("Sword"), 
                            new OpponentWeaponUsedCondition("Lance"), 
                            new OpponentWeaponUsedCondition("Axe"), 
                            new OpponentWeaponUsedCondition("Bow") 
                        }) 
                    }
                };
                skills.Add((goldenLotusSkill));
                break;

            case "Gentility":
                var gentilitySkill = new Skill("Gentility", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) }
                };
                skills.Add((gentilitySkill));
                break;

            case "Bow Guard":
                var bowGuardSkill = new Skill("Bow Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Bow") }
                };
                skills.Add((bowGuardSkill));
                break;

            case "Arms Shield":
                var armsShieldSkill = new Skill("Arms Shield", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(7) },
                    Conditions = new List<Condition> { new AdvantageWeaponUsedCondition() }
                };
                skills.Add((armsShieldSkill));
                break;

            case "Axe Guard":
                var axeGuardSkill = new Skill("Axe Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Axe") }
                };
                skills.Add((axeGuardSkill));
                break;

            case "Magic Guard":
                var magicGuardSkill = new Skill("Magic Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Magic") }
                };
                skills.Add((magicGuardSkill));
                break;

            case "Lance Guard":
                var lanceGuardSkill = new Skill("Lance Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Lance") }
                };
                skills.Add((lanceGuardSkill));
                break;

            case "Sympathetic":
                var sympatheticSkill = new Skill("Sympathetic", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> 
                    { 
                        new OpponentInitiatesCombatCondition(), 
                        new HealthBelowCondition(50) 
                    }
                };
                skills.Add((sympatheticSkill));
                break;

            case "Back at You":
                var backAtYouSkill = new Skill("Back at You", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnHPLostEffect() },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((backAtYouSkill));
                break;

            case "Lunar Brace":
                var lunarBraceSkill = new Skill("Lunar Brace", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnOpponentDefenseEffect(30) },
                    Conditions = new List<Condition> 
                    { 
                        new InitiatesCombatCondition(), 
                        new OrCondition(new List<Condition> 
                        { 
                            new WeaponUsedCondition("Sword"), 
                            new WeaponUsedCondition("Lance"), 
                            new WeaponUsedCondition("Axe"), 
                            new WeaponUsedCondition("Bow") 
                        }) 
                    }
                };
                skills.Add((lunarBraceSkill));
                break;

            case "Bravery":
                var braverySkill = new Skill("Bravery", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(5) }
                };
                skills.Add((braverySkill));
                break;
            case "Bushido":
                var bushidoExtraDamageSkill = new Skill("Bushido Extra Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(7) }
                };
                var bushidoReduceDamageSkill = new Skill("Bushido Reduce Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions =  new List<Condition> { new SpeedDifferenceCondition() }
                };
                skills.Add((bushidoExtraDamageSkill));
                skills.Add((bushidoReduceDamageSkill));
                break;
            case "Moon-Twin Wing":
                var moonTwinWingPenaltySkill = new Skill("Moon-Twin Wing Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new SpeedPenaltyEffect(5)},
                    Conditions = new List<Condition> { new HealthAboveCondition(25)}
                };
                var moonTwinWingDamageSkill = new Skill("Moon-Twin Wing Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions =  new List<Condition> { new SpeedDifferenceCondition() , new HealthAboveCondition(25)}
                };
                skills.Add((moonTwinWingDamageSkill));
                skills.Add((moonTwinWingPenaltySkill));
                break;
            case "Blue Skies":
                var blueSkiesSkill = new Skill("Blue Skies", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(5), new DamageAbsoluteReductionEffect(5) },
                };
                skills.Add((blueSkiesSkill));
                break;
            case "Aegis Shield":
                var aegisShieldBonusSkill = new Skill("Aegis Shield Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(3)},
                };
                var aegisShieldDamageSkill = new Skill("Aegis Shield Damage", "Damage")
                {
                    Effects = new List<Effect> {new FirstAttackDamagePercentageReductionEffect(50)},

                };
                skills.Add((aegisShieldBonusSkill));
                skills.Add((aegisShieldDamageSkill));
                break;
            case "Remote Sparrow":
                var remoteSparrowBonusSkill = new Skill("Remote Sparrow Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new SpeedBonusEffect(7) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteSparrowDamageSkill = new Skill("  Remote Sparrow Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30)},
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((remoteSparrowBonusSkill));
                skills.Add((remoteSparrowDamageSkill));
                break;
            case "Remote Mirror":
                var remoteMirrorBonusSkill = new Skill("Remote Mirror Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteMirrorDamageSkill = new Skill("Remote Mirror Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30)},
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((remoteMirrorBonusSkill));
                skills.Add((remoteMirrorDamageSkill));
                break;
            case "Remote Sturdy":
                var remoteSturdyBonusSkill = new Skill("Remote Sturdy Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteSturdyDamageSkill = new Skill("Remote Sturdy Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30)},
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add((remoteSturdyBonusSkill));
                skills.Add((remoteSturdyDamageSkill));
                break;
            case "Fierce Stance":
                var fierceStanceBonusSkill = new Skill("Fierce Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var fierceStanceDamageSkill = new Skill("Fierce Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((fierceStanceBonusSkill));
                skills.Add((fierceStanceDamageSkill));
                break;
            case "Darting Stance":
                var dartingStanceBonusSkill = new Skill("Darting Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var dartingStanceDamageSkill = new Skill("Darting Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((dartingStanceBonusSkill));
                skills.Add((dartingStanceDamageSkill));
                break;
            case "Steady Stance":
                var steadyStanceBonusSkill = new Skill("Steady Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(8) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var steadyStanceDamageSkill = new Skill("Steady Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((steadyStanceBonusSkill));
                skills.Add((steadyStanceDamageSkill));
                break;
            case "Warding Stance":
                var wardingStanceBonusSkill = new Skill("Warding Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(8) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var wardingStanceDamageSkill = new Skill("Warding Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((wardingStanceBonusSkill));
                skills.Add((wardingStanceDamageSkill));
                break;
            case "Kestrel Stance":
                var kestrelStanceBonusSkill = new Skill("Kestrel Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var kestrelStanceDamageSkill = new Skill("Kestrel Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((kestrelStanceBonusSkill));
                skills.Add((kestrelStanceDamageSkill));
                break;
            case "Sturdy Stance":
                var sturdyStanceBonusSkill = new Skill("Sturdy Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var sturdyStanceDamageSkill = new Skill("Sturdy Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((sturdyStanceBonusSkill));
                skills.Add((sturdyStanceDamageSkill));
                break;
            case "Mirror Stance":
                var mirrorStanceBonusSkill = new Skill("Mirror Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(6), new AttackBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var mirrorStanceDamageSkill = new Skill("Mirror Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((mirrorStanceBonusSkill));
                skills.Add((mirrorStanceDamageSkill));
                break;
            case "Steady Posture":
                var steadyPostureBonusSkill = new Skill("Steady Posture Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var steadyPostureDamageSkill = new Skill("Steady Posture Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((steadyPostureBonusSkill));
                skills.Add((steadyPostureDamageSkill));
                break;
            case "Swift Stance":
                var swiftStanceBonusSkill = new Skill("Swift Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var swiftStanceDamageSkill = new Skill("Swift Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((swiftStanceBonusSkill));
                skills.Add((swiftStanceDamageSkill));
                break;
            case "Bracing Stance":
                var bracingStanceBonusSkill = new Skill("Bracing Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var bracingStanceDamageSkill = new Skill("Bracing Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add((bracingStanceBonusSkill));
                skills.Add((bracingStanceDamageSkill));
                break;
            case "Poetic Justice":
                var poeticJusticePenaltySkill = new Skill("Poetic Justice Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(4)}
                };
                var poeticJusticeDamageSkill = new Skill("Poetic Justice Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnOpponentAttackEffect(15) }
                };
                skills.Add((poeticJusticePenaltySkill));
                skills.Add((poeticJusticeDamageSkill));
                break;
            case "Laguz Friend":
                var laguzFriendCostSkill = new Skill("Laguz Friend Cost", "Hybrid")
                {
                    Effects = new List<Effect> { new DefenseCostPercentageEffect(50), new ResistanceCostPercentageEffect(50), new SelfNeutralizeResistanceEffect(), new SelfNeutralizeDefenseBonusEffect() }
                };
                var laguzFriendDamageSkill = new Skill("Laguz Friend Bonus", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionEffect(50) }
                };
                skills.Add((laguzFriendCostSkill));
                skills.Add((laguzFriendDamageSkill));
                break;
            case "Chivalry":
                var chivalrySkill = new Skill("Chivalry", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(2), new DamageAbsoluteReductionEffect(2) },
                    Conditions = new List<Condition>
                        { new InitiatesCombatCondition(), new OpponentFullHealthCondition() }
                };
                skills.Add((chivalrySkill));
                break;
            case "Dragon's Wrath":
                var dragonsWrathDamageReductionSkill = new Skill("Dragon's Wrath Damage Reduction", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(25) }
                };
                var dragonsWrathExtraDamageSkill = new Skill("Dragon's Wrath Extra Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackExtraDamageBasedOnAttackAndOpponentResistanceDifferenceEffect(25) },
                    Conditions = new List<Condition> { new AttackAndOpponentResistanceCondition() }
                };
                skills.Add((dragonsWrathDamageReductionSkill));
                skills.Add((dragonsWrathExtraDamageSkill));
                break;
            case "Prescience":
                var presciencePenaltySkill = new Skill("Prescience Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new ResistancePenaltyEffect(5) },
                };
                var prescienceDamageSkill = new Skill("Prescience Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30) },
                    Conditions = new List<Condition>
                    {
                        new OrCondition(new List<Condition>
                        {
                            new InitiatesCombatCondition(),
                            new OrCondition(new List<Condition>
                            {
                                new OpponentWeaponUsedCondition("Magic"),
                                new OpponentWeaponUsedCondition("Bow")
                            })
                        })
                    }
                };
                skills.Add((presciencePenaltySkill));
                skills.Add((prescienceDamageSkill));
                break;
            case "Extra Chivalry":
                var extraChivalryPenaltySkill = new Skill("Extra Chivalry Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new DefensePenaltyEffect(5), new SpeedPenaltyEffect(5)},
                    Conditions = new List<Condition> { new OpponentHealthAboveCondition(50) }
                };
                var extraChivalryDamageSkill = new Skill("Extra Chivalry Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionBasedOnOpponentHealthEffect(50) },
                };
                skills.Add((extraChivalryPenaltySkill));
                skills.Add((extraChivalryDamageSkill));
                break;            
            case "Guard Bearing":
                var guardBearingPenaltySkill = new Skill("Guard Bearing Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new DefensePenaltyEffect(4), new SpeedPenaltyEffect(4)},
                };
                var guardBearingDamageSkill = new Skill("Guard Bearing Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionBasedOnFirstCombatsEffect() },
                };

                skills.Add((guardBearingPenaltySkill));
                skills.Add((guardBearingDamageSkill));
                break;
            case "Divine Recreation":
                var divineRecreationPenaltySkill = new Skill("Divine Recreation Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(4), new SpeedPenaltyEffect(4), new DefensePenaltyEffect(4), new ResistancePenaltyEffect(4)},
                    Conditions = new List<Condition> { new OpponentHealthAboveCondition(50) }
                };
                var divineRecreationDamageSkill = new Skill("Divine Recreation Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamageDivineRecreationEffect() },
                    Conditions = new List<Condition>  { new OpponentHealthAboveCondition(50) }
                };
                skills.Add((divineRecreationPenaltySkill));
                skills.Add((divineRecreationDamageSkill));
                break;
            default:
                var unknownSkill = new Skill(skillName, "Unknown");
                skills.Add((unknownSkill));
                break;
                
            
        }
        return skills;
    }


    public static List<Skill> InitiateSkills(List<string> skillNames)
    {
        List<Skill> skills = new();
        foreach (var skillName in skillNames)
        {
            AddSkills(skills, skillName);
        }
        return skills;
    }

    private static void AddSkills(List<Skill> skills, string skillName)
    {
        List<Skill> createdSkills = CreateSkill(skillName);
        skills.AddRange(createdSkills);
    }
    }