﻿using Fire_Emblem_View;

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
        var teamSetup = new TeamSetup(_view, _teamsFolder);
        teamSetup.SetupTeams();
        if (teamSetup.TeamsValid)
        {
            List<List<Unit>> teams = teamSetup.ObtainTeams();
            var battle = new Battle(_view, teams);
            battle.Start();
        }
        else
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
    }

}