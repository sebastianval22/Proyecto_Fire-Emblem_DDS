namespace Fire_Emblem.TeamChecks;

public class MaxSkillsPerUnitCheck : ITeamCheck
{
    public bool Check(List<List<Unit>> teams)
    {
        foreach (List<Unit> team in teams)
        {
            foreach (Unit unit in team)
            {
                if (unit.Skills.Count > 2)
                {
                    return false;
                }
            }
        }
        return true;
    }
}