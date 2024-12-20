using Fire_Emblem.Controllers.Skills.Conditions;
using Fire_Emblem.Controllers.Skills.Effects;
using Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects;
using Fire_Emblem.Controllers.Skills.Effects.BonusEffects;
using Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;
using Fire_Emblem.Controllers.Skills.Effects.DamageEffects;
using Fire_Emblem.Controllers.Skills.Effects.CostEffects;
using Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamageAbsoluteReduction;
using Fire_Emblem.Controllers.Skills.Effects.DamageEffects.DamagePercentageReduction;
using Fire_Emblem.Controllers.Skills.Effects.HybridEffects;
using Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;
using Fire_Emblem.Controllers.Skills.Effects.HealEffects;
using Fire_Emblem.Models;
using System.Collections;
using Fire_Emblem.Controllers.Skills.Effects.AttackDenialEffects;
using Fire_Emblem.Controllers.Skills.Effects.FollowUpEffects;

namespace Fire_Emblem.Controllers.Skills;

public static class SkillFactory
{
    private static SkillsList CreateSkill(string skillName)
    {
        SkillsList skills = new();
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
                skills.AddSkill((fairFightSkill));
                break;
            case "HP +15":
                var hp15Skill = new Skill("HP +15", "Base Stats")
                {
                    Effects = new List<Effect> { new Max15HPBonusEffect() }
                };
                skills.AddSkill((hp15Skill));
                break;

            case "Resolve":
                var resolveSkill = new Skill("Resolve", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(7), new ResistanceBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthBelowCondition(75) }
                };
                skills.AddSkill((resolveSkill));
                break;

            case "Speed +5":
                var speed5Skill = new Skill("Speed +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5) }
                };
                skills.AddSkill((speed5Skill));
                break;

            case "Armored Blow":
                var armoredBlowSkill = new Skill("Armored Blow", "Bonus")
                {
                    Conditions = new List<Condition> { new InitiatesCombatCondition() },
                    Effects = new List<Effect> { new DefenseBonusEffect(8) }
                };
                skills.AddSkill((armoredBlowSkill));
                break;

            case "Will to Win":
                var willToWinSkill = new Skill("Will to Win", "Bonus")
                {
                    Conditions = new List<Condition> { new HealthBelowCondition(50) },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
                skills.AddSkill((willToWinSkill));
                break;

            case "Single-Minded":
                var singleMindedSkill = new Skill("Single-Minded", "Bonus")
                {
                    Conditions = new List<Condition> { new RecentOpponentCondition() },
                    Effects = new List<Effect> { new AttackBonusEffect(8) }
                };
                skills.AddSkill((singleMindedSkill));
                break;

            case "Ignis":
                var ignisSkill = new Skill("Ignis", "First Attack")
                {
                    Effects = new List<Effect> { new FirstAttackBonusEffect(50) }
                };
                skills.AddSkill((ignisSkill));
                break;

            case "Perceptive":
                var AdditionalBonusPerSpeed = new Dictionary<string, int>
                {
                    { "Bonus", 1 },
                    { "Per Speed", 4 }
                };
                var perceptiveSkill = new Skill("Perceptive", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusWithAdditionalEffect(12, AdditionalBonusPerSpeed) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((perceptiveSkill));
                break;

            case "Tome Precision":
                var tomePrecisionSkill = new Skill("Tome Precision", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Magic") }
                };
                skills.AddSkill((tomePrecisionSkill));
                break;

            case "Attack +6":
                var attack6Skill = new Skill("Attack +6", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) }
                };
                skills.AddSkill((attack6Skill));
                break;

            case "Defense +5":
                var defense5Skill = new Skill("Defense +5", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(5) }
                };
                skills.AddSkill((defense5Skill));
                break;

            case "Wrath":
                var AdditionalAttackBonusPerHPLost = new Dictionary<string, int>
                {
                    { "Bonus", 1 },
                    { "Per HP", 1 }
                };
                var AdditionalSpeedBonusPerHP = new Dictionary<string, int>
                {
                    { "Bonus", 1 },
                    { "Per HP", 1 }
                };
                var wrathSkill = new Skill("Wrath", "Bonus")
                {
                    Effects = new List<Effect>
                    {
                        new AttackBonusPerHPLostEffect(0, AdditionalAttackBonusPerHPLost, 30),
                        new SpeedBonusPerHPLostEffect(0, AdditionalSpeedBonusPerHP, 30)
                    }
                };
                skills.AddSkill((wrathSkill));
                break;

            case "Resistance +5":
                var resistance5Skill = new Skill("Resistance +5", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(5) }
                };
                skills.AddSkill((resistance5Skill));
                break;

            case "Atk/Def +5":
                var atkDef5Skill = new Skill("Atk/Def +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new DefenseBonusEffect(5) }
                };
                skills.AddSkill((atkDef5Skill));
                break;

            case "Atk/Res +5":
                var atkRes5Skill = new Skill("Atk/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(5), new ResistanceBonusEffect(5) }
                };
                skills.AddSkill((atkRes5Skill));
                break;

            case "Spd/Res +5":
                var spdRes5Skill = new Skill("Spd/Res +5", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(5), new ResistanceBonusEffect(5) }
                };
                skills.AddSkill((spdRes5Skill));
                break;

            case "Deadly Blade":
                var deadlyBladeSkill = new Skill("Deadly Blade", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8), new SpeedBonusEffect(8) },
                    Conditions = new List<Condition>
                        { new WeaponUsedCondition("Sword"), new InitiatesCombatCondition() }
                };
                skills.AddSkill((deadlyBladeSkill));
                break;

            case "Death Blow":
                var deathBlowSkill = new Skill("Death Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((deathBlowSkill));
                break;

            case "Darting Blow":
                var dartingBlowSkill = new Skill("Darting Blow", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((dartingBlowSkill));
                break;

            case "Warding Blow":
                var wardingBlowSkill = new Skill("Warding Blow", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(8) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((wardingBlowSkill));
                break;

            case "Swift Sparrow":
                var swiftSparrowSkill = new Skill("Swift Sparrow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((swiftSparrowSkill));
                break;

            case "Sturdy Blow":
                var sturdyBlowSkill = new Skill("Sturdy Blow", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((sturdyBlowSkill));
                break;

            case "Mirror Strike":
                var mirrorStrikeSkill = new Skill("Mirror Strike", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((mirrorStrikeSkill));
                break;

            case "Steady Blow":
                var steadyBlowSkill = new Skill("Steady Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((steadyBlowSkill));
                break;

            case "Swift Strike":
                var swiftStrikeSkill = new Skill("Swift Strike", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((swiftStrikeSkill));
                break;

            case "Bracing Blow":
                var bracingBlowSkill = new Skill("Bracing Blow", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((bracingBlowSkill));
                break;

            case "Brazen Atk/Spd":
                var brazenAtkSpdSkill = new Skill("Brazen Atk/Spd", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new SpeedBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.AddSkill((brazenAtkSpdSkill));
                break;

            case "Brazen Atk/Def":
                var brazenAtkDefSkill = new Skill("Brazen Atk/Def", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.AddSkill((brazenAtkDefSkill));
                break;

            case "Brazen Atk/Res":
                var brazenAtkResSkill = new Skill("Brazen Atk/Res", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.AddSkill((brazenAtkResSkill));
                break;

            case "Brazen Spd/Def":
                var brazenSpdDefSkill = new Skill("Brazen Spd/Def", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.AddSkill((brazenSpdDefSkill));
                break;

            case "Brazen Spd/Res":
                var brazenSpdResSkill = new Skill("Brazen Spd/Res", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.AddSkill((brazenSpdResSkill));
                break;

            case "Brazen Def/Res":
                var brazenDefResSkill = new Skill("Brazen Def/Res", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(10), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new HealthBelowCondition(80) }
                };
                skills.AddSkill((brazenDefResSkill));
                break;

            case "Fire Boost":
                var fireBoostSkill = new Skill("Fire Boost", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.AddSkill((fireBoostSkill));
                break;

            case "Wind Boost":
                var windBoostSkill = new Skill("Wind Boost", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.AddSkill((windBoostSkill));
                break;

            case "Earth Boost":
                var earthBoostSkill = new Skill("Earth Boost", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.AddSkill((earthBoostSkill));
                break;

            case "Water Boost":
                var waterBoostSkill = new Skill("Water Boost", "Bonus")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(6) },
                    Conditions = new List<Condition> { new HealthAboveRivalCondition(3) }
                };
                skills.AddSkill((waterBoostSkill));
                break;

            case "Chaos Style":
                var chaosStyleSkill = new Skill("Chaos Style", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(3) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition(), new WeaponVsMagicCondition() }
                };
                skills.AddSkill((chaosStyleSkill));
                break;

            case "Blinding Flash":
                var blindingFlashSkill = new Skill("Blinding Flash", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(4) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((blindingFlashSkill));
                break;

            case "Not *Quite*":
                var notQuiteSkill = new Skill("Not *Quite*", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(4) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.AddSkill((notQuiteSkill));
                break;

            case "Stunning Smile":
                var stunningSmileSkill = new Skill("Stunning Smile", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
                skills.AddSkill((stunningSmileSkill));
                break;

            case "Disarming Sigh":
                var disarmingSighSkill = new Skill("Disarming Sigh", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(8) },
                    Conditions = new List<Condition> { new OpponentGenderCondition("Male") }
                };
                skills.AddSkill((disarmingSighSkill));
                break;

            case "Charmer":
                var charmerSkill = new Skill("Charmer", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(3), new AttackPenaltyEffect(3) },
                    Conditions = new List<Condition> { new RecentOpponentCondition() }
                };
                skills.AddSkill((charmerSkill));
                break;

            case "Luna":
                var lunaSkill = new Skill("Luna", "First Attack")
                {
                    Effects = new List<Effect>
                        { new FirstDefensePenaltyMinusHalfEffect(0), new FirstResistancePenaltyMinusHalfEffect(0) }
                };
                skills.AddSkill((lunaSkill));
                break;

            case "Belief in Love":
                var beliefInLoveSkill = new Skill("Belief in Love", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new DefensePenaltyEffect(5) },
                    Conditions = new List<Condition>
                    {
                        new OrCondition(new List<Condition>
                            { new OpponentInitiatesCombatCondition(), new OpponentFullHealthCondition() })
                    }
                };
                skills.AddSkill((beliefInLoveSkill));
                break;

            case "Beorc's Blessing":
                var beorcsBlessingSkill = new Skill("Beorc's Blessing", "Neutralization")
                {
                    Effects = new List<Effect>
                    {
                        new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(),
                        new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect()
                    }
                };
                skills.AddSkill((beorcsBlessingSkill));
                break;


            case "Agnea's Arrow":
                var agneasArrowSkill = new Skill("Agnea's Arrow", "Neutralization")
                {
                    Effects = new List<Effect>
                    {
                        new NeutralizeDefensePenaltyEffect(), new NeutralizeAttackPenaltyEffect(),
                        new NeutralizeResistancePenaltyEffect(), new NeutralizeSpeedPenaltyEffect()
                    }
                };
                skills.AddSkill((agneasArrowSkill));
                break;

            case "Soulblade":
                var soulbladeSkill = new Skill("Soulblade", "Hybrid")
                {
                    Effects = new List<Effect> { new OpponentDefenseResistanceAverageEffect() },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.AddSkill((soulbladeSkill));
                break;

            case "Sandstorm":
                var sandstormSkill = new Skill("Sandstorm", "Hybrid")
                {
                    Effects = new List<Effect> { new FollowUpAttackBasedOnUnitDefenseEffect() }
                };
                skills.AddSkill((sandstormSkill));
                break;

            case "Sword Agility":
                var swordAgilitySkill = new Skill("Sword Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.AddSkill((swordAgilitySkill));
                break;

            case "Lance Power":
                var lancePowerSkill = new Skill("Lance Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Lance") }
                };
                skills.AddSkill((lancePowerSkill));
                break;

            case "Sword Power":
                var swordPowerSkill = new Skill("Sword Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.AddSkill((swordPowerSkill));
                break;

            case "Bow Focus":
                var bowFocusSkill = new Skill("Bow Focus", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Bow") }
                };
                skills.AddSkill((bowFocusSkill));
                break;

            case "Lance Agility":
                var lanceAgilitySkill = new Skill("Lance Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Lance") }
                };
                skills.AddSkill((lanceAgilitySkill));
                break;

            case "Axe Power":
                var axePowerSkill = new Skill("Axe Power", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new DefenseCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Axe") }
                };
                skills.AddSkill((axePowerSkill));
                break;

            case "Bow Agility":
                var bowAgilitySkill = new Skill("Bow Agility", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(12), new AttackCostEffect(6) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Bow") }
                };
                skills.AddSkill((bowAgilitySkill));
                break;

            case "Sword Focus":
                var swordFocusSkill = new Skill("Sword Focus", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(10), new ResistanceCostEffect(10) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Sword") }
                };
                skills.AddSkill((swordFocusSkill));
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
                skills.AddSkill((closeDefSkill));
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
                skills.AddSkill((distantDefSkill));
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
                skills.AddSkill((lullAtkSpdSkill));
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
                skills.AddSkill((lullAtkDefSkill));
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
                skills.AddSkill((lullAtkResSkill));
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
                skills.AddSkill((lullSpdDefSkill));
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
                skills.AddSkill((lullSpdResSkill));
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
                skills.AddSkill((lullDefResSkill));
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
                skills.AddSkill((fortDefResSkill));
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
                skills.AddSkill((lifeAndDeathSkill));
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
                skills.AddSkill((solidGroundSkill));
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
                skills.AddSkill((stillWaterSkill));
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
                skills.AddSkill((dragonskinSkill));
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
                skills.AddSkill((lightAndDarkSkill));
                break;

            case "Dragon Wall":
                var dragonWallSkill = new Skill("Dragon Wall", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionResistanceEffect() },
                    Conditions = new List<Condition> { new ResistanceDifferenceCondition() }
                };
                skills.AddSkill((dragonWallSkill));
                break;

            case "Dodge":
                var dodgeSkill = new Skill("Dodge", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition(0) }
                };
                skills.AddSkill((dodgeSkill));
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
                skills.AddSkill((goldenLotusSkill));
                break;

            case "Gentility":
                var gentilitySkill = new Skill("Gentility", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) }
                };
                skills.AddSkill((gentilitySkill));
                break;

            case "Bow Guard":
                var bowGuardSkill = new Skill("Bow Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Bow") }
                };
                skills.AddSkill((bowGuardSkill));
                break;

            case "Arms Shield":
                var armsShieldSkill = new Skill("Arms Shield", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(7) },
                    Conditions = new List<Condition> { new AdvantageWeaponUsedCondition() }
                };
                skills.AddSkill((armsShieldSkill));
                break;

            case "Axe Guard":
                var axeGuardSkill = new Skill("Axe Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Axe") }
                };
                skills.AddSkill((axeGuardSkill));
                break;

            case "Magic Guard":
                var magicGuardSkill = new Skill("Magic Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Magic") }
                };
                skills.AddSkill((magicGuardSkill));
                break;

            case "Lance Guard":
                var lanceGuardSkill = new Skill("Lance Guard", "Damage")
                {
                    Effects = new List<Effect> { new DamageAbsoluteReductionEffect(5) },
                    Conditions = new List<Condition> { new OpponentWeaponUsedCondition("Lance") }
                };
                skills.AddSkill((lanceGuardSkill));
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
                skills.AddSkill((sympatheticSkill));
                break;

            case "Back at You":
                var backAtYouSkill = new Skill("Back at You", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnHPLostEffect() },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.AddSkill((backAtYouSkill));
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
                skills.AddSkill((lunarBraceSkill));
                break;

            case "Bravery":
                var braverySkill = new Skill("Bravery", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(5) }
                };
                skills.AddSkill((braverySkill));
                break;
            case "Bushido":
                var bushidoExtraDamageSkill = new Skill("Bushido Extra Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(7) }
                };
                var bushidoReduceDamageSkill = new Skill("Bushido Reduce Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition(0) }
                };
                skills.AddSkill((bushidoExtraDamageSkill));
                skills.AddSkill((bushidoReduceDamageSkill));
                break;
            case "Moon-Twin Wing":
                var moonTwinWingPenaltySkill = new Skill("Moon-Twin Wing Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(5), new SpeedPenaltyEffect(5) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var moonTwinWingDamageSkill = new Skill("Moon-Twin Wing Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionSpeedEffect() },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition(0), new HealthAboveCondition(25) }
                };
                skills.AddSkill((moonTwinWingDamageSkill));
                skills.AddSkill((moonTwinWingPenaltySkill));
                break;
            case "Blue Skies":
                var blueSkiesSkill = new Skill("Blue Skies", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(5), new DamageAbsoluteReductionEffect(5) },
                };
                skills.AddSkill((blueSkiesSkill));
                break;
            case "Aegis Shield":
                var aegisShieldBonusSkill = new Skill("Aegis Shield Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(6), new ResistanceBonusEffect(3) },
                };
                var aegisShieldDamageSkill = new Skill("Aegis Shield Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(50) },

                };
                skills.AddSkill((aegisShieldBonusSkill));
                skills.AddSkill((aegisShieldDamageSkill));
                break;
            case "Remote Sparrow":
                var remoteSparrowBonusSkill = new Skill("Remote Sparrow Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new SpeedBonusEffect(7) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteSparrowDamageSkill = new Skill("  Remote Sparrow Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((remoteSparrowBonusSkill));
                skills.AddSkill((remoteSparrowDamageSkill));
                break;
            case "Remote Mirror":
                var remoteMirrorBonusSkill = new Skill("Remote Mirror Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new ResistanceBonusEffect(10) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteMirrorDamageSkill = new Skill("Remote Mirror Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((remoteMirrorBonusSkill));
                skills.AddSkill((remoteMirrorDamageSkill));
                break;
            case "Remote Sturdy":
                var remoteSturdyBonusSkill = new Skill("Remote Sturdy Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new DefenseBonusEffect(10) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var remoteSturdyDamageSkill = new Skill("Remote Sturdy Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill((remoteSturdyBonusSkill));
                skills.AddSkill((remoteSturdyDamageSkill));
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
                skills.AddSkill((fierceStanceBonusSkill));
                skills.AddSkill((fierceStanceDamageSkill));
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
                skills.AddSkill((dartingStanceBonusSkill));
                skills.AddSkill((dartingStanceDamageSkill));
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
                skills.AddSkill((steadyStanceBonusSkill));
                skills.AddSkill((steadyStanceDamageSkill));
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
                skills.AddSkill((wardingStanceBonusSkill));
                skills.AddSkill((wardingStanceDamageSkill));
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
                skills.AddSkill((kestrelStanceBonusSkill));
                skills.AddSkill((kestrelStanceDamageSkill));
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
                skills.AddSkill((sturdyStanceBonusSkill));
                skills.AddSkill((sturdyStanceDamageSkill));
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
                skills.AddSkill((mirrorStanceBonusSkill));
                skills.AddSkill((mirrorStanceDamageSkill));
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
                skills.AddSkill((steadyPostureBonusSkill));
                skills.AddSkill((steadyPostureDamageSkill));
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
                skills.AddSkill((swiftStanceBonusSkill));
                skills.AddSkill((swiftStanceDamageSkill));
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
                skills.AddSkill((bracingStanceBonusSkill));
                skills.AddSkill((bracingStanceDamageSkill));
                break;
            case "Poetic Justice":
                var poeticJusticePenaltySkill = new Skill("Poetic Justice Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(4) }
                };
                var poeticJusticeDamageSkill = new Skill("Poetic Justice Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnOpponentAttackEffect(15) }
                };
                skills.AddSkill((poeticJusticePenaltySkill));
                skills.AddSkill((poeticJusticeDamageSkill));
                break;
            case "Laguz Friend":
                var laguzFriendCostSkill = new Skill("Laguz Friend Cost", "Hybrid")
                {
                    Effects = new List<Effect>
                    {
                        new DefenseCostPercentageEffect(50), new ResistanceCostPercentageEffect(50),
                        new SelfNeutralizeResistanceEffect(), new SelfNeutralizeDefenseBonusEffect()
                    }
                };
                var laguzFriendDamageSkill = new Skill("Laguz Friend Bonus", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionEffect(50) }
                };
                skills.AddSkill((laguzFriendCostSkill));
                skills.AddSkill((laguzFriendDamageSkill));
                break;
            case "Chivalry":
                var chivalrySkill = new Skill("Chivalry", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageEffect(2), new DamageAbsoluteReductionEffect(2) },
                    Conditions = new List<Condition>
                        { new InitiatesCombatCondition(), new OpponentFullHealthCondition() }
                };
                skills.AddSkill((chivalrySkill));
                break;
            case "Dragon's Wrath":
                var dragonsWrathDamageReductionSkill = new Skill("Dragon's Wrath Damage Reduction", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(25) }
                };
                var dragonsWrathExtraDamageSkill = new Skill("Dragon's Wrath Extra Damage", "Damage")
                {
                    Effects = new List<Effect>
                        { new FirstAttackExtraDamageBasedOnAttackAndOpponentResistanceDifferenceEffect(25) },
                    Conditions = new List<Condition> { new AttackAndOpponentResistanceCondition() }
                };
                skills.AddSkill((dragonsWrathDamageReductionSkill));
                skills.AddSkill((dragonsWrathExtraDamageSkill));
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
                skills.AddSkill((presciencePenaltySkill));
                skills.AddSkill((prescienceDamageSkill));
                break;
            case "Extra Chivalry":
                var extraChivalryPenaltySkill = new Skill("Extra Chivalry Penalty", "Penalty")
                {
                    Effects = new List<Effect>
                        { new AttackPenaltyEffect(5), new DefensePenaltyEffect(5), new SpeedPenaltyEffect(5) },
                    Conditions = new List<Condition> { new OpponentHealthAboveCondition(50) }
                };
                var extraChivalryDamageSkill = new Skill("Extra Chivalry Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionBasedOnOpponentHealthEffect(50) },
                };
                skills.AddSkill((extraChivalryPenaltySkill));
                skills.AddSkill((extraChivalryDamageSkill));
                break;
            case "Guard Bearing":
                var guardBearingPenaltySkill = new Skill("Guard Bearing Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new DefensePenaltyEffect(4), new SpeedPenaltyEffect(4) },
                };
                var guardBearingDamageSkill = new Skill("Guard Bearing Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionBasedOnFirstCombatsEffect() },
                };

                skills.AddSkill((guardBearingPenaltySkill));
                skills.AddSkill((guardBearingDamageSkill));
                break;
            case "Divine Recreation":
                var divineRecreationPenaltySkill = new Skill("Divine Recreation Penalty", "Penalty")
                {
                    Effects = new List<Effect>
                    {
                        new AttackPenaltyEffect(4), new SpeedPenaltyEffect(4), new DefensePenaltyEffect(4),
                        new ResistancePenaltyEffect(4)
                    },
                    Conditions = new List<Condition> { new OpponentHealthAboveCondition(50) }
                };
                var divineRecreationDamageSkill = new Skill("Divine Recreation Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamageDivineRecreationEffect() },
                    Conditions = new List<Condition> { new OpponentHealthAboveCondition(50) }
                };
                skills.AddSkill((divineRecreationPenaltySkill));
                skills.AddSkill((divineRecreationDamageSkill));
                break;
            case "Sol":
                var solSkill = new Skill("Sol", "Heal")
                {
                    Effects = new List<Effect> { new HealBasedOnDamageEffect(25) }
                };
                skills.AddSkill(solSkill);
                break;
            case "Nosferatu":
                var nosferatuSkill = new Skill("Nosferatu", "Heal")
                {
                    Effects = new List<Effect> { new HealBasedOnDamageEffect(50) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Magic") }
                };
                skills.AddSkill(nosferatuSkill);
                break;
            case "Solar Brace":
                var solarBraceSkill = new Skill("Solar Brace", "Heal")
                {
                    Effects = new List<Effect> { new HealBasedOnDamageEffect(50) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(solarBraceSkill);
                break;
            case "Windsweep":
                var windsweepSkill = new Skill("Windsweep", "Denial")
                {
                    Effects = new List<Effect> { new CounterAttackDenialEffect() },
                    Conditions = new List<Condition>
                    {
                        new InitiatesCombatCondition(),
                        new WeaponUsedCondition("Sword"),
                        new OpponentWeaponUsedCondition("Sword")
                    }
                };
                skills.AddSkill((windsweepSkill));
                break;
            case "Surprise Attack":
                var surpriseAttackSkill = new Skill("Surprise Attack", "Denial")
                {
                    Effects = new List<Effect> { new CounterAttackDenialEffect() },
                    Conditions = new List<Condition>
                    {
                        new InitiatesCombatCondition(),
                        new WeaponUsedCondition("Bow"),
                        new OpponentWeaponUsedCondition("Bow")
                    }
                };
                skills.AddSkill((surpriseAttackSkill));
                break;
            case "Hliðskjálf":
                var hlioskjalfSkill = new Skill("Hliðskjálf", "Denial")
                {
                    Effects = new List<Effect> { new CounterAttackDenialEffect() },
                    Conditions = new List<Condition>
                    {
                        new InitiatesCombatCondition(),
                        new WeaponUsedCondition("Magic"),
                        new OpponentWeaponUsedCondition("Magic")
                    }
                };
                skills.AddSkill(hlioskjalfSkill);
                break;
            case "Laws of Sacae":
                var lawsOfSacaeSkillDenial = new Skill("Laws of Sacae Denial", "Denial")
                {
                    Effects = new List<Effect> { new CounterAttackDenialEffect() },
                    Conditions = new List<Condition>
                    {
                        new InitiatesCombatCondition(),
                        new OrCondition(new List<Condition>
                        {
                            new OpponentWeaponUsedCondition("Sword"),
                            new OpponentWeaponUsedCondition("Axe"),
                            new OpponentWeaponUsedCondition("Lance")
                        }),
                        new SpeedDifferenceCondition(5)
                    }
                };
                var lawsOfSacaeSkillBonus = new Skill("Laws of Sacae Bonus", "Bonus")
                {
                    Effects = new List<Effect>
                    {
                        new SpeedBonusEffect(6), new AttackBonusEffect(6),
                        new DefenseBonusEffect(6), new ResistanceBonusEffect(6)
                    },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(lawsOfSacaeSkillDenial);
                skills.AddSkill(lawsOfSacaeSkillBonus);
                break;
            case "Null C-Disrupt":
                var nullCDisruptSkill = new Skill("Null C-Disrupt", "Denial")
                {
                    Effects = new List<Effect> { new DenialCounterAttackDenialEffect() }
                };
                skills.AddSkill(nullCDisruptSkill);
                break;
            case "Eclipse Brace":
                var eclipseBraceSkillDamage = new Skill("Eclipse Brace Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnOpponentDefenseEffect(30) },
                    Conditions = new List<Condition>
                    {
                        new InitiatesCombatCondition(), new OrCondition(new List<Condition>
                        {
                            new WeaponUsedCondition("Sword"),
                            new WeaponUsedCondition("Lance"),
                            new WeaponUsedCondition("Axe"),
                            new WeaponUsedCondition("Bow")
                        })
                    }
                };
                var eclipseBraceSkillHeal = new Skill("Eclipse Brace Heal", "Heal")
                {
                    Effects = new List<Effect> { new HealBasedOnDamageEffect(50) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(eclipseBraceSkillDamage);
                skills.AddSkill(eclipseBraceSkillHeal);
                break;
            case "Resonance":
                var resonanceSkill = new Skill("Resonance", "Damage")
                {
                    Effects = new List<Effect>
                        { new ExtraDamageEffect(3), new SelfExtraDamageBeforeCombatStartEffect(1) },
                    Conditions = new List<Condition>
                    {
                        new WeaponUsedCondition("Magic"),
                        new HealthAboveSpecificHPCondition(2)
                    }
                };
                skills.AddSkill(resonanceSkill);
                break;
            case "Flare":
                var flareSkill = new Skill("Flare", "Hybrid")
                {
                    Effects = new List<Effect>
                        { new ResistancePercentagePenaltyEffect(20), new HealBasedOnDamageEffect(50) },
                    Conditions = new List<Condition> { new WeaponUsedCondition("Magic") }
                };
                skills.AddSkill(flareSkill);
                break;
            case "Fury":
                var furySkill = new Skill("Fury", "Hybrid")
                {
                    Effects = new List<Effect>
                    {
                        new AttackBonusEffect(4), new SpeedBonusEffect(4), new DefenseBonusEffect(4),
                        new ResistanceBonusEffect(4), new SelfExtraDamageAfterCombatEffect(8)
                    }
                };
                skills.AddSkill(furySkill);
                break;
            case "Mystic Boost":
                var mysticBoostSkill = new Skill("Mystic Boost", "Hybrid")
                {
                    Effects = new List<Effect> { new HealAfterCombatEffect(10), new AttackPenaltyEffect(5) }
                };
                skills.AddSkill(mysticBoostSkill);
                break;
            case "Atk/Spd Push":
                var atkSpdPushSkillBonus = new Skill("Atk/Spd Push Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new SpeedBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var atkSpdPushSkillDamage = new Skill("Atk/Spd Push After Combar", "After Combat")
                {
                    Effects = new List<Effect> { new SelfExtraDamageAfterCombatEffect(5) },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(25), new UnitHasAttackedInRoundCondition() }
                };
                skills.AddSkill(atkSpdPushSkillBonus);
                skills.AddSkill(atkSpdPushSkillDamage);
                break;
            case "Atk/Def Push":
                var atkDefPushSkillBonus = new Skill("Atk/Def Push Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new DefenseBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var atkDefPushSkillDamage = new Skill("Atk/Def Push After Combar", "After Combat")
                {
                    Effects = new List<Effect> { new SelfExtraDamageAfterCombatEffect(5) },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(25), new UnitHasAttackedInRoundCondition() }
                };
                skills.AddSkill(atkDefPushSkillBonus);
                skills.AddSkill(atkDefPushSkillDamage);
                break;
            case "Atk/Res Push":
                var atkResPushSkillBonus = new Skill("Atk/Res Push Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(7), new ResistanceBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var atkResPushSkillDamage = new Skill("Atk/Res Push After Combar", "After Combat")
                {
                    Effects = new List<Effect> { new SelfExtraDamageAfterCombatEffect(5) },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(25), new UnitHasAttackedInRoundCondition() }
                };
                skills.AddSkill(atkResPushSkillBonus);
                skills.AddSkill(atkResPushSkillDamage);
                break;
            case "Spd/Def Push":
                var spdDefPushSkillBonus = new Skill("Spd/Def Push Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(7), new DefenseBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var spdDefPushSkillDamage = new Skill("Spd/Def Push After Combar", "After Combat")
                {
                    Effects = new List<Effect> { new SelfExtraDamageAfterCombatEffect(5) },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(25), new UnitHasAttackedInRoundCondition() }
                };
                skills.AddSkill(spdDefPushSkillBonus);
                skills.AddSkill(spdDefPushSkillDamage);
                break;
            case "Spd/Res Push":
                var spdResPushSkillBonus = new Skill("Spd/Res Push Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new SpeedBonusEffect(7), new ResistanceBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var spdResPushSkillDamage = new Skill("Spd/Res Push After Combar", "After Combat")
                {
                    Effects = new List<Effect> { new SelfExtraDamageAfterCombatEffect(5) },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(25), new UnitHasAttackedInRoundCondition() }
                };
                skills.AddSkill(spdResPushSkillBonus);
                skills.AddSkill(spdResPushSkillDamage);
                break;
            case "Def/Res Push":
                var defResPushSkillBonus = new Skill("Def/Res Push Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(7), new ResistanceBonusEffect(7) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var defResPushSkillDamage = new Skill("Def/Res Push After Combar", "After Combat")
                {
                    Effects = new List<Effect> { new SelfExtraDamageAfterCombatEffect(5) },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(25), new UnitHasAttackedInRoundCondition() }
                };
                skills.AddSkill(defResPushSkillBonus);
                skills.AddSkill(defResPushSkillDamage);
                break;
            case "True Dragon Wall":
                var trueDragonWallSkillDamage = new Skill("True Dragon Wall Damage", "Damage")
                {
                    Effects = new List<Effect>
                    {
                        new FirstAttackDamagePercentageReductionResistanceEffect(60),
                        new FollowUpDamagePercentageReductionResistanceEffect(40)
                    },
                    Conditions = new List<Condition> { new ResistanceDifferenceCondition() }
                };
                var trueDragonWallSkillHeal = new Skill("True Dragon Wall Heal", "Heal")
                {
                    Effects = new List<Effect> { new HealAfterCombatEffect(7) },
                    Conditions = new List<Condition>
                    {
                        new AlliesWeaponUsedCondition("Magic")
                    }
                };
                skills.AddSkill((trueDragonWallSkillDamage));
                skills.AddSkill(trueDragonWallSkillHeal);
                break;
            case "Scendscale":
                var scendscaleSkillDamage = new Skill("Scendscale Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraDamageBasedOnAttackEffect(25) }
                };
                var scendscaleSkillAfterCombat = new Skill("Scendscale After Combat", "After Combat")
                {
                    Effects = new List<Effect> { new SelfExtraDamageAfterCombatEffect(7) },
                    Conditions = new List<Condition> { new UnitHasAttackedInRoundCondition() }
                };
                skills.AddSkill((scendscaleSkillDamage));
                skills.AddSkill(scendscaleSkillAfterCombat);
                break;
            case "Mastermind":
                var mastermindSkillSelfDamage = new Skill("Mastermind Self Damage", "Damage")
                {
                    Effects = new List<Effect> { new SelfExtraDamageBeforeCombatStartEffect(1) },
                    Conditions = new List<Condition> { new HealthAboveSpecificHPCondition(2) }
                };
                var mastermindSkillDamage = new Skill("Mastermind Damage", "Damage")
                {
                    Effects = new List<Effect>
                    {
                        new ExtraDamageBasedOnOpponentPenaltyEffect(80),
                        new ExtraDamageBasedOnBonusEffect(80)
                    },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var mastermindSkillBonus = new Skill("Mastermind Bonus", "Bonus")
                {
                    Effects = new List<Effect> { new AttackBonusEffect(9), new SpeedBonusEffect(9) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(mastermindSkillDamage);
                skills.AddSkill(mastermindSkillSelfDamage);
                skills.AddSkill(mastermindSkillBonus);
                break;
            case "Bewitching Tome":
                var bewitchingTomeSkillDamage = new Skill("Bewitching Tome Damage", "Damage")
                {
                    Effects = new List<Effect>
                    {
                        new FirstAttackDamagePercentageReductionEffect(30),
                        new BewitchingTomeExtraDamageBeforeCombatStartEffect()
                    },
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
                var bewitchingTomeSkillHybrid = new Skill("Bewitching Tome Hybrid", "Hybrid")
                {
                    Effects = new List<Effect>
                    {
                        new ResistanceBonusEffect(5), new SpeedBonusEffect(5), new DefenseBonusEffect(5),
                        new AttackBonusEffect(5), new AttackPercentageBonusBasedOnSpeedEffect(20),
                        new SpeedPercentageBonusEffect(20), new HealAfterCombatEffect(7)
                    },
                    Conditions = new List<Condition>
                    {
                        new OrCondition(new List<Condition>
                        {
                            new InitiatesCombatCondition(),
                            new OrCondition(new List<Condition>
                            {
                                new OpponentWeaponUsedCondition("Magic"), new OpponentWeaponUsedCondition("Bow")
                            })
                        })
                    }
                };
                skills.AddSkill(bewitchingTomeSkillDamage);
                skills.AddSkill(bewitchingTomeSkillHybrid);
                break;
            case "Quick Riposte":
                var quickRiposteSkill = new Skill("Quick Riposte", "Follow Up")
                {
                    Effects = new List<Effect> { new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(60), new OpponentInitiatesCombatCondition() }
                };
                skills.AddSkill(quickRiposteSkill);
                break;
            case "Follow-Up Ring":
                var followUpRingSkill = new Skill("Follow-Up Ring", "Follow Up")
                {
                    Effects = new List<Effect> { new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(50)}
                };
                skills.AddSkill(followUpRingSkill);
                break;
            case "Wary Fighter":
                var waryFighterSkill = new Skill("Wary Fighter", "Follow Up")
                {
                    Effects = new List<Effect> { new NeutralizeFollowUpEffect(), new SelfNeutralizeFollowUpEffect() },
                    Conditions = new List<Condition>
                        { new HealthAboveCondition(50) }
                };
                skills.AddSkill(waryFighterSkill);
                break;
            case "Piercing Tribute":
                var piercingTributeSkill = new Skill("Piercing Tribute", "Follow Up")
                {
                    Effects = new List<Effect> { new ImmuneToGuaranteedFollowUpEffect() }
                };
                skills.AddSkill(piercingTributeSkill);
                break;
            case "Mjölnir":
                var mjolnirSkill = new Skill("Mjölnir", "Follow Up")
                {
                    Effects = new List<Effect> { new ImmuneToNeutralizeFollowUpEffect() }
                };
                skills.AddSkill(mjolnirSkill);
                break;
            case "Brash Assault":
                var brashAssaultSkillDamage = new Skill("Brash Assault Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30),
                        new ExtraDamageBasedOnOpponentFirstAttackEffect(30) },
                    Conditions = new List<Condition>
                    {
                        new OrCondition(new List<Condition>
                        {
                            new AndCondition(
                                new List<Condition> { new HealthBelowCondition(99), new InitiatesCombatCondition() }),
                            new AndCondition(new List<Condition>
                                { new OpponentFullHealthCondition(), new InitiatesCombatCondition() })
                        })
                    }
                };
                var brashAssaultSkillHybrid = new Skill("Brash Assault Hybrid", "Hybrid")
                {
                    Effects = new List<Effect>
                    {
                        new DefensePenaltyEffect(4), new ResistancePenaltyEffect(4), new GuaranteedFollowUpEffect()
                    },
                    Conditions = new List<Condition>
                    {
                        new OrCondition(new List<Condition>
                        {
                            new AndCondition(
                                new List<Condition> { new HealthBelowCondition(99), new InitiatesCombatCondition() }),
                            new AndCondition(new List<Condition>
                                { new OpponentFullHealthCondition(), new InitiatesCombatCondition() })
                        })
                    }
                };
                skills.AddSkill(brashAssaultSkillDamage);
                skills.AddSkill(brashAssaultSkillHybrid);
                break;
            case "Melee Breaker":
                var meleeBreakerSkill = new Skill("Melee Breaker", "Follow Up")
                {
                    Effects = new List<Effect> { new NeutralizeFollowUpEffect(), new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition>
                    {
                        new OrCondition(new List<Condition>
                        {
                            new OpponentWeaponUsedCondition("Sword"),
                            new OpponentWeaponUsedCondition("Axe"),
                            new OpponentWeaponUsedCondition("Lance")
                        }),
                        new HealthAboveCondition(50)
                    }
                };
                skills.AddSkill(meleeBreakerSkill);
                break;
            case "Range Breaker":
                var rangeBreakerSkill = new Skill("Range Breaker", "Follow Up")
                {
                    Effects = new List<Effect> { new NeutralizeFollowUpEffect(), new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition>
                    {
                        new OrCondition(new List<Condition>
                        {
                            new OpponentWeaponUsedCondition("Magic"),
                            new OpponentWeaponUsedCondition("Bow")
                        }),
                        new HealthAboveCondition(50)
                    }
                };
                skills.AddSkill(rangeBreakerSkill);
                break;
            case "Pegasus Flight":
                var pegasusFlightSkillPenalty = new Skill("Pegasus Flight Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new DefensePenaltyEffect(4), new AttackPenaltyEffect(4) }
                };
                var pegasusFlightSkillSecondPenalty = new Skill("Pegasus Flight Second Penalty", "Penalty")
                {
                    Effects = new List<Effect>
                    {
                        new AttackPenaltyBasedOnResistanceDifferenceEffect(80),
                        new DefensePenaltyBasedOnResistanceDifferenceEffect(80)
                    },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition(-10) }
                };
                var pegasusFlightSkillFollowUp = new Skill("Pegasus Flight Follow Up", "Denial")
                {
                    Effects = new List<Effect> { new NeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition(-10), new SpeedAndResistanceDifferenceCondition() }
                };
                skills.AddSkill(pegasusFlightSkillPenalty);
                skills.AddSkill(pegasusFlightSkillSecondPenalty);
                skills.AddSkill(pegasusFlightSkillFollowUp);
                break;
            case "Wyvern Flight":
                var wyvernFlightSkillPenalty = new Skill("Wyvern Flight Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new DefensePenaltyEffect(4), new AttackPenaltyEffect(4) }
                };
                var wyvernFlightSkillSecondPenalty = new Skill("Wyvern Flight Second Penalty", "Penalty")
                {
                    Effects = new List<Effect>
                    {
                        new AttackPenaltyBasedOnDefenseDifferenceEffect(80),
                        new DefensePenaltyBasedOnDefenseDifferenceEffect(80)
                    },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition(-10) }
                };
                var wyvernFlightSkillFollowUp = new Skill("Wyvern Flight Follow Up", "Denial")
                {
                    Effects = new List<Effect> { new NeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition(-10), new SpeedAndDefenseDifferenceCondition() }
                };
                skills.AddSkill(wyvernFlightSkillPenalty);
                skills.AddSkill(wyvernFlightSkillFollowUp);
                skills.AddSkill(wyvernFlightSkillSecondPenalty);
                break;
            case "Null Follow-Up":
                var nullFollowUpSkill = new Skill("Null Follow-Up", "Follow Up")
                {
                    Effects = new List<Effect> { new ImmuneToGuaranteedFollowUpEffect(), new ImmuneToNeutralizeFollowUpEffect() }
                };
                skills.AddSkill(nullFollowUpSkill);
                break;
            case "Sturdy Impact":
                var sturdyImpactSkill = new Skill("Sturdy Impact", "Hybrid")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(10), new AttackBonusEffect(6), new NeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(sturdyImpactSkill);
                break;
            case "Mirror Impact":
                var mirrorImpactSkill = new Skill("Mirror Impact", "Hybrid")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(10), new AttackBonusEffect(6), new NeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(mirrorImpactSkill);
                break;
            case "Swift Impact":
                var swiftImpactSkill = new Skill("Swift Impact", "Hybrid")
                {
                    Effects = new List<Effect> { new ResistanceBonusEffect(10), new SpeedBonusEffect(6), new NeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(swiftImpactSkill);
                break;
            case "Steady Impact":
                var steadyImpactSkill = new Skill("Steady Impact", "Hybrid")
                {
                    Effects = new List<Effect> { new DefenseBonusEffect(10), new SpeedBonusEffect(6), new NeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(steadyImpactSkill);
                break;
            case "Slick Fighter":
                var slickFighterSkill = new Skill("Slick Fighter", "Hybrid")
                {
                    Effects = new List<Effect> { new NeutralizeAttackPenaltyEffect(), new NeutralizeDefensePenaltyEffect(),
                        new NeutralizeSpeedPenaltyEffect(), new NeutralizeResistancePenaltyEffect(), new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition>
                    {
                        new HealthAboveCondition(25), new OpponentInitiatesCombatCondition()
                    }
                };
                skills.AddSkill(slickFighterSkill);
                break;
            case "Wily Fighter":
                var wilyFighterSkill = new Skill("Wily Fighter", "Hybrid")
                {
                    Effects = new List<Effect> { new NeutralizeAttackBonusEffect(), new NeutralizeDefenseBonusEffect(),
                        new NeutralizeSpeedBonusEffect(), new NeutralizeResistanceBonusEffect(), new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition>
                    {
                        new HealthAboveCondition(25), new OpponentInitiatesCombatCondition()
                    }
                };
                skills.AddSkill(wilyFighterSkill);
                break;
            case "Savvy Fighter":
                var savvyFighterSkillFollowUp = new Skill("Savvy Fighter Follow Up", "Follow Up")
                {
                    Effects = new List<Effect> { new ImmuneToGuaranteedFollowUpEffect(), new ImmuneToNeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                var savvyFighterSkillDamage = new Skill("Savvy Fighter Damage", "Damage")
                {
                    Effects = new List<Effect> { new FirstAttackDamagePercentageReductionEffect(30) },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition(), new SpeedDifferenceCondition(-4) }
                };
                skills.AddSkill(savvyFighterSkillFollowUp);
                skills.AddSkill(savvyFighterSkillDamage);
                break;
            case "Flow Force":
                var flowForceHybrid = new Skill("Flow Force Hybrid", "Hybrid")
                {
                    Effects = new List<Effect> { new NeutralizeSpeedPenaltyEffect(), new NeutralizeAttackPenaltyEffect(),
                        new ImmuneToNeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(flowForceHybrid);
                break;
            case "Flow Refresh":
                var flowRefreshHybrid = new Skill("Flow Refresh Hybrid", "Hybrid")
                {
                    Effects = new List<Effect> { new ImmuneToNeutralizeFollowUpEffect(),
                        new HealAfterCombatEffect(10) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                skills.AddSkill(flowRefreshHybrid);
                break;
            case "Flow Feather":
                var flowFeatherFollowUp = new Skill("Flow Feather Follow Up", "Follow Up")
                {
                    Effects = new List<Effect> { new ImmuneToNeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var flowFeatherDamage = new Skill("Flow Feather Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraAndAbsoluteReductionDamageBasedOnResistanceEffect(70) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition(), new SpeedDifferenceCondition(-10)}     
                };
                skills.AddSkill(flowFeatherFollowUp);
                skills.AddSkill(flowFeatherDamage);
                break;
            case "Flow Flight":
                var flowFlightFollowUp = new Skill("Flow Flight Follow Up", "Follow Up")
                {
                    Effects = new List<Effect> { new ImmuneToNeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new InitiatesCombatCondition() }
                };
                var flowFlightDamage = new Skill("Flow Flight Damage", "Damage")
                {
                    Effects = new List<Effect> { new ExtraAndAbsoluteReductionDamageBasedOnDefenseEffect(70) },
                    Conditions = new List<Condition> { new InitiatesCombatCondition(), new SpeedDifferenceCondition(-10) }
                };
                skills.AddSkill(flowFlightFollowUp);
                skills.AddSkill(flowFlightDamage);
                break;
            case "Binding Shield":
                var bindingShieldSkillDenial = new Skill("Binding Shield Denial", "Denial")
                {
                    Effects = new List<Effect> { new CounterAttackDenialEffect() },
                    Conditions = new List<Condition> { new InitiatesCombatCondition(), new SpeedDifferenceCondition(5) }
                };
                var bindingShieldSkillFollowUp = new Skill("Binding Shield Follow Up", "Denial")
                {
                    Effects = new List<Effect> { new GuaranteedFollowUpEffect(), new NeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new SpeedDifferenceCondition(5) }
                };
                skills.AddSkill(bindingShieldSkillDenial);
                skills.AddSkill(bindingShieldSkillFollowUp);
                break;
            case "Sun-Twin Wing":
                var sunTwinWingSkilll = new Skill("Sun-Twin Wing", "Hybrid")
                {
                    Effects = new List<Effect> { new SpeedPenaltyEffect(5), new DefensePenaltyEffect(5),
                        new ImmuneToGuaranteedFollowUpEffect(), new ImmuneToNeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new HealthAboveCondition(25)}
                };
                skills.AddSkill(sunTwinWingSkilll);
                break;
            case "Dragon's Ire":
                var dragonsIreSkillHybrid = new Skill("Dragon's Ire Hybrid", "Hybrid")
                {
                    Effects = new List<Effect> { new AttackPenaltyEffect(4), new ResistancePenaltyEffect(4),
                        new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var dragonsIreSkillFollowUp= new Skill("Dragon's Ire Follow Up", "Follow Up")
                {
                    Effects = new List<Effect> { new ImmuneToNeutralizeFollowUpEffect() },
                    Conditions = new List<Condition>
                    {
                        new HealthAboveCondition(25),
                        new OpponentInitiatesCombatCondition()
                    }
                };
                skills.AddSkill(dragonsIreSkillHybrid);
                skills.AddSkill(dragonsIreSkillFollowUp);
                break;
            case "Black Eagle Rule":
                var blackEagleRuleSkillFollowUp = new Skill("Black Eagle Rule Follow Up", "Follow Up")
                {
                    Effects = new List<Effect> { new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                var blackEagleRuleSkillDamage = new Skill("Black Eagle Rule Damage", "Damage")
                {
                    Effects = new List<Effect> { new FollowUpDamagePercentageReductionEffect(80) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25),
                        new OpponentInitiatesCombatCondition() }
                };
                skills.AddSkill(blackEagleRuleSkillFollowUp);
                skills.AddSkill(blackEagleRuleSkillDamage);
                break;
            case "Blue Lion Rule":
                var blueLionRuleSkillDamage = new Skill("Blue Lion Rule Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionDefenseEffect() },
                    Conditions = new List<Condition> { new DefenseDifferenceCondition() }
                };
                var blueLionRuleSkillFollowUp = new Skill("Blue Lion Rule Follow Up", "Follow Up")
                {
                    Effects = new List<Effect> { new GuaranteedFollowUpEffect() },
                    Conditions = new List<Condition> { new OpponentInitiatesCombatCondition() }
                };
                skills.AddSkill(blueLionRuleSkillFollowUp);
                skills.AddSkill(blueLionRuleSkillDamage);
                break;
            case "New Divinity":
                var newDivinitySkillFollowUp = new Skill("New Divinity Follow Up", "Follow Up")
                {
                    Effects = new List<Effect> { new NeutralizeFollowUpEffect() },
                    Conditions = new List<Condition> { new HealthAboveCondition(40)}
                };
                var newDivinitySkillDamage = new Skill("New Divinity Damage", "Damage")
                {
                    Effects = new List<Effect> { new DamagePercentageReductionResistanceEffect() },
                    Conditions = new List<Condition>
                    {
                        new HealthAboveCondition(25),
                        new ResistanceDifferenceCondition()
                    }
                };
                var newDivinitySkillPenalty = new Skill("New Divinity Penalty", "Penalty")
                {
                    Effects = new List<Effect> { new ResistancePenaltyEffect(5), new AttackPenaltyEffect(5) },
                    Conditions = new List<Condition> { new HealthAboveCondition(25) }
                };
                skills.AddSkill(newDivinitySkillPenalty);
                skills.AddSkill(newDivinitySkillDamage);
                skills.AddSkill(newDivinitySkillFollowUp);
                break;
            case "Phys. Null Follow":
                var physNullFollowSkill = new Skill("Phys. Null Follow", "Hybrid")
                {
                    Effects = new List<Effect>
                    {
                        new SpeedPenaltyEffect(4), new DefensePenaltyEffect(4),
                        new ImmuneToNeutralizeFollowUpEffect(), new ImmuneToGuaranteedFollowUpEffect(),
                        new DamagePercentageReductionReductionEffect(50)
                    }
                };
                skills.AddSkill(physNullFollowSkill);
                break;
            case "Mag. Null Follow":
                var magNullFollowSkill = new Skill("Mag. Null Follow", "Hybrid")
                {
                    Effects = new List<Effect>
                    {
                        new SpeedPenaltyEffect(4), new ResistancePenaltyEffect(4),
                        new ImmuneToNeutralizeFollowUpEffect(), new ImmuneToGuaranteedFollowUpEffect(),
                        new DamagePercentageReductionReductionEffect(50)
                    }
                };
                skills.AddSkill(magNullFollowSkill);
                break;
        default:
                var unknownSkill = new Skill(skillName, "Unknown");
                skills.AddSkill((unknownSkill));
                break;
        }
        return skills;
    }


    public static  SkillsList InitiateSkills(NameList skillNames)
    {
        SkillsList skills = new();
        foreach (var skillName in skillNames)
        {
            AddSkills(skills, skillName);
        }
        return skills;
    }

    private static void AddSkills( SkillsList skills, string skillName)
    {
        SkillsList createdSkills = CreateSkill(skillName);
        skills.AddRangeSkills(createdSkills.AsEnumerable());
    }
}