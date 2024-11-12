using System.Collections;

namespace Fire_Emblem.Models;

public class NameList : IEnumerable<string>
{
    private List<string> _names = new List<string>();
    
    public void AddName(string unitName)
    {
        _names.Add(unitName);
    }
    
    public bool Contains(string unitName)
    {
        return _names.Contains(unitName);
    }
    public IEnumerator<string> GetEnumerator()
    {
        return _names.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public int CountNames()
    {
        return _names.Count();
    }

    public void ToList(IEnumerable<string> names)
    {
        _names = names.ToList();
    }
}