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
                var fairFightData = new SkillData("Fair Fight", "Bonus")
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
                skills.Add(new Skill(fairFightData));
                break; 
            case "HP +15":
                var hp15Data = new SkillData("HP +15", "Base Stats")
                {
                    Effects = new List<Effect> { new Max15HPBonusEffect() }
                };
                skills.Add(new Skill(hp15Data));
                break;

            case "Resolve":
                var resolveData = new SkillData("Resolve", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(7), new ResistanceBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthBelowCondition(75) }
                };
                skills.Add(new Skill(resolveData));
                break;

            case "Speed +5":
                var speed5Data = new SkillData("Speed +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5) }
                };
                skills.Add(new Skill(speed5Data));
                break;

            case "Armored Blow":
                var armoredBlowData = new SkillData("Armored Blow", "Bonus")
                {
                    Conditions = new List<Condition> { new InitiatesCombatCondition() },
                    Effects = new List<Effect> { new DefenseBonusEffect(8) }
                };
                skills.Add(new Skill(armoredBlowData));
                break;

            case "Will to Win":
                var willToWinData = new SkillData("Will to Win", "Bonus")
                {
                    Conditions = new List<Condition> { new HealthBelowCondition(50) },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
                skills.Add(new Skill(willToWinData));
                break;

            case "Single-Minded":
                var singleMindedData = new SkillData("Single-Minded", "Bonus")
                {
                    Conditions = new List<Condition> { new RecentOpponentCondition() },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
                skills.Add(new Skill(singleMindedData));
                break;

            case "Ignis":
                var ignisData = new SkillData("Ignis", "First Attack")
                {
                    Effects = new List<Effect> { new FirstAttackBonusEffect(50) }
                };
                skills.Add(new Skill(ignisData));
                break;

            case "Perceptive":
                var additionalBonusPerSpeed = new Dictionary<string, int>
                {
                    { "Bonus", 1 },
                    { "Per Speed", 4 }
                };
                var perceptiveData = new SkillData("Perceptive", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusWithAdditionalEffect(12, additionalBonusPerSpeed) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(perceptiveData));
                break;

            case "Tome Precision":
                var tomePrecisionData = new SkillData("Tome Precision", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Magic") }
                };
                skills.Add(new Skill(tomePrecisionData));
                break;

            case "Attack +6":
                var attack6Data = new SkillData("Attack +6", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) }
                };
                skills.Add(new Skill(attack6Data));
                break;

            case "Defense +5":
                var defense5Data = new SkillData("Defense +5", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(5) }
                };
                skills.Add(new Skill(defense5Data));
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
                var wrathData = new SkillData("Wrath", "Bonus")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackBonusPerHPLostEffect(0, additionalAttackBonusPerHPLost, 30), 
                        new SpeedBonusPerHPLostEffect(0, additionalSpeedBonusPerHP, 30) 
                    }
                };
                skills.Add(new Skill(wrathData));
                break;

            case "Resistance +5":
                var resistance5Data = new SkillData("Resistance +5", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(5) }
                };
                skills.Add(new Skill(resistance5Data));
                break;

            case "Atk/Def +5":
                var atkDef5Data = new SkillData("Atk/Def +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new DefenseBonusEffect(5) }
                };
                skills.Add(new Skill(atkDef5Data));
                break;

            case "Atk/Res +5":
                var atkRes5Data = new SkillData("Atk/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new ResistanceBonusEffect(5) }
                };
                skills.Add(new Skill(atkRes5Data));
                break;

            case "Spd/Res +5":
                var spdRes5Data = new SkillData("Spd/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5), new ResistanceBonusEffect(5) }
                };
                skills.Add(new Skill(spdRes5Data));
                break;

            case "Deadly Blade":
                var deadlyBladeData = new SkillData("Deadly Blade", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8), new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword"), new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(deadlyBladeData));
                break;

            case "Death Blow":
                var deathBlowData = new SkillData("Death Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(deathBlowData));
                break;

            case "Darting Blow":
                var dartingBlowData = new SkillData("Darting Blow", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(dartingBlowData));
                break;

            case "Warding Blow":
                var wardingBlowData = new SkillData("Warding Blow", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(wardingBlowData));
                break;

            case "Swift Sparrow":
                var swiftSparrowData = new SkillData("Swift Sparrow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(swiftSparrowData));
                break;

            case "Sturdy Blow":
                var sturdyBlowData = new SkillData("Sturdy Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(sturdyBlowData));
                break;

            case "Mirror Strike":
                var mirrorStrikeData = new SkillData("Mirror Strike", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(mirrorStrikeData));
                break;

            case "Steady Blow":
                var steadyBlowData = new SkillData("Steady Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(steadyBlowData));
                break;

            case "Swift Strike":
                var swiftStrikeData = new SkillData("Swift Strike", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(swiftStrikeData));
                break;

            case "Bracing Blow":
                var bracingBlowData = new SkillData("Bracing Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(bracingBlowData));
                break;

            case "Brazen Atk/Spd":
                var brazenAtkSpdData = new SkillData("Brazen Atk/Spd", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new SpeedBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add(new Skill(brazenAtkSpdData));
                break;

            case "Brazen Atk/Def":
                var brazenAtkDefData = new SkillData("Brazen Atk/Def", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add(new Skill(brazenAtkDefData));
                break;

            case "Brazen Atk/Res":
                var brazenAtkResData = new SkillData("Brazen Atk/Res", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add(new Skill(brazenAtkResData));
                break;

            case "Brazen Spd/Def":
                var brazenSpdDefData = new SkillData("Brazen Spd/Def", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add(new Skill(brazenSpdDefData));
                break;

            case "Brazen Spd/Res":
                var brazenSpdResData = new SkillData("Brazen Spd/Res", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add(new Skill(brazenSpdResData));
                break;

            case "Brazen Def/Res":
                var brazenDefResData = new SkillData("Brazen Def/Res", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.Add(new Skill(brazenDefResData));
                break;

            case "Fire Boost":
                var fireBoostData = new SkillData("Fire Boost", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.Add(new Skill(fireBoostData));
                break;

            case "Wind Boost":
                var windBoostData = new SkillData("Wind Boost", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.Add(new Skill(windBoostData));
                break;

            case "Earth Boost":
                var earthBoostData = new SkillData("Earth Boost", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.Add(new Skill(earthBoostData));
                break;

            case "Water Boost":
                var waterBoostData = new SkillData("Water Boost", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.Add(new Skill(waterBoostData));
                break;

            case "Chaos Style":
                var chaosStyleData = new SkillData("Chaos Style", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(3) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition(), new WeaponVsMagicCondition() }
                };
                skills.Add(new Skill(chaosStyleData));
                break;

            case "Blinding Flash":
                var blindingFlashData = new SkillData("Blinding Flash", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(4) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(blindingFlashData));
                break;

            case "Not *Quite*":
                var notQuiteData = new SkillData("Not *Quite*", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(4) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(notQuiteData));
                break;

            case "Stunning Smile":
                var stunningSmileData = new SkillData("Stunning Smile", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
                skills.Add(new Skill(stunningSmileData));
                break;

            case "Disarming Sigh":
                var disarmingSighData = new SkillData("Disarming Sigh", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
                skills.Add(new Skill(disarmingSighData));
                break;

            case "Charmer":
                var charmerData = new SkillData("Charmer", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(3), new AttackPenaltyEffect(3) },
                    Conditions = new List<Condition> { new RecentOpponentCondition() }
                };
                skills.Add(new Skill(charmerData));
                break;

            case "Luna":
                var lunaData = new SkillData("Luna", "First Attack")
                {
                    Effects = new List<Effect> { new FirstDefensePenaltyMinusHalfEffect(0), new FirstResistancePenaltyMinusHalfEffect(0) }
                };
                skills.Add(new Skill(lunaData));
                break;

            case "Belief in Love":
                var beliefInLoveData = new SkillData("Belief in Love", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new DefensePenaltyEffect(5) },
                    Conditions = new List<Condition> { new OrCondition(new List<Condition> { new OpponentInitiatesCombatCondition(), new OpponentFullHealthCondition() }) }
                };
                skills.Add(new Skill(beliefInLoveData));
                break;

            case "Beorc's Blessing":
                var beorcsBlessingData = new SkillData("Beorc's Blessing", "Neutralization")
                {
                    Effects = new List<Effect> { new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect() }
                };
                skills.Add(new Skill(beorcsBlessingData));
                break;


            case "Agnea's Arrow":
                var agneasArrowData = new SkillData("Agnea's Arrow", "Neutralization")
                {
                    Effects = new List<Effect> { new NeutralizeDefensePenaltyEffect(), new NeutralizeAttackPenaltyEffect(), new NeutralizeResistancePenaltyEffect(), new NeutralizeSpeedPenaltyEffect() }
                };
                skills.Add(new Skill(agneasArrowData));
                break;

            case "Soulblade":
                var soulbladeData = new SkillData("Soulblade", "Hybrid")
                {
                    Effects = new List<Effect> { new OpponentDefenseResistanceAverageEffect() },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.Add(new Skill(soulbladeData));
                break;

            case "Sandstorm":
                var sandstormData = new SkillData("Sandstorm", "Hybrid")
                {
                    Effects = new List<Effect> { new FollowUpAttackBasedOnUnitDefenseEffect() }
                };
                skills.Add(new Skill(sandstormData));
                break;

            case "Sword Agility":
                var swordAgilityData = new SkillData("Sword Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.Add(new Skill(swordAgilityData));
                break;
            
            case "Lance Power":
                var lancePowerData = new SkillData("Lance Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Lance") }
                };
                skills.Add(new Skill(lancePowerData));
                break;

            case "Sword Power":
                var swordPowerData = new SkillData("Sword Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.Add(new Skill(swordPowerData));
                break;

            case "Bow Focus":
                var bowFocusData = new SkillData("Bow Focus", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Bow") }
                };
                skills.Add(new Skill(bowFocusData));
                break;

            case "Lance Agility":
                var lanceAgilityData = new SkillData("Lance Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Lance") }
                };
                skills.Add(new Skill(lanceAgilityData));
                break;

            case "Axe Power":
                var axePowerData = new SkillData("Axe Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Axe") }
                };
                skills.Add(new Skill(axePowerData));
                break;

            case "Bow Agility":
                var bowAgilityData = new SkillData("Bow Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Bow") }
                };
                skills.Add(new Skill(bowAgilityData));
                break;

            case "Sword Focus":
                var swordFocusData = new SkillData("Sword Focus", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.Add(new Skill(swordFocusData));
                break;

            case "Close Def":
                var closeDefData = new SkillData("Close Def", "Hybrid")
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
                skills.Add(new Skill(closeDefData));
                break;

            case "Distant Def":
                var distantDefData = new SkillData("Distant Def", "Hybrid")
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
                skills.Add(new Skill(distantDefData));
                break;


           case "Lull Atk/Spd":
                var lullAtkSpdData = new SkillData("Lull Atk/Spd", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackPenaltyEffect(3), new SpeedPenaltyEffect(3), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect() 
                    }
                };
                skills.Add(new Skill(lullAtkSpdData));
                break;

            case "Lull Atk/Def":
                var lullAtkDefData = new SkillData("Lull Atk/Def", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackPenaltyEffect(3), new DefensePenaltyEffect(3), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect() 
                    }
                };
                skills.Add(new Skill(lullAtkDefData));
                break;

            case "Lull Atk/Res":
                var lullAtkResData = new SkillData("Lull Atk/Res", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackPenaltyEffect(3), new ResistancePenaltyEffect(3), 
                        new NeutralizeAttackBonusEffect(), new NeutralizeResistanceBonusEffect() 
                    }
                };
                skills.Add(new Skill(lullAtkResData));
                break;

            case "Lull Spd/Def":
                var lullSpdDefData = new SkillData("Lull Spd/Def", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new SpeedPenaltyEffect(3), new DefensePenaltyEffect(3), 
                        new NeutralizeSpeedBonusEffect(), new NeutralizeDefenseBonusEffect() 
                    }
                };
                skills.Add(new Skill(lullSpdDefData));
                break;

            case "Lull Spd/Res":
                var lullSpdResData = new SkillData("Lull Spd/Res", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new SpeedPenaltyEffect(3), new ResistancePenaltyEffect(3), 
                        new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect() 
                    }
                };
                skills.Add(new Skill(lullSpdResData));
                break;

            case "Lull Def/Res":
                var lullDefResData = new SkillData("Lull Def/Res", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new DefensePenaltyEffect(3), new ResistancePenaltyEffect(3), 
                        new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect() 
                    }
                };
                skills.Add(new Skill(lullDefResData));
                break;

            case "Fort. Def/Res":
                var fortDefResData = new SkillData("Fort. Def/Res", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new DefenseBonusEffect(6), new ResistanceBonusEffect(6), 
                        new AttackCostEffect(2) 
                    }
                };
                skills.Add(new Skill(fortDefResData));
                break;

            case "Life and Death":
                var lifeAndDeathData = new SkillData("Life and Death", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new AttackBonusEffect(6), new DefenseCostEffect(5), 
                        new ResistanceCostEffect(5), new SpeedBonusEffect(6) 
                    }
                };
                skills.Add(new Skill(lifeAndDeathData));
                break;

            case "Solid Ground":
                var solidGroundData = new SkillData("Solid Ground", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new DefenseBonusEffect(6), new AttackBonusEffect(6), 
                        new ResistanceCostEffect(5) 
                    }
                };
                skills.Add(new Skill(solidGroundData));
                break;

            case "Still Water":
                var stillWaterData = new SkillData("Still Water", "Hybrid")
                {
                    Effects = new List<Effect> 
                    { 
                        new ResistanceBonusEffect(6), new AttackBonusEffect(6), 
                        new DefenseCostEffect(5) 
                    }
                };
                skills.Add(new Skill(stillWaterData));
                break;

            case "Dragonskin":
                var dragonskinData = new SkillData("Dragonskin", "Hybrid")
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
                skills.Add(new Skill(dragonskinData));
                break;

            case "Light and Dark":
                var lightAndDarkData = new SkillData("Light and Dark", "Hybrid")
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
                skills.Add(new Skill(lightAndDarkData));
                break;

            case "Dragon Wall":
                var dragonWallData = new SkillData("Dragon Wall", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionResistanceEffect() },
                    Conditions = new List<Condition> { new ResistanceDifferenceCondition() }
                };
                skills.Add(new Skill(dragonWallData));
                break;

            case "Dodge":
                var dodgeData = new SkillData("Dodge", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition() }
                };
                skills.Add(new Skill(dodgeData));
                break;

            case "Golden Lotus":
                var goldenLotusData = new SkillData("Golden Lotus", "Damage")
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
                skills.Add(new Skill(goldenLotusData));
                break;

            case "Gentility":
                var gentilityData = new SkillData("Gentility", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) }
                };
                skills.Add(new Skill(gentilityData));
                break;

            case "Bow Guard":
                var bowGuardData = new SkillData("Bow Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Bow") }
                };
                skills.Add(new Skill(bowGuardData));
                break;

            case "Arms Shield":
                var armsShieldData = new SkillData("Arms Shield", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(7) },
                    Conditions = new List<Condition> { new AdvantageWeaponUsedCondition() }
                };
                skills.Add(new Skill(armsShieldData));
                break;

            case "Axe Guard":
                var axeGuardData = new SkillData("Axe Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Axe") }
                };
                skills.Add(new Skill(axeGuardData));
                break;

            case "Magic Guard":
                var magicGuardData = new SkillData("Magic Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Magic") }
                };
                skills.Add(new Skill(magicGuardData));
                break;

            case "Lance Guard":
                var lanceGuardData = new SkillData("Lance Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Lance") }
                };
                skills.Add(new Skill(lanceGuardData));
                break;

            case "Sympathetic":
                var sympatheticData = new SkillData("Sympathetic", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> 
                    { 
                        new OpponentInitiatesCombatCondition(), 
                        new HealthBelowCondition(50) 
                    }
                };
                skills.Add(new Skill(sympatheticData));
                break;

            case "Back at You":
                var backAtYouData = new SkillData("Back at You", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnHPLostEffect() },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(backAtYouData));
                break;

            case "Lunar Brace":
                var lunarBraceData = new SkillData("Lunar Brace", "Damage")
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
                skills.Add(new Skill(lunarBraceData));
                break;

            case "Bravery":
                var braveryData = new SkillData("Bravery", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(5) }
                };
                skills.Add(new Skill(braveryData));
                break;
            case "Bushido":
                var bushidoExtraDamageData = new SkillData("Bushido Extra Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(7) }
                };
                var bushidoReduceDamageData = new SkillData("Bushido Reduce Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions =  new List<Condition> { new SpeedDifferenceCondition() }
                };
                skills.Add(new Skill(bushidoExtraDamageData));
                skills.Add(new Skill(bushidoReduceDamageData));
                break;
            case "Moon-Twin Wing":
                var moonTwinWingPenaltyData = new SkillData("Moon-Twin Wing Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new SpeedPenaltyEffect(5)},
                    Conditions = new List<Condition> { new HealthAboveCondition(25)}
                };
                var moonTwinWingDamageData = new SkillData("Moon-Twin Wing Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions =  new List<Condition> { new SpeedDifferenceCondition() , new HealthAboveCondition(25)}
                };
                skills.Add(new Skill(moonTwinWingDamageData));
                skills.Add(new Skill(moonTwinWingPenaltyData));
                break;
            case "Blue Skies":
                var blueSkiesData = new SkillData("Blue Skies", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(5), new DamageAbsoluteReductionEffect(5) },
                };
                skills.Add(new Skill(blueSkiesData));
                break;
            case "Aegis Shield":
                var aegisShieldBonusData = new SkillData("Aegis Shield Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(3)},
                };
                var aegisShieldDamageData = new SkillData("Aegis Shield Damage", "Damage")
                {
                    Effects = new List<Effect> {new FirstAttackDamagePercentageReductionEffect(50)},

                };
                skills.Add(new Skill(aegisShieldBonusData));
                skills.Add(new Skill(aegisShieldDamageData));
                break;
            case "Remote Sparrow":
                var remoteSparrowBonusData = new SkillData("Remote Sparrow Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new SpeedBonusEffect(7) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteSparrowDamageData = new SkillData("  Remote Sparrow Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30)},
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(remoteSparrowBonusData));
                skills.Add(new Skill(remoteSparrowDamageData));
                break;
            case "Remote Mirror":
                var remoteMirrorBonusData = new SkillData("Remote Mirror Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteMirrorDamageData = new SkillData("Remote Mirror Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30)},
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(remoteMirrorBonusData));
                skills.Add(new Skill(remoteMirrorDamageData));
                break;
            case "Remote Sturdy":
                var remoteSturdyBonusData = new SkillData("Remote Sturdy Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteSturdyDamageData = new SkillData("Remote Sturdy Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30)},
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.Add(new Skill(remoteSturdyBonusData));
                skills.Add(new Skill(remoteSturdyDamageData));
                break;
            case "Fierce Stance":
                var fierceStanceBonusData = new SkillData("Fierce Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var fierceStanceDamageData = new SkillData("Fierce Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(fierceStanceBonusData));
                skills.Add(new Skill(fierceStanceDamageData));
                break;
            case "Darting Stance":
                var dartingStanceBonusData = new SkillData("Darting Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var dartingStanceDamageData = new SkillData("Darting Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(dartingStanceBonusData));
                skills.Add(new Skill(dartingStanceDamageData));
                break;
            case "Steady Stance":
                var steadyStanceBonusData = new SkillData("Steady Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(8) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var steadyStanceDamageData = new SkillData("Steady Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(steadyStanceBonusData));
                skills.Add(new Skill(steadyStanceDamageData));
                break;
            case "Warding Stance":
                var wardingStanceBonusData = new SkillData("Warding Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(8) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var wardingStanceDamageData = new SkillData("Warding Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(wardingStanceBonusData));
                skills.Add(new Skill(wardingStanceDamageData));
                break;
            case "Kestrel Stance":
                var kestrelStanceBonusData = new SkillData("Kestrel Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var kestrelStanceDamageData = new SkillData("Kestrel Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(kestrelStanceBonusData));
                skills.Add(new Skill(kestrelStanceDamageData));
                break;
            case "Sturdy Stance":
                var sturdyStanceBonusData = new SkillData("Sturdy Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var sturdyStanceDamageData = new SkillData("Sturdy Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(sturdyStanceBonusData));
                skills.Add(new Skill(sturdyStanceDamageData));
                break;
            case "Mirror Stance":
                var mirrorStanceBonusData = new SkillData("Mirror Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(6), new AttackBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var mirrorStanceDamageData = new SkillData("Mirror Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(mirrorStanceBonusData));
                skills.Add(new Skill(mirrorStanceDamageData));
                break;
            case "Steady Posture":
                var steadyPostureBonusData = new SkillData("Steady Posture Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var steadyPostureDamageData = new SkillData("Steady Posture Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(steadyPostureBonusData));
                skills.Add(new Skill(steadyPostureDamageData));
                break;
            case "Swift Stance":
                var swiftStanceBonusData = new SkillData("Swift Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var swiftStanceDamageData = new SkillData("Swift Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(swiftStanceBonusData));
                skills.Add(new Skill(swiftStanceDamageData));
                break;
            case "Bracing Stance":
                var bracingStanceBonusData = new SkillData("Bracing Stance Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var bracingStanceDamageData = new SkillData("Bracing Stance Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(10) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.Add(new Skill(bracingStanceBonusData));
                skills.Add(new Skill(bracingStanceDamageData));
                break;
            case "Poetic Justice":
                var poeticJusticePenaltyData = new SkillData("Poetic Justice Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(4)}
                };
                var poeticJusticeDamageData = new SkillData("Poetic Justice Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnOpponentAttackEffect(15) }
                };
                skills.Add(new Skill(poeticJusticePenaltyData));
                skills.Add(new Skill(poeticJusticeDamageData));
                break;
            case "Laguz Friend":
                var laguzFriendCostData = new SkillData("Laguz Friend Cost", "Hybrid")
                {
                    Effects = new List<Effect> { new DefenseCostPercentageEffect(50), new ResistanceCostPercentageEffect(50), new SelfNeutralizeResistanceEffect(), new SelfNeutralizeDefenseBonusEffect() }
                };
                var laguzFriendDamageData = new SkillData("Laguz Friend Bonus", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionEffect(50) }
                };
                skills.Add(new Skill(laguzFriendCostData));
                skills.Add(new Skill(laguzFriendDamageData));
                break;
            case "Chivalry":
                var chivalryData = new SkillData("Chivalry", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(2), new DamageAbsoluteReductionEffect(2) },
                    Conditions = new List<Condition>
                        { new InitiatesCombatCondition(), new OpponentFullHealthCondition() }
                };
                skills.Add(new Skill(chivalryData));
                break;
            case "Dragon's Wrath":
                var dragonsWrathDamageReductionData = new SkillData("Dragon's Wrath Damage Reduction", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(25) }
                };
                var dragonsWrathExtraDamageData = new SkillData("Dragon's Wrath Extra Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackExtraDamageBasedOnAttackAndOpponentResistanceDifferenceEffect(25) },
                    Conditions = new List<Condition> { new AttackAndOpponentResistanceCondition() }
                };
                skills.Add(new Skill(dragonsWrathDamageReductionData));
                skills.Add(new Skill(dragonsWrathExtraDamageData));
                break;
            case "Prescience":
                var presciencePenaltyData = new SkillData("Prescience Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new ResistancePenaltyEffect(5) },
                };
                var prescienceDamageData = new SkillData("Prescience Damage", "Damage")
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
                skills.Add(new Skill(presciencePenaltyData));
                skills.Add(new Skill(prescienceDamageData));
                break;
            case "Extra Chivalry":
                var extraChivalryPenaltyData = new SkillData("Extra Chivalry Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new DefensePenaltyEffect(5), new SpeedPenaltyEffect(5)},
                    Conditions = new List<Condition> { new OpponentHealthAboveCondition(50) }
                };
                var extraChivalryDamageData = new SkillData("Extra Chivalry Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionBasedOnOpponentHealthEffect(50) },
                };
                skills.Add(new Skill(extraChivalryPenaltyData));
                skills.Add(new Skill(extraChivalryDamageData));
                break;            
            case "Guard Bearing":
                var guardBearingPenaltyData = new SkillData("Guard Bearing Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new DefensePenaltyEffect(4), new SpeedPenaltyEffect(4)},
                };
                var guardBearingDamageData = new SkillData("Guard Bearing Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionBasedOnFirstCombatsEffect() },
                };

                skills.Add(new Skill(guardBearingPenaltyData));
                skills.Add(new Skill(guardBearingDamageData));
                break;
            case "Divine Recreation":
                var divineRecreationPenaltyData = new SkillData("Divine Recreation Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(4), new SpeedPenaltyEffect(4), new DefensePenaltyEffect(4), new ResistancePenaltyEffect(4)},
                    Conditions = new List<Condition> { new OpponentHealthAboveCondition(50) }
                };
                var divineRecreationDamageData = new SkillData("Divine Recreation Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamageDivineRecreationEffect() },
                    Conditions = new List<Condition>  { new OpponentHealthAboveCondition(50) }
                };
                skills.Add(new Skill(divineRecreationPenaltyData));
                skills.Add(new Skill(divineRecreationDamageData));
                break;
            default:
                var unknownSkillData = new SkillData(skillName, "Unknown");
                skills.Add(new Skill(unknownSkillData));
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