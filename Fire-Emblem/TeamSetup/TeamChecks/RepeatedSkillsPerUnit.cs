using Fire_Emblem.Skills;

namespace Fire_Emblem.TeamChecks;

public class RepeatedSkillsPerUnit : ITeamCheck
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
        foreach (Unit unit in team)
        {
            CheckUnitSkills(unit);
        }
    }

    private void CheckUnitSkills(Unit unit)
    {
        List<string> skillNames = new List<string>();
        foreach (Skill skill in unit.Skills)
        {
            CheckSkillNames(skillNames, skill);
        }
    }
    
    private void CheckSkillNames(List<string> skillNames, Skill skill)
    {
        if (SkillIsRepeated(skillNames, skill))
        {
            _validTeam = false;
            return;
        }
        skillNames.Add(skill.SkillData.Name);
    }

    private bool SkillIsRepeated(List<string> skillNames, Skill skill)
    {
        return skillNames.Contains(skill.SkillData.Name);
    }
}