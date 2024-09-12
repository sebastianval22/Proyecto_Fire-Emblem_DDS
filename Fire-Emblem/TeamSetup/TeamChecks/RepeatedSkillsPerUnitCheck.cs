using Fire_Emblem.Skills;

namespace Fire_Emblem.TeamChecks;

public class RepeatedSkillsPerUnitCheck : ITeamCheck
{
    public bool Check(List<List<Unit>> teams)
    {
        foreach (List<Unit> team in teams)
        {
            foreach (Unit unit in team)
            {
                List<string> skillNames = new List<string>();
                foreach (Skill skill in unit.Skills)
                {
                    if (skillNames.Contains(skill.Name))
                    {
                        return false;
                    }
                    skillNames.Add(skill.Name);
                }
            }
        }
        return true;
    }
}