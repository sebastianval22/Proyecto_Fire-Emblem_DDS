using Fire_Emblem_View;
using Fire_Emblem.TeamChecks;
using Fire_Emblem.Skills;

namespace Fire_Emblem.TeamSetup;

public class TeamSetup
{
    private string _teamsFolder;
    private View _view;
    private bool _teamsValid = true;
    private string _chosenTeamFile;
    public List<List<Unit>> ChosenTeamInfo = new List<List<Unit>>();
    private List<ITeamCheck> _teamChecks;

    public TeamSetup(View view, string teamsFolder)
    {
        _teamsFolder = teamsFolder;
        _view = view;
        _teamChecks = new List<ITeamCheck>  // If more checks are added they will be executed in the order they are added
        {
            new MaxUnitsCheck(),
            new RepeatedUnitsCheck(),
            new MaxSkillsPerUnitCheck(),
            new RepeatedSkillsPerUnitCheck()
        };
    }

    public bool IsTeamsValid()
    {
        return _teamsValid;
    }
    
    private void CheckTeams()
    {
        foreach (var check in _teamChecks)
        {
            if (!check.Check(ChosenTeamInfo))
            {
                _teamsValid = false;
                return;
            }
        }
    }
    private void InitializeChosenTeamInfo()
    {
        string[] teamFileLines = File.ReadAllLines(_chosenTeamFile);
        List<Unit> currentTeam = null;

        foreach (string line in teamFileLines)
        {
            if (line.StartsWith("Player 1 Team") || line.StartsWith("Player 2 Team"))
            {
                if (currentTeam != null)
                {
                    ChosenTeamInfo.Add(currentTeam);
                }
                currentTeam = new List<Unit>();
            }
            else if (currentTeam != null)
            {
                currentTeam.Add(CreateUnit(line));
            }
        }
        if (currentTeam != null)
        {
            ChosenTeamInfo.Add(currentTeam);
        }
    }

    private Unit CreateUnit(string unitInfo)
    {
        string[] parts = unitInfo.Split('(', 2); // Split into name and Skills (if there are any)
        string unitName = parts[0].Trim();
        List<string> skillNames = new List<string>();
        if (parts.Length > 1)
        {
            string skillsPart = parts[1].TrimEnd(')');
            skillNames = skillsPart.Split(',').Select(a => a.Trim()).ToList();
        }

        List<Skill> Skills = SkillFactory.InitiateSkills(skillNames);

        return new Unit(unitName, Skills);
    }
    public void SetupTeams()
    {
        _chosenTeamFile = TeamOptions.ChooseTeam(_view, _teamsFolder);
        InitializeChosenTeamInfo();
        CheckTeams();
    }
}