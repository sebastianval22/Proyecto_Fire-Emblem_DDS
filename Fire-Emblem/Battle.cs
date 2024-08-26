using Fire_Emblem_View;

namespace Fire_Emblem;

public class Battle
{
    private List<List<Unit>> _teams;
    private View _view;
    private int _attacking_player_number = 1;
    private int _defending_player_number = 2;
    private int _round = 1;
    private Damage _damage;
    
    public Battle(View view, List<List<Unit>> teams)
    {
        _view = view;
        _teams = teams;
        _damage = new Damage(view);
    }
    
    public void Start()
    {
        while (_teams[0].Count > 0 && _teams[1].Count > 0)
        {   
            Unit attacking_unit = ChooseUnit(_attacking_player_number);
            Unit defending_unit = ChooseUnit(_defending_player_number);
            _view.WriteLine($"Round {_round}: {attacking_unit.Name} (Player {_attacking_player_number}) comienza");
            int damage = _damage.CalculateDamage(attacking_unit, defending_unit);
            _view.WriteLine($"{attacking_unit.Name} ataca a {defending_unit.Name} con {damage} de daño");
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