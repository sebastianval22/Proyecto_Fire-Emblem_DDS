using Fire_Emblem.Skills;

namespace Fire_Emblem;


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
    public int Defence { get; set; }
    public int Resistance { get; set; }
    public List<Skill> Skills { get; set; }
    public Unit RecentOpponent { get; set; } 
    public bool HasFirstAttackSkill { get; set; }
    public Dictionary<string, int> ActiveSkillsEffects{ get; set; }
    
    public bool BonusesHaveBeenNeutralized { get; set; }
    public bool PenaltyHasBeenNeutralized { get; set; }
    
    // Backup attributes
    private int _backupAttack;
    private int _backupSpeed;
    private int _backupDefence;
    private int _backupResistance;
    

    public Unit(string name, List<Skill> skills)
    {
        Name = name;
        Skills = skills;
        var unitData = new UnitData();
        unitData.InitializeUnit(this);
        ActiveSkillsEffects= new Dictionary<string, int>
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
            {"FirstAttackResistancePenalty", 0}
        };
        BonusesHaveBeenNeutralized = false;
        PenaltyHasBeenNeutralized = false;
    }

    public void UpdateHPStatus(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
        }
    }

    public bool IsUnitAlive()
    {
        return CurrentHP > 0;
    }
    // Save current attributes
    public void SaveAttributes()
    {
        _backupAttack = Attack;
        _backupSpeed = Speed;
        _backupDefence = Defence;
        _backupResistance = Resistance;
    }

    // Restore saved attributes
    public void RestoreBackupAttributes()
    {
        Attack = _backupAttack;
        Speed = _backupSpeed;
        Defence = _backupDefence;
        Resistance = _backupResistance;
    }
    public Dictionary<string, int> ObtainAttributes()
    {
        return new Dictionary<string, int>
        {
            { "Attack", Attack },
            { "Speed", Speed },
            { "Defence", Defence },
            { "Resistance", Resistance }
        };
    }

    // Restore saved attributes
    public void RestoreSpecificAttributes(Dictionary<string, int> attributes)
    {
        if (attributes.ContainsKey("Attack")) Attack = attributes["Attack"];
        if (attributes.ContainsKey("Speed")) Speed = attributes["Speed"];
        if (attributes.ContainsKey("Defence")) Defence = attributes["Defence"];
        if (attributes.ContainsKey("Resistance")) Resistance = attributes["Resistance"];
    }
    public void ApplyEffects()
    {
        if (!BonusesHaveBeenNeutralized)
        {
            Attack += ActiveSkillsEffects["AttackBonus"];
            Defence += ActiveSkillsEffects["DefenseBonus"];
            Speed += ActiveSkillsEffects["SpeedBonus"];
            Resistance += ActiveSkillsEffects["ResistanceBonus"];
        }
        if (!PenaltyHasBeenNeutralized)
        {
            Attack += ActiveSkillsEffects["AttackPenalty"];
            Defence += ActiveSkillsEffects["DefensePenalty"];
            Speed += ActiveSkillsEffects["SpeedPenalty"];
            Resistance += ActiveSkillsEffects["ResistancePenalty"];
        }
        if (ActiveSkillsEffects.Any(kv => kv.Key.Contains("FirstAttack") && kv.Value != 0))
        {
            SaveAttributes();
            ApplyFirstAttackEffects();
            HasFirstAttackSkill = true;
        }
    }
    private void ApplyFirstAttackEffects()
    {
        if (!BonusesHaveBeenNeutralized)
        {
            Attack += ActiveSkillsEffects["FirstAttackAttackBonus"];
            Defence += ActiveSkillsEffects["FirstAttackDefenseBonus"];
            Resistance += ActiveSkillsEffects["FirstAttackResistanceBonus"]; 
        }
        if (!PenaltyHasBeenNeutralized)
        {
            Attack += ActiveSkillsEffects["FirstAttackAttackPenalty"];
            Defence += ActiveSkillsEffects["FirstAttackDefensePenalty"];
            Resistance += ActiveSkillsEffects["FirstAttackResistancePenalty"];
        }
    }
    public void ResetActiveSkillsEffects()
    {
        var keys = ActiveSkillsEffects.Keys.ToList();
        foreach (var key in keys)
        {
            ActiveSkillsEffects[key] = 0;
            BonusesHaveBeenNeutralized = false;
            PenaltyHasBeenNeutralized = false;
        }
    }
}