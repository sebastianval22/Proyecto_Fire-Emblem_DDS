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
                return new Skill(fairFightData);
                        case "HP +15":
                var hp15Data = new SkillData("HP +15", "Base Stats")
                {
                    Effects = new List<Effect> { new Max15HPBonusEffect() }
                };
                return new Skill(hp15Data);

            case "Resolve":
                var resolveData = new SkillData("Resolve", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(7), new ResistanceBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthBelowCondition(75) }
                };
                return new Skill(resolveData);

            case "Speed +5":
                var speed5Data = new SkillData("Speed +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5) }
                };
                return new Skill(speed5Data);

            case "Armored Blow":
                var armoredBlowData = new SkillData("Armored Blow", "Bonus")
                {
                    Conditions = new List<Condition> { new InitiatesCombatCondition() },
                    Effects = new List<Effect> { new DefenseBonusEffect(8) }
                };
                return new Skill(armoredBlowData);

            case "Will to Win":
                var willToWinData = new SkillData("Will to Win", "Bonus")
                {
                    Conditions = new List<Condition> { new HealthBelowCondition(50) },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
                return new Skill(willToWinData);

            case "Single-Minded":
                var singleMindedData = new SkillData("Single-Minded", "Bonus")
                {
                    Conditions = new List<Condition> { new RecentOpponentCondition() },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
                return new Skill(singleMindedData);

            case "Ignis":
                var ignisData = new SkillData("Ignis", "First Attack")
                {
                    Effects = new List<Effect> { new FirstAttackBonusEffect(50) }
                };
                return new Skill(ignisData);

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
                return new Skill(perceptiveData);

            case "Tome Precision":
                var tomePrecisionData = new SkillData("Tome Precision", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Magic") }
                };
                return new Skill(tomePrecisionData);

            case "Attack +6":
                var attack6Data = new SkillData("Attack +6", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) }
                };
                return new Skill(attack6Data);

            case "Defense +5":
                var defense5Data = new SkillData("Defense +5", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(5) }
                };
                return new Skill(defense5Data);

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
                return new Skill(wrathData);

            case "Resistance +5":
                var resistance5Data = new SkillData("Resistance +5", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(5) }
                };
                return new Skill(resistance5Data);

            case "Atk/Def +5":
                var atkDef5Data = new SkillData("Atk/Def +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new DefenseBonusEffect(5) }
                };
                return new Skill(atkDef5Data);

            case "Atk/Res +5":
                var atkRes5Data = new SkillData("Atk/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new ResistanceBonusEffect(5) }
                };
                return new Skill(atkRes5Data);

            case "Spd/Res +5":
                var spdRes5Data = new SkillData("Spd/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5), new ResistanceBonusEffect(5) }
                };
                return new Skill(spdRes5Data);

            case "Deadly Blade":
                var deadlyBladeData = new SkillData("Deadly Blade", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8), new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword"), new InitiatesCombatCondition() }
                };
                return new Skill(deadlyBladeData);

            case "Death Blow":
                var deathBlowData = new SkillData("Death Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(deathBlowData);

            case "Darting Blow":
                var dartingBlowData = new SkillData("Darting Blow", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(dartingBlowData);
             case "Warding Blow":
                var wardingBlowData = new SkillData("Warding Blow", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(wardingBlowData);

            case "Swift Sparrow":
                var swiftSparrowData = new SkillData("Swift Sparrow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(swiftSparrowData);

            case "Sturdy Blow":
                var sturdyBlowData = new SkillData("Sturdy Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(sturdyBlowData);

            case "Mirror Strike":
                var mirrorStrikeData = new SkillData("Mirror Strike", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(mirrorStrikeData);

            case "Steady Blow":
                var steadyBlowData = new SkillData("Steady Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(steadyBlowData);

            case "Swift Strike":
                var swiftStrikeData = new SkillData("Swift Strike", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(swiftStrikeData);

            case "Bracing Blow":
                var bracingBlowData = new SkillData("Bracing Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(bracingBlowData);

            case "Brazen Atk/Spd":
                var brazenAtkSpdData = new SkillData("Brazen Atk/Spd", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new SpeedBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                return new Skill(brazenAtkSpdData);

            case "Brazen Atk/Def":
                var brazenAtkDefData = new SkillData("Brazen Atk/Def", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                return new Skill(brazenAtkDefData);

            case "Brazen Atk/Res":
                var brazenAtkResData = new SkillData("Brazen Atk/Res", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                return new Skill(brazenAtkResData);

            case "Brazen Spd/Def":
                var brazenSpdDefData = new SkillData("Brazen Spd/Def", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                return new Skill(brazenSpdDefData);

            case "Brazen Spd/Res":
                var brazenSpdResData = new SkillData("Brazen Spd/Res", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                return new Skill(brazenSpdResData);

            case "Brazen Def/Res":
                var brazenDefResData = new SkillData("Brazen Def/Res", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                return new Skill(brazenDefResData);

            case "Fire Boost":
                var fireBoostData = new SkillData("Fire Boost", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                return new Skill(fireBoostData);

            case "Wind Boost":
                var windBoostData = new SkillData("Wind Boost", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                return new Skill(windBoostData);

            case "Earth Boost":
                var earthBoostData = new SkillData("Earth Boost", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                return new Skill(earthBoostData);

            case "Water Boost":
                var waterBoostData = new SkillData("Water Boost", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                return new Skill(waterBoostData);

            case "Chaos Style":
                var chaosStyleData = new SkillData("Chaos Style", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(3) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition(), new WeaponVsMagicCondition() }
                };
                return new Skill(chaosStyleData);

            case "Blinding Flash":
                var blindingFlashData = new SkillData("Blinding Flash", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(4) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                return new Skill(blindingFlashData);

            case "Not *Quite*":
                var notQuiteData = new SkillData("Not *Quite*", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(4) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                return new Skill(notQuiteData);

            case "Stunning Smile":
                var stunningSmileData = new SkillData("Stunning Smile", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
                return new Skill(stunningSmileData);

            case "Disarming Sigh":
                var disarmingSighData = new SkillData("Disarming Sigh", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
                return new Skill(disarmingSighData);

            case "Charmer":
                var charmerData = new SkillData("Charmer", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(3), new AttackPenaltyEffect(3) },
                    Conditions = new List<Condition> { new RecentOpponentCondition() }
                };
                return new Skill(charmerData);

            case "Luna":
                var lunaData = new SkillData("Luna", "First Attack")
                {
                    Effects = new List<Effect> { new FirstDefensePenaltyMinusHalfEffect(0), new FirstResistancePenaltyMinusHalfEffect(0) }
                };
                return new Skill(lunaData);

            case "Belief in Love":
                var beliefInLoveData = new SkillData("Belief in Love", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new DefensePenaltyEffect(5) },
                    Conditions = new List<Condition> { new OrCondition(new List<Condition> { new OpponentInitiatesCombatCondition(), new OpponentFullHealthCondition() }) }
                };
                return new Skill(beliefInLoveData);

            case "Beorc's Blessing":
                var beorcsBlessingData = new SkillData("Beorc's Blessing", "Neutralization")
                {
                    Effects = new List<Effect> { new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect() }
                };
                return new Skill(beorcsBlessingData);

            case "Agnea's Arrow":
                var agneasArrowData = new SkillData("Agnea's Arrow", "Neutralization")
                {
                    Effects = new List<Effect> { new NeutralizeDefensePenaltyEffect(), new NeutralizeAttackPenaltyEffect(), new NeutralizeResistancePenaltyEffect(), new NeutralizeSpeedPenaltyEffect() }
                };
                return new Skill(agneasArrowData);

            case "Soulblade":
                var soulbladeData = new SkillData("Soulblade", "Hybrid")
                {
                    Effects = new List<Effect> { new OpponentDefenseResistanceAverageEffect() },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                return new Skill(soulbladeData);

            case "Sandstorm":
                var sandstormData = new SkillData("Sandstorm", "Hybrid")
                {
                    Effects = new List<Effect> { new FollowUpAttackBasedOnUnitDefenseEffect() }
                };
                return new Skill(sandstormData);

            case "Sword Agility":
                var swordAgilityData = new SkillData("Sword Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                return new Skill(swordAgilityData);
                        case "Lance Power":
                var lancePowerData = new SkillData("Lance Power", "Hybrid");
                lancePowerData.Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) };
                lancePowerData.Conditions = new List<Condition> { new WeaponUsedCondition("Lance") };
                return new Skill(lancePowerData);

            case "Sword Power":
                var swordPowerData = new SkillData("Sword Power", "Hybrid");
                swordPowerData.Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) };
                swordPowerData.Conditions = new List<Condition> { new WeaponUsedCondition("Sword") };
                return new Skill(swordPowerData);

            case "Bow Focus":
                var bowFocusData = new SkillData("Bow Focus", "Hybrid");
                bowFocusData.Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) };
                bowFocusData.Conditions = new List<Condition> { new WeaponUsedCondition("Bow") };
                return new Skill(bowFocusData);

            case "Lance Agility":
                var lanceAgilityData = new SkillData("Lance Agility", "Hybrid");
                lanceAgilityData.Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) };
                lanceAgilityData.Conditions = new List<Condition> { new WeaponUsedCondition("Lance") };
                return new Skill(lanceAgilityData);

            case "Axe Power":
                var axePowerData = new SkillData("Axe Power", "Hybrid");
                axePowerData.Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) };
                axePowerData.Conditions = new List<Condition> { new WeaponUsedCondition("Axe") };
                return new Skill(axePowerData);

            case "Bow Agility":
                var bowAgilityData = new SkillData("Bow Agility", "Hybrid");
                bowAgilityData.Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) };
                bowAgilityData.Conditions = new List<Condition> { new WeaponUsedCondition("Bow") };
                return new Skill(bowAgilityData);

            case "Sword Focus":
                var swordFocusData = new SkillData("Sword Focus", "Hybrid");
                swordFocusData.Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) };
                swordFocusData.Conditions = new List<Condition> { new WeaponUsedCondition("Sword") };
                return new Skill(swordFocusData);

            case "Close Def":
                var closeDefData = new SkillData("Close Def", "Hybrid");
                closeDefData.Effects = new List<Effect> { new DefenseBonusEffect(8), new ResistanceBonusEffect(8), new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect() };
                closeDefData.Conditions = new List<Condition> { new OpponentInitiatesCombatCondition(), new OrCondition(new List<Condition> { new OpponentWeaponUsedCondition("Sword"), new OpponentWeaponUsedCondition("Lance"), new OpponentWeaponUsedCondition("Axe") }) };
                return new Skill(closeDefData);

            case "Distant Def":
                var distantDefData = new SkillData("Distant Def", "Hybrid");
                distantDefData.Effects = new List<Effect> { new DefenseBonusEffect(8), new ResistanceBonusEffect(8), new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect() };
                distantDefData.Conditions = new List<Condition> { new OpponentInitiatesCombatCondition(), new OrCondition(new List<Condition> { new OpponentWeaponUsedCondition("Magic"), new OpponentWeaponUsedCondition("Bow") }) };
                return new Skill(distantDefData);

            case "Lull Atk/Spd":
                var lullAtkSpdData = new SkillData("Lull Atk/Spd", "Hybrid");
                lullAtkSpdData.Effects = new List<Effect> { new AttackPenaltyEffect(3), new SpeedPenaltyEffect(3), new NeutralizeAttackBonusEffect(), new NeutralizeSpeedBonusEffect() };
                return new Skill(lullAtkSpdData);

            case "Lull Atk/Def":
                var lullAtkDefData = new SkillData("Lull Atk/Def", "Hybrid");
                lullAtkDefData.Effects = new List<Effect> { new AttackPenaltyEffect(3), new DefensePenaltyEffect(3), new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect() };
                return new Skill(lullAtkDefData);

            case "Lull Atk/Res":
                var lullAtkResData = new SkillData("Lull Atk/Res", "Hybrid");
                lullAtkResData.Effects = new List<Effect> { new AttackPenaltyEffect(3), new ResistancePenaltyEffect(3), new NeutralizeAttackBonusEffect(), new NeutralizeResistanceBonusEffect() };
                return new Skill(lullAtkResData);

            case "Lull Spd/Def":
                var lullSpdDefData = new SkillData("Lull Spd/Def", "Hybrid");
                lullSpdDefData.Effects = new List<Effect> { new SpeedPenaltyEffect(3), new DefensePenaltyEffect(3), new NeutralizeSpeedBonusEffect(), new NeutralizeDefenseBonusEffect() };
                return new Skill(lullSpdDefData);

            case "Lull Spd/Res":
                var lullSpdResData = new SkillData("Lull Spd/Res", "Hybrid");
                lullSpdResData.Effects = new List<Effect> { new SpeedPenaltyEffect(3), new ResistancePenaltyEffect(3), new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect() };
                return new Skill(lullSpdResData);

            case "Lull Def/Res":
                var lullDefResData = new SkillData("Lull Def/Res", "Hybrid");
                lullDefResData.Effects = new List<Effect> { new DefensePenaltyEffect(3), new ResistancePenaltyEffect(3), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect() };
                return new Skill(lullDefResData);

            case "Fort. Def/Res":
                var fortDefResData = new SkillData("Fort. Def/Res", "Hybrid");
                fortDefResData.Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6), new AttackCostEffect(2) };
                return new Skill(fortDefResData);

            case "Life and Death":
                var lifeAndDeathData = new SkillData("Life and Death", "Hybrid");
                lifeAndDeathData.Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseCostEffect(5), new ResistanceCostEffect(5), new SpeedBonusEffect(6) };
                return new Skill(lifeAndDeathData);

            case "Solid Ground":
                var solidGroundData = new SkillData("Solid Ground", "Hybrid");
                solidGroundData.Effects = new List<Effect> { new DefenseBonusEffect(6), new AttackBonusEffect(6), new ResistanceCostEffect(5) };
                return new Skill(solidGroundData);

            case "Still Water":
                var stillWaterData = new SkillData("Still Water", "Hybrid");
                stillWaterData.Effects = new List<Effect> { new ResistanceBonusEffect(6), new AttackBonusEffect(6), new DefenseCostEffect(5) };
                return new Skill(stillWaterData);

            case "Dragonskin":
                var dragonskinData = new SkillData("Dragonskin", "Hybrid");
                dragonskinData.Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6), new DefenseBonusEffect(6), new ResistanceBonusEffect(6), new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect(), new NeutralizeSpeedBonusEffect() };
                dragonskinData.Conditions = new List<Condition> { new OrCondition(new List<Condition> { new OpponentInitiatesCombatCondition(), new OpponentHealthAboveCondition(75) }) };
                return new Skill(dragonskinData);

            case "Light and Dark":
                var lightAndDarkData = new SkillData("Light and Dark", "Hybrid");
                lightAndDarkData.Effects = new List<Effect> { new AttackPenaltyEffect(5), new SpeedPenaltyEffect(5), new DefensePenaltyEffect(5), new ResistancePenaltyEffect(5), new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(), new NeutralizeResistanceBonusEffect(), new NeutralizeSpeedBonusEffect(), new NeutralizeAttackPenaltyEffect(), new NeutralizeDefensePenaltyEffect(), new NeutralizeResistancePenaltyEffect(), new NeutralizeSpeedPenaltyEffect() };
                return new Skill(lightAndDarkData);
            case "Dragon Wall":
                var dragonWallData = new SkillData("Dragon Wall", "Damage");
                dragonWallData.Effects = new List<Effect> { new DamagePercentageReductionResistanceEffect() };
                dragonWallData.Conditions = new List<Condition> { new ResistanceDifferenceCondition()};
                return new Skill(dragonWallData);
            case "Dodge":
                var dodgeData = new SkillData("Dodge", "Damage");
                dodgeData.Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() };
                dodgeData.Conditions = new List<Condition> { new SpeedDifferenceCondition()};
                return new Skill(dodgeData);
            case "Golden Lotus":
                var goldenLotusData = new SkillData("Golden Lotus", "Damage");
                goldenLotusData.Effects = new List<Effect> { new FirstAttackDamagePercentageReductionHalfEffect() };
                goldenLotusData.Conditions = new List<Condition> { new OrCondition(new List<Condition> { new OpponentWeaponUsedCondition("Sword"), new OpponentWeaponUsedCondition("Lance"), new OpponentWeaponUsedCondition("Axe"), new OpponentWeaponUsedCondition("Bow")}) };
                return new Skill(goldenLotusData);
            case "Gentility":
                var gentilityData = new SkillData("Gentility", "Damage");
                gentilityData.Effects = new List<Effect> {new DamageAbsoluteReductionEffect(5)};
                return new Skill(gentilityData);
            case "Bow Guard":
                var bowGuardData = new SkillData("Bow Guard", "Damage");
                bowGuardData.Effects = new List<Effect> {new DamageAbsoluteReductionEffect(5)};
                bowGuardData.Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Bow")};
                return new Skill(bowGuardData);
            case "Arms Shield":
                var armsShieldData = new SkillData("Arms Guard", "Damage");
                armsShieldData.Effects = new List<Effect> {new DamageAbsoluteReductionEffect(7)};
                armsShieldData.Conditions = new List<Condition> { new AdvantageWeaponUsedCondition()};
                return new Skill(armsShieldData);
            case "Axe Guard":
                var axeGuardData = new SkillData("Axe Guard", "Damage");
                axeGuardData.Effects = new List<Effect> {new DamageAbsoluteReductionEffect(5)};
                axeGuardData.Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Axe")};
                return new Skill(axeGuardData);
            case "Magic Guard":
                var magicGuardData = new SkillData("Magic Guard", "Damage");
                magicGuardData.Effects = new List<Effect> {new DamageAbsoluteReductionEffect(5)};
                magicGuardData.Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Magic")};
                return new Skill(magicGuardData);
            case "Lance Guard":
                var lanceGuardData = new SkillData("Lance Guard", "Damage");
                lanceGuardData.Effects = new List<Effect> {new DamageAbsoluteReductionEffect(5)};
                lanceGuardData.Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Lance")};
                return new Skill(lanceGuardData);
            case "Sympathetic":
                var sympatheticData = new SkillData("Sympathetic", "Damage");
                sympatheticData.Effects = new List<Effect> {new DamageAbsoluteReductionEffect(5)};
                sympatheticData.Conditions = new List<Condition> { new OpponentInitiatesCombatCondition(), new HealthBelowCondition(50) };
                return new Skill(sympatheticData);
            case "Back at You":
                var backAtYouData = new SkillData("Back at You", "Damage");
                backAtYouData.Effects = new List<Effect> {new ExtraDamageBasedOnHPLostEffect()};
                backAtYouData.Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() };
                return new Skill(backAtYouData);
            case "Lunar Brace":
                var lunarBraceData = new SkillData("Lunar Brace", "Damage");
                lunarBraceData.Effects = new List<Effect> {new ExtraDamageBasedOnOpponentDefenseEffect(30)};
                lunarBraceData.Conditions = new List<Condition> { new InitiatesCombatCondition(), new OrCondition(new List<Condition> { new WeaponUsedCondition("Sword"), new WeaponUsedCondition("Lance"), new WeaponUsedCondition("Axe"), new WeaponUsedCondition("Bow")}) };
                return new Skill(lunarBraceData);
            case "Bravery":
                var braveryData = new SkillData("Bravery", "Damage");
                braveryData.Effects = new List<Effect> {new ExtraDamageEffect(5)};
                return new Skill(braveryData);
            default:
                return new Skill(new SkillData(skillName, "Unknown"));
        }
    }

    public static List<Skill> InitiateSkills(List<string> skillNames)
    {
        List<Skill> skills = new();
        foreach (var skillName in skillNames)
        {
            AddSkillIfNotNull(skills, skillName);
        }
        return skills;
    }

    private static void AddSkillIfNotNull(List<Skill> skills, string skillName)
    {
        Skill skill = CreateSkill(skillName);
        if (skill != null)
        {
            skills.Add(skill);
        }
    }
    
    }