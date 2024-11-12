using Fire_Emblem_View;
using Fire_Emblem.Views;
using Fire_Emblem.Controllers;


namespace Fire_Emblem;

public class Game
{

    private readonly string _teamsFolder;
    
    public Game(View view, string teamsFolder)
    {
        BaseView.Initialize(view);
        _teamsFolder = teamsFolder;
    }

    public void Play()
    { 
        var teamSetup = new TeamSetupController(_teamsFolder);
        teamSetup.SetupTeams();
        if (teamSetup.IsTeamsValid())
        {
            var battle = new BattleController(teamSetup.ChosenTeamInfo);
            battle.Start();
        }
        else
        {
            GameView.ShowInvalidTeamFileMessage();
        }
    }
}