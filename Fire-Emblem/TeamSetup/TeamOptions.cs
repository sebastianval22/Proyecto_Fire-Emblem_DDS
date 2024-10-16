using Fire_Emblem_View;

namespace Fire_Emblem.TeamSetup;

public static class TeamOptions
{
    private static string _teamsFolder;
    private static string[] _teamFiles;
    private static View _view;

    private static void DisplayTeamFiles()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] files = Directory.GetFiles(_teamsFolder, "*.txt");
        Array.Sort(files);
        _teamFiles = files;
        for (int i = 0; i < files.Length; i++)
        {
            _view.WriteLine($"{i}: {Path.GetFileName(files[i])}");
        }
    }

    private static string GetChosenTeamName()
    {
        return _view.ReadLine();
    }

    private static string ShowTeamOptions()
    {
        DisplayTeamFiles();
        return GetChosenTeamName();
    }

    private static bool IsValidTeamIndex(string nameChosenTeam, out int index)
    {
        return int.TryParse(nameChosenTeam, out index) && index < _teamFiles.Length;
    }

    public static string ChooseTeam(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        string nameChosenTeam = ShowTeamOptions();
        if (IsValidTeamIndex(nameChosenTeam, out int index))
        {
            string chosenTeamFile = _teamFiles.GetValue(index).ToString();
            return chosenTeamFile;
        }

        return "Equipo en archivo no encontrado";
    }
}