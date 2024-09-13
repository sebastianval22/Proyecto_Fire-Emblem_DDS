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
    public void ApplySkills(RoundFight roundFight)

    {
        foreach (Skill unitSkill in this.Skills.Reverse<Skill>())
        {
            if (unitSkill.SkillType == "Bonus")
            {
                unitSkill.ApplyEffects(this, roundFight);
            }
        }
    }
}