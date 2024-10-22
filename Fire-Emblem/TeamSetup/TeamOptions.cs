using Fire_Emblem.Exceptions;
using Fire_Emblem.Views;

namespace Fire_Emblem.TeamSetup;

public static class TeamOptions
{
    private static string _teamsFolder;
    private static string[] _teamFiles;

    private static void DisplayTeamFiles()
    {
        string[] files = Directory.GetFiles(_teamsFolder, "*.txt");
        Array.Sort(files);
        _teamFiles = files;
        TeamSetupView.ShowTeamOptions(files);
    }



    private static string ShowTeamOptions()
    {
        DisplayTeamFiles();
        return TeamSetupView.GetChosenTeamName();
    }

    private static bool IsValidTeamIndex(string nameChosenTeam, out int index)
    {
        return int.TryParse(nameChosenTeam, out index) && index < _teamFiles.Length;
    }

    public static string ChooseTeam( string teamsFolder)
    {
        _teamsFolder = teamsFolder;
        string nameChosenTeam = ShowTeamOptions();
        if (IsValidTeamIndex(nameChosenTeam, out int index))
        {
            string chosenTeamFile = _teamFiles.GetValue(index).ToString();
            return chosenTeamFile;
        }
        throw new ChosenTeamNotFoundException();
    }
}