namespace Fire_Emblem.Models;

public class Attributes
{
    private Dictionary<string, int> _attributes = new Dictionary<string, int>();

    public Attributes(Unit unit)
    {
        _attributes = unit.Stats.ToDictionary(stat => stat.GetType().Name, stat => stat.Value);

    }
    public int GetAttributeValue(string key)
    {
        return _attributes[key];
    }
    public void SaveAttribute(string key, int value)
    {
        _attributes[key] = value;
    }

}