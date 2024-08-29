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
    public List<string> Abilities { get; set; }

    public Unit(string name, List<string> abilities)
    {
        Name = name;
        Abilities = abilities;
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
}