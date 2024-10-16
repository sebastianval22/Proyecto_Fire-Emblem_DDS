namespace Fire_Emblem.TeamChecks;

public class RepeatedUnits : ITeamCheck
{
    private bool _validTeam = true;

    public bool Check(List<List<Unit>> teams)
    {
        foreach (List<Unit> team in teams)
        {
            CheckTeamUnits(team);
        }
        return _validTeam;
    }

    private void CheckTeamUnits(List<Unit> team)
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