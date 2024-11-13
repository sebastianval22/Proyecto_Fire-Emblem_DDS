using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.TeamSetup.TeamChecks;

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
        NameList teamUnitsName = new NameList();
        foreach (Unit unit in team)
        {
            CheckUnitName(teamUnitsName, unit);
        }
    }

    private void CheckUnitName(NameList team, Unit unit)
    {
        if (UnitIsRepeated(team, unit))
        {
            _validTeam = false;
            return;
        }
        team.Add(unit.Name);
    }

    private bool UnitIsRepeated(NameList team, Unit unit)
    {
        return team.Contains(unit.Name);
    }
}