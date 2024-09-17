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
        while (_teams[0].Count > 0 && _teams[1].Count > 0)
        {   
            _attackingUnit = ChooseUnit(_attackingPlayerNumber);
            _defendingUnit = ChooseUnit(_defendingPlayerNumber);
            _view.WriteLine($"Round {_round}: {_attackingUnit.Name} (Player {_attackingPlayerNumber}) comienza");
            Console.WriteLine($"attacking unit:{ _attackingUnit.Name} health: {_attackingUnit.CurrentHP} defending unit: {_defendingUnit.Name} health: {_defendingUnit.CurrentHP}");
            _roundFightController.Fight(_attackingUnit, _defendingUnit);
            UpdateTeams();
            _view.WriteLine($"{_attackingUnit.Name} ({_attackingUnit.CurrentHP}) : {_defendingUnit.Name} ({_defendingUnit.CurrentHP})");
            _round++;
            (_attackingPlayerNumber, _defendingPlayerNumber) = (_defendingPlayerNumber, _attackingPlayerNumber);

        }
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
    
    private Unit ChooseUnit(int player_number)
    {
        List<Unit> team = _teams[player_number - 1];
        _view.WriteLine($"Player {player_number} selecciona una opción");
        for (int i = 0; i < team.Count; i++)
        {
            _view.WriteLine($"{i}: {team[i].Name}");
        }
        string option_chosen_unit = _view.ReadLine();
        if (int.TryParse(option_chosen_unit, out int index))
        {
            return team[index];
        }
        else
        {
            // Input is not a valid integer
            return ChooseUnit(player_number); // Recursively call the method to prompt again
        }
    }
    private void AddAlterationBaseStats()
    {
        foreach (List<Unit> team in _teams)
        {
            foreach (Unit unit in team)
            {
                foreach (Skill skill in unit.Skills)
                {
                    if (skill.SkillType == "Base Stats")
                    {
                        skill.ActivateBaseStatsSkillEffects(unit);
                    }
                }
            }
        }
    }
}