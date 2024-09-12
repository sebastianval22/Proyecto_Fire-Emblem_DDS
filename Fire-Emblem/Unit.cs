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
    public int Resistence { get; set; }
    public List<Skill> Skills { get; set; }
    
    // Backup attributes
    private int _backupAttack;
    private int _backupSpeed;
    private int _backupDefence;
    private int _backupResistence;

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
        _backupResistence = Resistence;
    }

    // Restore saved attributes
    public void RestoreAttributes()
    {
        Attack = _backupAttack;
        Speed = _backupSpeed;
        Defence = _backupDefence;
        Resistence = _backupResistence;
    }
}