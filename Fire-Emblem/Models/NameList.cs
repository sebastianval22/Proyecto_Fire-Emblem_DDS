using System.Collections;

namespace Fire_Emblem.Models;

public class NameList : IEnumerable<string>
{
    private List<string> _names = new List<string>();
    
    public void Add(string name)
    {
        _names.Add(name);
    }
    
    public bool Contains(string name)
    {
        return _names.Contains(name);
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