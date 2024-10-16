namespace Fire_Emblem.TeamChecks;

public class MaxUnits : ITeamCheck
{
    private bool _validTeam = true;

    public bool Check(List<List<Unit>> teams)
    {
        foreach (List<Unit> team in teams)
        {
            CheckTeamSize(team);
        }
        return _validTeam;
    }

    private void CheckTeamSize(List<Unit> team)
    {
        if (TeamSizeIsInvalid(team))
        {
            _validTeam = false;
        }
    }

    private bool TeamSizeIsInvalid(List<Unit> team)
    {
        return team.Count > 3 || team.Count < 1;
    }
}