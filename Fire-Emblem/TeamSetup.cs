using Fire_Emblem_View;
using Fire_Emblem.TeamChecks;

namespace Fire_Emblem;

public class TeamSetup
{
    private string _teamsFolder;
    private View _view;
    private bool _teamsValid = true;
    private string _chosenTeamFile;
    private Array _teamFiles;
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

    private string ShowTeamOptions()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] files = Directory.GetFiles(_teamsFolder, "*.txt");
        Array.Sort(files);
        _teamFiles = files;
        for (int i = 0; i < files.Length; i++)
        {
            _view.WriteLine($"{i}: {Path.GetFileName(files[i])}");
        }

        string nameChosenTeam = _view.ReadLine();
        return nameChosenTeam;
    }

    private void ChooseTeam(string nameChosenTeam)
    {

        if (int.TryParse(nameChosenTeam, out int index) && index <= _teamFiles.Length)
        {
            _chosenTeamFile = _teamFiles.GetValue(index).ToString();
        }
        else
        {
            _teamsValid = false;
        }
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
        List<string> Skills = new List<string>();
        if (parts.Length > 1)
        {
            string skillsPart = parts[1].TrimEnd(')');
            Skills = skillsPart.Split(',').Select(a => a.Trim()).ToList();
        }

        return new Unit(unitName, Skills);
    }
    public void SetupTeams()
    {
        ChooseTeam(ShowTeamOptions());
        InitializeChosenTeamInfo();
        CheckTeams();
    }
}