using Fire_Emblem_View;

namespace Fire_Emblem;

public class Battle
{
    private List<List<Unit>> _teams;
    private View _view;
    private int _attacking_player_number = 1;
    private int _defending_player_number = 2;
    private int _round = 1;
    private Unit _attacking_unit;
    private Unit _defending_unit;
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
            _attacking_unit = ChooseUnit(_attacking_player_number);
            _defending_unit = ChooseUnit(_defending_player_number);
            _view.WriteLine($"Round {_round}: {_attacking_unit.Name} (Player {_attacking_player_number}) comienza");
            _attackController.FirstAttack(_attacking_unit, _defending_unit);
            CounterAttack();
            FollowUp();
            UpdateTeams();
            _view.WriteLine($"{_attacking_unit.Name} ({_attacking_unit.Current_HP}) : {_defending_unit.Name} ({_defending_unit.Current_HP})");
            _round++;
            (_attacking_player_number, _defending_player_number) = (_defending_player_number, _attacking_player_number);

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
    
    public void UpdateTeams()
    {
        for (int i = 0; i < _teams.Count; i++)
        {
            _teams[i].RemoveAll(unit => !unit.IsUnitAlive());
        }
    }
    
    public void CounterAttack()
    {
        if (AreBothUnitsAlive())
        {
            
            _attackController.Attack(_defending_unit, _attacking_unit);
        }
        
    }

    private bool AreBothUnitsAlive()
    {
        return (_attacking_unit.IsUnitAlive() && _defending_unit.IsUnitAlive());
    }

    public void FollowUp()
    {
        int difference_speed = _attacking_unit.Speed - _defending_unit.Speed;
        if (AreBothUnitsAlive())
        {
            if (difference_speed >= 5)
            {
                _attackController.Attack(_attacking_unit, _defending_unit);
            }
            else if (difference_speed <= -5)

            {
                _attackController.Attack(_defending_unit, _attacking_unit);
            }
            else
            {
                _view.WriteLine("Ninguna unidad puede hacer un follow up");
            }
        }
        
    }
    public Unit ChooseUnit(int player_number)
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