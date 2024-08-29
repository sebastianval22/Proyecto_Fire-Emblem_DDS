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
        var defensePoints = DetermineDefensePoints();
        var attackPoints = (int)Math.Truncate(_attacker.Attack * _advantageFactor);
        return (Math.Max(attackPoints-defensePoints, 0));
    }

    private int DetermineDefensePoints()
    {
        return _attacker.Weapon switch
        {
            "Magic" => _defender.Resistence,
            _ => _defender.Defence
        };
    }
    
    private float DetermineAdvantageFactor() =>
        _attacker.Weapon switch
        {
            "Sword" => DetermineAdvantageFactorSword(),
            "Lance" => DetermineAdvantageFactorLance(),
            "Axe" => DetermineAdvantageFactorAxe(),
            _ => 1
        };
    
    
    private float DetermineAdvantageFactorSword() =>
        _defender.Weapon switch
        {
            "Lance" => 0.8f,
            "Axe" => 1.2f,
            _ => 1.0f
        };

    private float DetermineAdvantageFactorLance() =>
        _defender.Weapon switch
        {
            "Axe" => 0.8f,
            "Sword" => 1.2f,
            _ => 1.0f
        };

    private float DetermineAdvantageFactorAxe() =>
        _defender.Weapon switch
        {
            "Sword" => 0.8f,
            "Lance" => 1.2f,
            _ => 1.0f
        };

    public void ShowAdvantageMessage()
    {
        string message = _advantageFactor switch
        {
            > 1 => $"{_attacker.Name} ({_attacker.Weapon}) tiene ventaja con respecto a {_defender.Name} ({_defender.Weapon})",
            < 1 => $"{_defender.Name} ({_defender.Weapon}) tiene ventaja con respecto a {_attacker.Name} ({_attacker.Weapon})",
            _ => "Ninguna unidad tiene ventaja con respecto a la otra"
        };
        _view.WriteLine(message);
    }
}
