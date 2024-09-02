namespace Fire_Emblem.TeamChecks;

public class RepeatedSkillsPerUnitCheck : ITeamCheck
{
    public bool Check(List<List<Unit>> teams)
    {
        foreach (List<Unit> team in teams)
        {
            foreach (Unit unit in team)
            {
                List<string> skills = new List<string>();
                foreach (string skill in unit.Skills)
                {
                    if (skills.Contains(skill))
                    {
                        return false;
                    }
                    skills.Add(skill);
                }
            }
        }
        return true;
    }
}