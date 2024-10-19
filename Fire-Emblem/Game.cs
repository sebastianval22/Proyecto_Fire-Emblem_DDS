using Fire_Emblem_View;
using Fire_Emblem.Views;
using Fire_Emblem.Controllers;
using Fire_Emblem.TeamSetup;
using Fire_Emblem.TeamSetup.TeamChecks;

namespace Fire_Emblem;

public class Game
{
    private View _view;
    private string _teamsFolder;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }

    public void Play()
    {
        BaseView.Initialize(_view);
        var teamSetup = new TeamSetupController(_teamsFolder);
        teamSetup.SetupTeams();
        if (teamSetup.IsTeamsValid())
        {
            var battle = new BattleController(teamSetup.ChosenTeamInfo);
            battle.Start();
        }
        else
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
    }

}