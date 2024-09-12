using Fire_Emblem_View;

namespace Fire_Emblem.TeamSetup;

public static class TeamOptions
{
    private static string _teamsFolder;
    private static string[] _teamFiles;
    private static View _view;
    
    private static string ShowTeamOptions()
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
    
    public static string ChooseTeam(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        string nameChosenTeam = ShowTeamOptions();
        if (int.TryParse(nameChosenTeam, out int index) && index <= _teamFiles.Length)
        {
            string chosenTeamFile = _teamFiles.GetValue(index).ToString();
            return chosenTeamFile;
        }

        return "Equipo en archivo no encontrado";
    }
    
}