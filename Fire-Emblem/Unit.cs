using Fire_Emblem.Skills;

namespace Fire_Emblem
{
    public class Unit
    {
        public string Name { get; set; }
        public string Weapon { get; set; }
        public string Gender { get; set; }
        public string DeathQuote { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Defense { get; set; }
        public int Resistance { get; set; }
        public List<Skill> Skills { get; set; }
        public Unit RecentOpponent { get; set; }
        public bool HasFirstAttackSkill { get; set; }
        public Dictionary<string, int> ActiveSkillsEffects { get; set; }

        public bool AttackBonusNeutralized { get; set; }
        public bool DefenseBonusNeutralized { get; set; }
        public bool SpeedBonusNeutralized { get; set; }
        public bool ResistanceBonusNeutralized { get; set; }
        public bool AttackPenaltyNeutralized { get; set; }
        public bool DefensePenaltyNeutralized { get; set; }
        public bool SpeedPenaltyNeutralized { get; set; }
        public bool ResistancePenaltyNeutralized { get; set; }

        private int _backupAttack;
        private int _backupSpeed;
        private int _backupDefense;
        private int _backupResistance;

        public Unit(string name, List<Skill> skills)
        {
            Name = name;
            Skills = skills;
            InitializeUnitData();
            InitializeActiveSkillsEffects();
            ResetNeutralizations();
        }

        private void InitializeUnitData()
        {
            var unitData = new UnitData();
            unitData.InitializeUnit(this);
        }

        private void InitializeActiveSkillsEffects()
        {
            ActiveSkillsEffects = new Dictionary<string, int>
            {
                {"AttackBonus", 0},
                {"DefenseBonus", 0},
                {"SpeedBonus", 0},
                {"ResistanceBonus", 0},
                {"AttackPenalty", 0},
                {"DefensePenalty", 0},
                {"SpeedPenalty", 0},
                {"ResistancePenalty", 0},
                {"FirstAttackAttackBonus", 0},
                {"FirstAttackDefenseBonus", 0},
                {"FirstAttackResistanceBonus", 0},
                {"FirstAttackAttackPenalty", 0},
                {"FirstAttackDefensePenalty", 0},
                {"FirstAttackResistancePenalty", 0},
                {"FollowUpAttackAttackBonus", 0},
                {"FollowUpAttackDefenseBonus", 0},
                {"FollowUpAttackResistanceBonus", 0},
                {"FollowUpAttackAttackPenalty", 0},
                {"FollowUpAttackDefensePenalty", 0},
                {"FollowUpAttackResistancePenalty", 0}
            };
        }

        public void UpdateHPStatus(int damage)
        {
            CurrentHP = Math.Max(CurrentHP - damage, 0);
        }

        public bool IsUnitAlive()
        {
            return CurrentHP > 0;
        }

        public void SaveAttributes()
        {
            _backupAttack = Attack;
            _backupSpeed = Speed;
            _backupDefense = Defense;
            _backupResistance = Resistance;
        }

        public void RestoreBackupAttributes()
        {
            Attack = _backupAttack;
            Speed = _backupSpeed;
            Defense = _backupDefense;
            Resistance = _backupResistance;
        }

        public Dictionary<string, int> ObtainAttributes()
        {
            return new Dictionary<string, int>
            {
                { "Attack", Attack },
                { "Speed", Speed },
                { "Defense", Defense },
                { "Resistance", Resistance }
            };
        }

        public void RestoreSpecificAttributes(Dictionary<string, int> attributes)
        {
            if (attributes.ContainsKey("Attack")) Attack = attributes["Attack"];
            if (attributes.ContainsKey("Speed")) Speed = attributes["Speed"];
            if (attributes.ContainsKey("Defense")) Defense = attributes["Defense"];
            if (attributes.ContainsKey("Resistance")) Resistance = attributes["Resistance"];
        }

        public void ApplyEffects()
        {
            ApplyBonuses();
            ApplyPenalties();

            if (HasFirstAttackEffects())
            {
                SaveAttributes();
                ApplyFirstAttackEffects();
                HasFirstAttackSkill = true;
            }
        }

        private void ApplyBonuses()
        {
            if (!AttackBonusNeutralized) Attack += ActiveSkillsEffects["AttackBonus"];
            if (!DefenseBonusNeutralized) Defense += ActiveSkillsEffects["DefenseBonus"];
            if (!SpeedBonusNeutralized) Speed += ActiveSkillsEffects["SpeedBonus"];
            if (!ResistanceBonusNeutralized) Resistance += ActiveSkillsEffects["ResistanceBonus"];
        }

        private void ApplyPenalties()
        {
            if (!AttackPenaltyNeutralized) Attack += ActiveSkillsEffects["AttackPenalty"];
            if (!DefensePenaltyNeutralized) Defense += ActiveSkillsEffects["DefensePenalty"];
            if (!SpeedPenaltyNeutralized) Speed += ActiveSkillsEffects["SpeedPenalty"];
            if (!ResistancePenaltyNeutralized) Resistance += ActiveSkillsEffects["ResistancePenalty"];
        }

        private bool HasFirstAttackEffects()
        {
            return ActiveSkillsEffects.Any(kv => kv.Key.Contains("FirstAttack") && kv.Value != 0);
        }

        private void ApplyFirstAttackEffects()
        {
            if (!AttackBonusNeutralized) Attack += ActiveSkillsEffects["FirstAttackAttackBonus"];
            if (!DefenseBonusNeutralized) Defense += ActiveSkillsEffects["FirstAttackDefenseBonus"];
            if (!ResistanceBonusNeutralized) Resistance += ActiveSkillsEffects["FirstAttackResistanceBonus"];

            if (!AttackPenaltyNeutralized) Attack += ActiveSkillsEffects["FirstAttackAttackPenalty"];
            if (!DefensePenaltyNeutralized) Defense += ActiveSkillsEffects["FirstAttackDefensePenalty"];
            if (!ResistancePenaltyNeutralized) Resistance += ActiveSkillsEffects["FirstAttackResistancePenalty"];
        }

        public void ApplyFollowUpAttackEffects()
        {
            ApplyFollowUpBonuses();
            ApplyFollowUpPenalties();
        }

        private void ApplyFollowUpBonuses()
        {
            if (!AttackBonusNeutralized) Attack += ActiveSkillsEffects["FollowUpAttackAttackBonus"];
            if (!DefenseBonusNeutralized) Defense += ActiveSkillsEffects["FollowUpAttackDefenseBonus"];
            if (!ResistanceBonusNeutralized) Resistance += ActiveSkillsEffects["FollowUpAttackResistanceBonus"];
        }

        private void ApplyFollowUpPenalties()
        {
            if (!AttackPenaltyNeutralized) Attack += ActiveSkillsEffects["FollowUpAttackAttackPenalty"];
            if (!DefensePenaltyNeutralized) Defense += ActiveSkillsEffects["FollowUpAttackDefensePenalty"];
            if (!ResistancePenaltyNeutralized) Resistance += ActiveSkillsEffects["FollowUpAttackResistancePenalty"];
        }

        public void ResetActiveSkillsEffects()
        {
            foreach (var key in ActiveSkillsEffects.Keys.ToList())
            {
                ActiveSkillsEffects[key] = 0;
            }

            HasFirstAttackSkill = false;
            ResetNeutralizations();
        }

        private void ResetNeutralizations()
        {
            AttackBonusNeutralized = false;
            DefenseBonusNeutralized = false;
            SpeedBonusNeutralized = false;
            ResistanceBonusNeutralized = false;
            AttackPenaltyNeutralized = false;
            DefensePenaltyNeutralized = false;
            SpeedPenaltyNeutralized = false;
            ResistancePenaltyNeutralized = false;
        }
    }
}