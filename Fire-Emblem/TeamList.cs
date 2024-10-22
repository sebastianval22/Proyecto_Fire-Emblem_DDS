using System.Collections;

namespace Fire_Emblem;

public class TeamList : IEnumerable <UnitList>
{
    private List<UnitList> teamList = new List<UnitList>();
    public void AddTeam(UnitList team)
    {
        teamList.Add(team);
    }
    public IEnumerator<UnitList> GetEnumerator()
    {
        return teamList.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public UnitList GetTeam(int index)
    {
        return teamList[index - 1];
    }
    public int NumberOfTeams()
    {
        return teamList.Count();
    }
    
}