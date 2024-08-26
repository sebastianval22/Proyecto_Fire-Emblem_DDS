using Fire_Emblem_View;

namespace Fire_Emblem;

public class TeamSetup
{
    private string _teamsFolder;
    private View _view;
    private bool _teamsValid = true;
    private string _teamFile;
    
    public TeamSetup(View view, string teamsFolder)
    {
        _teamsFolder = teamsFolder;
        _view = view;
    }

    public void ChooseTeam()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] files = Directory.GetFiles(_teamsFolder, "*.txt");
        Array.Sort(files);

        for (int i = 0; i < files.Length; i++)
        {
            _view.WriteLine($"{i}: {Path.GetFileName(files[i])}");
        }
        string option_chosen_team = _view.ReadLine();
        if (int.TryParse(option_chosen_team, out int index) && index <= files.Length)
        {
            _teamFile = files[index];
            List<List<Unit>> teams_info = ObtainTeams();
            
            CheckTeams(teams_info);
        }
        else
        {
            _teamsValid = false;
        }
    }
    
    public void CheckTeams(List<List<Unit>> teams_info)
    {
        if (teams_info.Count != 2)
        {
            _teamsValid = false;
            return;
        }
        foreach (List<Unit> team in teams_info) // Check if each team has at most 3 units and at least 1
        {
            if (team.Count > 3 || team.Count < 1)
            {
                _teamsValid = false;
                _view.WriteLine("UNITCOUNT");
                return;
            }
        }
        // If a unit is repeated in the same team the teams are invalid
        foreach (List<Unit> team in teams_info)
        {
            List<string> teamUnits = new List<string>();
            foreach (Unit unit in team)
            {
                _view.WriteLine(unit.DeathQuote);
                if (teamUnits.Contains(unit.Name))
                {
                    _view.WriteLine("UNITREPEATED");
                    _teamsValid = false;
                    
                    return;
                }
                teamUnits.Add(unit.Name);
            }
        }
        // If a unit has more than 2 abilities the teams are invalid
        foreach (List<Unit> team in teams_info)
        {
            foreach (Unit unit in team)
            {
                if (unit.Abilities.Count > 2)
                {
                    _teamsValid = false;
                    _view.WriteLine("ABILITYREPEATED");
                    return;
                }
            }
        }
        // If an ability is repeated in a unit of the team the teams are invalid
        foreach (List<Unit> team in teams_info)
        {
            foreach (Unit unit in team)
            {
                List<string> abilities = new List<string>();
                foreach (string ability in unit.Abilities)
                {
                    if (abilities.Contains(ability))
                    {
                        _teamsValid = false;
                        _view.WriteLine("HABABABREPEATED");
                        return;
                    }
                    abilities.Add(ability);
                }
            }
        }
    }
    public List<List<Unit>> ObtainTeams()
    {
        string[] team_file_lines = File.ReadAllLines(_teamFile);
        List<List<Unit>> teams_info = new List<List<Unit>>();
        List<Unit> currentTeam = null;

        foreach (string line in team_file_lines)
        {
            if (line.StartsWith("Player 1 Team") || line.StartsWith("Player 2 Team"))
            {
                if (currentTeam != null)
                {
                    teams_info.Add(currentTeam);
                }
                currentTeam = new List<Unit>();
            }
            else if (currentTeam != null)
            {
                string[] parts = line.Split('(', 2); // Split into name and abilities (if there are any)
                string unitName = parts[0].Trim();
                List<string> abilities = new List<string>();
                if (parts.Length > 1)
                {
                    string abilitiesPart = parts[1].TrimEnd(')');
                    abilities = abilitiesPart.Split(',').Select(a => a.Trim()).ToList();
                }

                currentTeam.Add(new Unit(unitName, abilities));
            }
        }
        if (currentTeam != null)
        {
            teams_info.Add(currentTeam);
        }

        return teams_info;
    }
    public bool TeamsValid
    {
        get { return _teamsValid; }
        private set { _teamsValid = value; }
    }
    public void SetupTeams()
    {
        ChooseTeam();
        
    }
}