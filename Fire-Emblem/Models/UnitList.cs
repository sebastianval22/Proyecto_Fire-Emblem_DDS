using System.Collections;

namespace Fire_Emblem.Models;

public class UnitList : IEnumerable<Unit>
{
    
    private List<Unit> _unitList = new List<Unit>();
    
    public void AddUnit(Unit unit)
    {
        _unitList.Add(unit);
    }
    
    public int  CountUnits()
    {
        return _unitList.Count();
    }
    
    public IEnumerator<Unit> GetEnumerator()
    {
        return _unitList.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public Unit GetUnit(int index)
    {
       return _unitList[index];
    }
    
    public void RemoveAll(Predicate<Unit> match)
    {
        _unitList.RemoveAll(match);
    }
}