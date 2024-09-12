using Fire_Emblem_View;
using Fire_Emblem.Skills.Effects;

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
        var teamSetup = new TeamSetup.TeamSetup(_view, _teamsFolder);
        teamSetup.SetupTeams();
        if (teamSetup.IsTeamsValid())
        {
            EffectLogger.Initialize(_view);
            var battle = new Battle(_view, teamSetup.ChosenTeamInfo);
            battle.Start();
        }
        else
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
    }

}