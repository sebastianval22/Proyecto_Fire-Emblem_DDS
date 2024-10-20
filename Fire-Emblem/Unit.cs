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
    

        public Unit(string name, List<Skill> skills)
        {
            Name = name;
            Skills = skills;
        }

    }
}