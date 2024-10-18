using Fire_Emblem.Skills;
using Fire_Emblem.Skills.Effects;


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
        public Attack Attack { get; set; }
        public Defense Defense { get; set; }
        public Speed Speed { get; set; }
        public Resistance Resistance { get; set; }
        public DamagePercentageReductionStat DamagePercentageReductionStat { get; set; }
        public DamageAbsoluteReductionStat DamageAbsoluteReductionStat { get; set; }
        public ExtraDamageStat ExtraDamageStat { get; set; }
        public List<Skill> Skills { get; set; }
        public Unit RecentOpponent { get; set; }
        public bool HasFirstAttackSkill { get; set; }
        public bool HasHadFirstCombatStarting { get; set; } = false;
        public bool HasHadFirstCombatNotStarting { get; set; } = false;

    public List<Stat> Stats { get; set; }

        private readonly UnitEffectsService _effectsService;
        private readonly UnitAttributesService _attributesService;

        public Unit(string name, List<Skill> skills)
        {
            Name = name;
            Skills = skills;
            InitializeUnitData();
            foreach (var stat in Stats)
            {
                stat.ResetEffects();
            }
            _effectsService = new UnitEffectsService();
            _attributesService = new UnitAttributesService();
        }

        private void InitializeUnitData()
        {
            InitializeStats();
            InitializeStatList();
            InitializeDamageStats();
            InitializeUnitDataObject();
        }

        private void InitializeStats()
        {
            Attack = new Attack();
            Defense = new Defense();
            Speed = new Speed();
            Resistance = new Resistance();
        }

        private void InitializeStatList()
        {
            Stats = new List<Stat> { Attack, Defense, Speed, Resistance };
        }

        private void InitializeDamageStats()
        {
            DamagePercentageReductionStat = new DamagePercentageReductionStat(1, 1, 1);
            DamageAbsoluteReductionStat = new DamageAbsoluteReductionStat(0, 0);
            ExtraDamageStat = new ExtraDamageStat(0, 0);
        }

        private void InitializeUnitDataObject()
        {
            var unitData = new UnitData();
            unitData.InitializeUnit(this);
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
            _attributesService.SaveAttributes(this);
        }

        public void RestoreBackupAttributes()
        {
            _attributesService.RestoreBackupAttributes(this);
        }

        public Dictionary<string, int> ObtainAttributes()
        {
            return _attributesService.ObtainAttributes(this);
        }

        public void RestoreSpecificAttributes(Dictionary<string, int> attributes)
        {
            _attributesService.RestoreSpecificAttributes(this, attributes);
        }

        public void ApplyEffects()
        {
            _effectsService.ApplyEffects(this);
        }

        public void ApplyFollowUpAttackEffects()
        {
            _effectsService.ApplyFollowUpAttackEffects(this);
        }

        public void ResetActiveSkillsEffects()
        {
            _effectsService.ResetActiveSkillsEffects(this);
        }
        
    }
}