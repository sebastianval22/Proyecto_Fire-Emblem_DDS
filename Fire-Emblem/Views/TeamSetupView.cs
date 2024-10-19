namespace Fire_Emblem.Views;

public class TeamSetupView
{
    public static void ShowTeamOptions(string[] teamOptions)
    {
        BaseView.ShowMessage("Elige un archivo para cargar los equipos");
        for (int i = 0; i < teamOptions.Length; i++)
        {
           BaseView.ShowMessage($"{i}: {Path.GetFileName(teamOptions[i])}");
        }
    }

    public static string GetChosenTeamName()
    {
        return BaseView.ReadLine();
    }

}