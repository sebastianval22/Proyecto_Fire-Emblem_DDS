using Fire_Emblem.TeamSetup;
using Fire_Emblem.TeamSetup.TeamChecks;
using Fire_Emblem.Skills;

namespace Fire_Emblem.Controllers;

public class TeamSetupController
{
    private readonly string _teamsFolder;
    private bool _teamsValid = true;
    private string _chosenTeamFile;
    public List<List<Unit>> ChosenTeamInfo = new List<List<Unit>>();
    private readonly List<ITeamCheck> _teamChecks;
    private readonly UnitController _unitController = new UnitController();
    public TeamSetupController( string teamsFolder)
    {
        _teamsFolder = teamsFolder;

        _teamChecks = new List<ITeamCheck> 
        {
            new MaxUnits(),
            new RepeatedUnits(),
            new RepeatedSkillsPerUnit()
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
            PerformCheck(check);
        }
    }

    private void PerformCheck(ITeamCheck check)
    {
        if (IsTeamInvalidForSpecificCheck(check))
        {
            _teamsValid = false;
        }
    }
    private bool IsTeamInvalidForSpecificCheck(ITeamCheck check)
    {
        return !check.Check(ChosenTeamInfo);
    }
    
    private void InitializeChosenTeamInfo()
    {
        string[] teamFileLines = File.ReadAllLines(_chosenTeamFile);
        List<Unit> currentTeam = null;

        foreach (string line in teamFileLines)
        {
            currentTeam = ProcessLine(line, currentTeam);
        }
        AddCurrentTeamToList(currentTeam);
    }

    private List<Unit> ProcessLine(string line, List<Unit> currentTeam)
    {
        if (IsTeamHeader(line))
        {
            AddCurrentTeamToList(currentTeam);
            return new List<Unit>();
        }
        else if (currentTeam != null)
        {
            currentTeam.Add(CreateUnit(line));
        }
        return currentTeam;
    }

    private bool IsTeamHeader(string line)
    {
        return line.StartsWith("Player 1 Team") || line.StartsWith("Player 2 Team");
    }

    private void AddCurrentTeamToList(List<Unit> currentTeam)
    {
        if (currentTeam != null)
        {
            ChosenTeamInfo.Add(currentTeam);
        }
    }

    private Unit CreateUnit(string unitInfo)
    {
        string unitName = ExtractUnitName(unitInfo);
        List<string> skillNames = ExtractSkillNames(unitInfo);
        if (MaxSkillsPerUnit.Check(skillNames))
        {
            _teamsValid = false;
        }
        List<Skill> skills = SkillFactory.InitiateSkills(skillNames);
        Unit newUnit = new Unit(unitName, skills);
        _unitController.InitializeUnitData(newUnit);
        return newUnit;
    }

    private string ExtractUnitName(string unitInfo)
    {
        string[] parts = unitInfo.Split('(', 2);
        return parts[0].Trim();
    }

    private  static List<string> ExtractSkillNames(string unitInfo)
    {
        string[] parts = unitInfo.Split('(', 2);
        if (parts.Length > 1)
        {
            string skillsPart = parts[1].TrimEnd(')');
            return skillsPart.Split(',').Select(a => a.Trim()).ToList();
        }
        return new List<string>();
    }

    public void SetupTeams()
    {
        _chosenTeamFile = TeamOptions.ChooseTeam(_teamsFolder);
        InitializeChosenTeamInfo();
        CheckTeams();
    }
}