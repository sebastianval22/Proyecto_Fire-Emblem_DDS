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
        var units = LoadUnitData();
        var unitData = FindUnitData(units, unit.Name);

        if (unitData != null)
        {
            ApplyUnitData(unit, unitData);
        }
    }

    private List<UnitData> LoadUnitData()
    {
        string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "characters.json");
        string jsonContent = File.ReadAllText(jsonFilePath);
        return JsonSerializer.Deserialize<List<UnitData>>(jsonContent);
    }

    private UnitData FindUnitData(List<UnitData> units, string unitName)
    {
        return units.FirstOrDefault(u => u.Name.Trim() == unitName);
    }

    private void ApplyUnitData(Unit unit, UnitData unitData)
    {
        unit.Weapon = unitData.Weapon.Trim();
        unit.Gender = unitData.Gender.Trim();
        unit.DeathQuote = unitData.DeathQuote.Trim();
        unit.MaxHP = int.Parse(unitData.HP.Trim());
        unit.CurrentHP = unit.MaxHP;
        unit.Attack.Value = int.Parse(unitData.Atk.Trim());
        unit.Speed.Value = int.Parse(unitData.Spd.Trim());
        unit.Defense.Value = int.Parse(unitData.Def.Trim());
        unit.Resistance.Value = int.Parse(unitData.Res.Trim());
    }
}