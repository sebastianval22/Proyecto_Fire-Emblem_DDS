using Fire_Emblem_View;

namespace Fire_Emblem;

public class Damage
{
    private Unit _attacker;
    private Unit _defender; 
    private View _view;
    
    public Damage(View view)
    {
        _view = view;
    }
    
    public int CalculateDamage(Unit attacker, Unit defender)
    {
        _attacker = attacker;
        _defender = defender;
        var advantageFactor = DetermineAdvantageFactor();
        var defense_points = DetermineDefensePoints();
        var attack_points = (int)Math.Truncate(_attacker.Attack * advantageFactor);
        return (Math.Max(attack_points-defense_points, 0));
    }

    private int DetermineDefensePoints()
    {
        switch (_defender.Weapon)
        {
            case "Magic":
                return _defender.Resistence;
            default:
                return _defender.Defence;
        }
    }
    private float DetermineAdvantageFactor()
    {
        switch (_attacker.Weapon)
        {
            case "Sword":
                return DetermineAdvantageFactorSword();
            case "Lance":
                return DetermineAdvantageFactorLance();
            case "Axe":
                return DetermineAdvantageFactorAxe();
            default:
                _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
                return 1;
        }
    }

    private float DetermineAdvantageFactorSword()
    {
        switch (_defender.Weapon)
        {
            case "Lance":
                _view.WriteLine($"{_defender.Name} ({_defender.Weapon}) tiene ventaja con respecto a {_attacker.Name} ({_attacker.Weapon})");
                return 0.8f;
            case "Axe":
                _view.WriteLine($"{_attacker.Name} ({_attacker.Weapon}) tiene ventaja con respecto a {_defender.Name} ({_defender.Weapon})");
                return 1.2f;
            default:
                _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
                return 1.0f;
        }
    }

    private float DetermineAdvantageFactorLance()
    {
        switch (_defender.Weapon)
        {
            case "Axe":
                _view.WriteLine($"{_defender.Name} ({_defender.Weapon}) tiene ventaja con respecto a {_attacker.Name} ({_attacker.Weapon})");
                return 0.8f;
            case "Sword":
                _view.WriteLine($"{_attacker.Name} ({_attacker.Weapon}) tiene ventaja con respecto a {_defender.Name} ({_defender.Weapon})");
                return 1.2f;
            default:
                _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
                return 1.0f;
        }
    }

    private float DetermineAdvantageFactorAxe()
    {
        switch (_defender.Weapon)
        {
            case "Sword":
                _view.WriteLine($"{_defender.Name} ({_defender.Weapon}) tiene ventaja con respecto a {_attacker.Name} ({_attacker.Weapon})");
                return 0.8f;
            case "Lance":
                _view.WriteLine($"{_attacker.Name} ({_attacker.Weapon}) tiene ventaja con respecto a {_defender.Name} ({_defender.Weapon})");
                return 1.2f;
            default:
                _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
                return 1.0f;
        }
    }
}
