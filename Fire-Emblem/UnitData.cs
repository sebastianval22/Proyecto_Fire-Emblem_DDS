using System.Text.Json;

namespace Fire_Emblem;

public class UnitData
{
    public string Name { get; set; }
    public string Weapon { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    public string HP { get; set; }
    public string Atk { get; set; }
    public string Spd { get; set; }
    public string Def { get; set; }
    public string Res { get; set; }
    
    public void InitializeUnit(Unit unit)
    {
        string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "characters.json");
        string jsonContent = File.ReadAllText(jsonFilePath);
        var units = JsonSerializer.Deserialize<List<UnitData>>(jsonContent);

        foreach (var unitData in units)
        {
            if (unitData.Name.Trim() == unit.Name)
            {
                unit.Weapon = unitData.Weapon.Trim();
                unit.Gender = unitData.Gender.Trim();
                unit.DeathQuote = unitData.DeathQuote.Trim();
                unit.MaxHP = int.Parse(unitData.HP.Trim());
                unit.CurrentHP = unit.MaxHP;
                unit.Attack = int.Parse(unitData.Atk.Trim());
                unit.Speed = int.Parse(unitData.Spd.Trim());
                unit.Defence = int.Parse(unitData.Def.Trim());
                unit.Resistence = int.Parse(unitData.Res.Trim());
                break;
            }
        }
    }
}