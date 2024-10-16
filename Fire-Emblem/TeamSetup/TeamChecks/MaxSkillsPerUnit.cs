namespace Fire_Emblem.TeamChecks;

public class MaxSkillsPerUnit : ITeamCheck

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

    private void CheckTeamUnits(List < Unit > team)
    {
        foreach (Unit unit in team)
        { 
            CheckUnitSkills(unit);
        }
    }

    private void CheckUnitSkills(Unit unit)
    {
        if (UnitHasTooManySkills(unit))
        {
            _validTeam = false;
        }

    }
    
    private bool UnitHasTooManySkills(Unit unit)
    {
        return unit.Skills.Count > 2;
    }
}