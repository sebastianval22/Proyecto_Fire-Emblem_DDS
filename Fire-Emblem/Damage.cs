using Fire_Emblem_View;

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
        _advantageFactor = DetermineAdvantageFactor();
        var defense_points = DetermineDefensePoints();
        var attack_points = (int)Math.Truncate(_attacker.Attack * _advantageFactor);
        return (Math.Max(attack_points-defense_points, 0));
    }

    private int DetermineDefensePoints()
    {
        switch (_attacker.Weapon)
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
                return 1;
        }
    }

    private float DetermineAdvantageFactorSword()
    {
        switch (_defender.Weapon)
        {
            case "Lance":
                return 0.8f;
            case "Axe":
                return 1.2f;
            default:
                return 1.0f;
        }
    }

    private float DetermineAdvantageFactorLance()
    {
        switch (_defender.Weapon)
        {
            case "Axe":
                return 0.8f;
            case "Sword":
                return 1.2f;
            default:
                return 1.0f;
        }
    }

    private float DetermineAdvantageFactorAxe()
    {
        switch (_defender.Weapon)
        {
            case "Sword":
                return 0.8f;
            case "Lance":
                return 1.2f;
            default:
                return 1.0f;
        }
    }

    public void ShowAdvantageMessage()
    {
        if (_advantageFactor > 1)
        {
            _view.WriteLine($"{_attacker.Name} ({_attacker.Weapon}) tiene ventaja con respecto a {_defender.Name} ({_defender.Weapon})");
        }
        else if (_advantageFactor < 1)
        {
            _view.WriteLine($"{_defender.Name} ({_defender.Weapon}) tiene ventaja con respecto a {_attacker.Name} ({_attacker.Weapon})");
        }
        else
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
        
    }
}
