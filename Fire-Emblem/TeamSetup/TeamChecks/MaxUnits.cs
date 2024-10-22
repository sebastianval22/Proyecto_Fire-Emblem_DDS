namespace Fire_Emblem.TeamSetup.TeamChecks;

public class MaxUnits : ITeamCheck
{
    private bool _validTeam = true;

    public bool Check(TeamList teams)
    {
        foreach (UnitList team in teams)
        {
            CheckTeamSize(team);
        }
        return _validTeam;
    }

    private void CheckTeamSize(UnitList team)
    {
        if (TeamSizeIsInvalid(team))
        {
            _validTeam = false;
        }
    }

    private bool TeamSizeIsInvalid(UnitList team)
    {
        return team.CountUnits() > 3 || team.CountUnits() < 1;
    }
}