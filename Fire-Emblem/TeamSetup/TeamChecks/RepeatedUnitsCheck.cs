namespace Fire_Emblem.TeamChecks;

public class RepeatedUnitsCheck : ITeamCheck
{
    public bool Check(List<List<Unit>> teams)
    {
        foreach (List<Unit> team in teams)
        {
            List<string> teamUnits = new List<string>();
            foreach (Unit unit in team)
            {
                if (teamUnits.Contains(unit.Name))
                {
                    return false;
                }
                teamUnits.Add(unit.Name);
            }
        }
        return true;
    }
}