using Fire_Emblem_View;

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
    private AttackController _attackController;
    
    public Battle(View view, List<List<Unit>> teams)
    {
        _view = view;
        _teams = teams;
        _attackController = new AttackController(view);
    }
    
    public void Start()
    {
        while (_teams[0].Count > 0 && _teams[1].Count > 0)
        {   
            _attackingUnit = ChooseUnit(_attackingPlayerNumber);
            _defendingUnit = ChooseUnit(_defendingPlayerNumber);
            _view.WriteLine($"Round {_round}: {_attackingUnit.Name} (Player {_attackingPlayerNumber}) comienza");
            _attackController.FirstAttack(_attackingUnit, _defendingUnit);
            CounterAttack();
            FollowUpAttack();
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
    
    private void CounterAttack()
    {
        if (AreBothUnitsAlive())
        {
            _attackController.Attack(_defendingUnit, _attackingUnit);
        }
        
    }

    private bool AreBothUnitsAlive()
    {
        return (_attackingUnit.IsUnitAlive() && _defendingUnit.IsUnitAlive());
    }

    private void FollowUpAttack()
    {
        var differenceSpeed = _attackingUnit.Speed - _defendingUnit.Speed;
        if (AreBothUnitsAlive())
        {
            switch (differenceSpeed)
            {
                case >= 5:
                    _attackController.Attack(_attackingUnit, _defendingUnit);
                    break;
                case <= -5:
                    _attackController.Attack(_defendingUnit, _attackingUnit);
                    break;
                default:
                    _view.WriteLine("Ninguna unidad puede hacer un follow up");
                    break;
            }
        
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
    
}