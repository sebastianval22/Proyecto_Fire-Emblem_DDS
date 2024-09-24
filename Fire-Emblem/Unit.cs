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
        public Attack Attack { get; set; }
        public Defense Defense { get; set; }
        public Speed Speed { get; set; }
        public Resistance Resistance { get; set; }
        public List<Skill> Skills { get; set; }
        public Unit RecentOpponent { get; set; }
        public bool HasFirstAttackSkill { get; set; }
        public List<Stat> Stats { get; set; }



        public Unit(string name, List<Skill> skills)
        {
            Name = name;
            Skills = skills;
            InitializeUnitData();
            foreach (var stat in Stats)
            {
                stat.ResetEffects();
            }
        }

        private void InitializeUnitData()
        {
            Attack = new Attack();
            Defense = new Defense();
            Speed = new Speed();
            Resistance = new Resistance();
            Stats = new List<Stat> { Attack, Defense, Speed, Resistance };
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
            foreach (var stat in Stats)
            {
                stat.SaveValue();
            }
        }

        public void RestoreBackupAttributes()
        {
            foreach (var stat in Stats)
            {
                stat.RestoreValue();
            }
        }
        
        public Dictionary<string, int> ObtainAttributes()
        {
            return Stats.ToDictionary(stat => stat.GetType().Name, stat => stat.Value);
        }

        public void RestoreSpecificAttributes(Dictionary<string, int> attributes)
        {
            foreach (var stat in Stats)
            {
                if (attributes.TryGetValue(stat.GetType().Name, out var value))
                {
                    stat.Value = value;
                }
            }
        }
        public void ApplyEffects()
        {
            foreach (var stat in Stats)
            {
                stat.ApplyEffects();
            }

            if (HasFirstAttackEffects())
            {
                SaveAttributes();
                ApplyFirstAttackEffects();
                HasFirstAttackSkill = true;
            }
        }

        private bool HasFirstAttackEffects()
        {

            return Stats.Any(stat => stat.FirstAttackBonus != 0 || stat.FirstAttackPenalty != 0);
        }

        private void ApplyFirstAttackEffects()
        {
            foreach (var stat in Stats)
            {
                stat.ApplyFirstAttackEffects();
            }
        }

        public void ApplyFollowUpAttackEffects()
        {
            foreach (var stat in Stats)
            {
                stat.ApplyFollowUpAttackEffects();
            }
        }

        public void ResetActiveSkillsEffects()
        {
            foreach (var stat in Stats)
            {
                stat.ResetEffects();
            }
            HasFirstAttackSkill = false;
        }
    }
}