using Fire_Emblem_View;
using Fire_Emblem.AdvantageWeapons;

namespace Fire_Emblem;

public class Damage
{
    private Unit _attacker;
    private Unit _defender; 
    private View _view;
    private float _advantageFactor;
    
    public Damage(View view)
    {
        _view = view;
    }
    
    public int CalculateDamage(Unit attacker, Unit defender)
    {
        _attacker = attacker;
        _defender = defender;
        DetermineAdvantageFactor();
        var defensePoints = DetermineDefensePoints();
        Console.WriteLine("Defense points: " + defensePoints);
        Console.WriteLine("Attack points: " + _attacker.Attack);
        var attackPoints = (int)Math.Truncate(_attacker.Attack * _advantageFactor);
        
        return (Math.Max(attackPoints-defensePoints, 0));
    }

    private int DetermineDefensePoints()
    {
        return _attacker.Weapon switch
        {
            "Magic" => _defender.Resistance,
            _ => _defender.Defense
        };
    }
    
    private void DetermineAdvantageFactor()
    {
        IWeaponAdvantage advantage = _attacker.Weapon switch
        {
            "Sword" => new SwordAdvantage(),
            "Lance" => new LanceAdvantage(),
            "Axe" => new AxeAdvantage(),
            _ => null
        };
        _advantageFactor = advantage?.DetermineAdvantageFactor(_defender) ?? 1;
    }

    public void ShowAdvantageMessage(Unit attacker, Unit defender)
    {
        _attacker = attacker;
        _defender = defender;
        DetermineAdvantageFactor();
        string message = _advantageFactor switch
        {
            > 1 => $"{_attacker.Name} ({_attacker.Weapon}) tiene ventaja con respecto a {_defender.Name} ({_defender.Weapon})",
            < 1 => $"{_defender.Name} ({_defender.Weapon}) tiene ventaja con respecto a {_attacker.Name} ({_attacker.Weapon})",
            _ => "Ninguna unidad tiene ventaja con respecto a la otra"
        };
        _view.WriteLine(message);
    }
}
