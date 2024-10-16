using Fire_Emblem_View;
using Fire_Emblem.Skills;

namespace Fire_Emblem;

public class Battle
{
    private List<List<Unit>> _teams;
    private View _view;
    private int _attackingPlayerNumber = 1;
    private int _defendingPlayerNumber = 2;
    private int _round = 1;
    private Unit _attackingUnit;
    private Unit _defendingUnit;
    private RoundFight _roundFightController;
    
    public Battle(View view, List<List<Unit>> teams)
    {
        _view = view;
        _teams = teams;
        _roundFightController = new RoundFight(_view);
    }
    
    public void Start()
    {
        AddAlterationBaseStats();
        while (TeamsAreAlive())
        {   
            ExecuteRound();
            UpdateTeams();
            DisplayRoundResult();
            PrepareNextRound();
        }
        DisplayWinner();
    }

    private bool TeamsAreAlive()
    {
        return _teams[0].Count > 0 && _teams[1].Count > 0;
    }

    private void ExecuteRound()
    {
        _attackingUnit = ChooseUnit(_attackingPlayerNumber);
        _defendingUnit = ChooseUnit(_defendingPlayerNumber);
        _view.WriteLine($"Round {_round}: {_attackingUnit.Name} (Player {_attackingPlayerNumber}) comienza");
        _roundFightController.Fight(_attackingUnit, _defendingUnit);
    }

    private void DisplayRoundResult()
    {
        _view.WriteLine($"{_attackingUnit.Name} ({_attackingUnit.CurrentHP}) : {_defendingUnit.Name} ({_defendingUnit.CurrentHP})");
    }

    private void PrepareNextRound()
    {
        _round++;
        (_attackingPlayerNumber, _defendingPlayerNumber) = (_defendingPlayerNumber, _attackingPlayerNumber);
    }

    private void DisplayWinner()
    {
        if (_teams[0].Count == 0)
        {
            _view.WriteLine("Player 2 ganó");
        }
        else
        {
            _view.WriteLine("Player 1 ganó");
        }
    }

    private void UpdateTeams()
    {
        for (int i = 0; i < _teams.Count; i++)
        {
            _teams[i].RemoveAll(unit => !unit.IsUnitAlive());
        }
    }
    
    private Unit ChooseUnit(int playerNumber)
    {
        List<Unit> team = _teams[playerNumber - 1];
        DisplayTeamOptions(playerNumber, team);
        return GetChosenUnit(playerNumber, team);
    }

    private void DisplayTeamOptions(int playerNumber, List<Unit> team)
    {
        _view.WriteLine($"Player {playerNumber} selecciona una opción");
        for (int i = 0; i < team.Count; i++)
        {
            _view.WriteLine($"{i}: {team[i].Name}");
        }
    }

    private Unit GetChosenUnit(int playerNumber, List<Unit> team)
    {
        string optionChosenUnit = _view.ReadLine();
        if (int.TryParse(optionChosenUnit, out int index))
        {
            return team[index];
        }
        else
        {
            return ChooseUnit(playerNumber); 
        }
    }

    private void AddAlterationBaseStats()
    {
        foreach (List<Unit> team in _teams)
        {
            AddBaseStatsToTeam(team);
        }
    }

    private void AddBaseStatsToTeam(List<Unit> team)
    {
        foreach (Unit unit in team)
        {
            AddBaseStatsToUnit(unit);
        }
    }

    private void AddBaseStatsToUnit(Unit unit)
    {
        foreach (Skill skill in unit.Skills)
        {
            ActivateBaseStatsSkillIfApplicable(skill, unit);
        }
    }

    private void ActivateBaseStatsSkillIfApplicable(Skill skill, Unit unit)
    {
        if (skill.SkillData.SkillType == "Base Stats")
        {
            skill.ActivateBaseStatsSkillEffects(unit);
        }
    }
}