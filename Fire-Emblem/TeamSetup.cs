using Fire_Emblem_View;

namespace Fire_Emblem;

public class TeamSetup
{
    private string _teamsFolder;
    private View _view;
    private bool _teamsValid = true;
    private string _chosenTeamFile;
    private Array _teamFiles;
    public List<List<Unit>> ChosenTeamInfo = new List<List<Unit>>();

    public TeamSetup(View view, string teamsFolder)
    {
        _teamsFolder = teamsFolder;
        _view = view;
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

    private void CheckMaxUnits()
    {
        foreach (List<Unit> team in ChosenTeamInfo) // Check if each team has at most 3 units and at least 1
        {
            if (team.Count > 3 || team.Count < 1)
            {
                _teamsValid = false;
                return;
            }
        }
    }

    private void CheckRepeatedUnits()
    {
        // If a unit is repeated in the same team the teams are invalid
        foreach (List<Unit> team in ChosenTeamInfo)
        {
            List<string> teamUnits = new List<string>();
            foreach (Unit unit in team)
            {
                if (teamUnits.Contains(unit.Name))
                {
                    _teamsValid = false;
                    
                    return;
                }
                teamUnits.Add(unit.Name);
            }
        }
    }

    private void CheckMaxAbilitiesPerUnit()
    {
        // If a unit has more than 2 abilities the teams are invalid
        foreach (List<Unit> team in ChosenTeamInfo)
        {
            foreach (Unit unit in team)
            {
                if (unit.Abilities.Count > 2)
                {
                    _teamsValid = false;
                    return;
                }
            }
        }
    }

    private void CheckRepeatedAbilitiesPerUnit()
    {
        // If an ability is repeated in a unit of the team the teams are invalid
        foreach (List<Unit> team in ChosenTeamInfo)
        {
            foreach (Unit unit in team)
            {
                List<string> abilities = new List<string>();
                foreach (string ability in unit.Abilities)
                {
                    if (abilities.Contains(ability))
                    {
                        _teamsValid = false;
                        return;
                    }
                    abilities.Add(ability);
                }
            }
        }
    }
    private void CheckTeams()
    {
        CheckMaxUnits();
        CheckRepeatedUnits();
        CheckMaxAbilitiesPerUnit();
        CheckRepeatedAbilitiesPerUnit();
    }
    private void InitializeChosenTeamInfo()
    {
        string[] team_file_lines = File.ReadAllLines(_chosenTeamFile);
        List<Unit> currentTeam = null;

        foreach (string line in team_file_lines)
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
        string[] parts = unitInfo.Split('(', 2); // Split into name and abilities (if there are any)
        string unitName = parts[0].Trim();
        List<string> abilities = new List<string>();
        if (parts.Length > 1)
        {
            string abilitiesPart = parts[1].TrimEnd(')');
            abilities = abilitiesPart.Split(',').Select(a => a.Trim()).ToList();
        }

        return new Unit(unitName, abilities);
    }
    public void SetupTeams()
    {
        ChooseTeam(ShowTeamOptions());
        InitializeChosenTeamInfo();
        CheckTeams();
    }
}