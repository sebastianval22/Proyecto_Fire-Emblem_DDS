namespace Fire_Emblem.TeamSetup.TeamChecks;

public class RepeatedUnits : ITeamCheck
{
    private bool _validTeam = true;

    public bool Check(TeamList teams)
    {
        foreach (UnitList team in teams)
        {
            CheckTeamUnits(team);
        }
        return _validTeam;
    }

    private void CheckTeamUnits(UnitList team)
    {
        List<string> teamUnits = new List<string>();
        foreach (Unit unit in team)
        {
            CheckUnitName(teamUnits, unit);
        }
    }

    private void CheckUnitName(List<string> teamUnits, Unit unit)
    {
        if (UnitIsRepeated(teamUnits, unit))
        {
            _validTeam = false;
            return;
        }
        teamUnits.Add(unit.Name);
    }

    private bool UnitIsRepeated(List<string> teamUnits, Unit unit)
    {
        return teamUnits.Contains(unit.Name);
    }
}