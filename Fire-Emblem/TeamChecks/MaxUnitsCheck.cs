namespace Fire_Emblem.TeamChecks;

public class MaxUnitsCheck : ITeamCheck
{
    public bool Check(List<List<Unit>> teams)
    {
        foreach (List<Unit> team in teams)
        {
            if (team.Count > 3 || team.Count < 1)
            {
                return false;
            }
        }
        return true;
    }
}