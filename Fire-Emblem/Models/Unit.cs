namespace Fire_Emblem.Models
{
    public class Unit
    {
        
        public string Name { get; set; }
        public string Weapon { get; set; }
        public string Gender { get; set; }
        public string DeathQuote { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int BeforeRoundHP { get; set; }
        public Attack Attack { get; set; }
        public Defense Defense { get; set; }
        public Speed Speed { get; set; }
        public Resistance Resistance { get; set; }
        public DamageEffectStat DamageEffectStat { get; set; }
        public HpEffectStat HpEffectStat { get; set; }
        public SkillsList Skills { get; set; }
        public Unit RecentOpponent { get; set; }
        public bool HasFirstAttackSkill { get; set; }
        public bool CanCounterAttack { get; set; } = true;
        public bool CanFollowUpAttack { get; set; } = true;
        public bool HasDenialOfAttackDenialEffect { get; set; } = false;
        public bool HasHadFirstCombatStarting { get; set; } = false;
        public bool HasHadFirstCombatNotStarting { get; set; } = false;
        public bool HasAttackedInRound { get; set; } = false;
        public bool HasFollowedUpInRound { get; set; } = false;
        public int GuaranteedFollowUpEffects { get; set; } = 0;
        public int NeutralizeFollowUpEffects { get; set; } = 0;
        public bool IsImmuneToGuaranteedFollowUpEffects { get; set; } = false;
        public bool IsImmuneToNeutralizeFollowUpEffects { get; set; } = false;
        public List<Stat> Stats { get; set; }
        public UnitList UnitAllies { get; set; }
    
        public Unit(string name, SkillsList skills)
        {
            Name = name;
            Skills = skills;
        }
    }
}