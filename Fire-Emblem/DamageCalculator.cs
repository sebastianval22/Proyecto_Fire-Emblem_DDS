using Fire_Emblem_View;
using Fire_Emblem.AdvantageWeapons;

namespace Fire_Emblem;

public class DamageCalculator
{
    private Unit _attacker;
    private Unit _defender; 
    private View _view;
    private float _advantageFactor;
    
    public DamageCalculator(View view)
    {
        _view = view;
    }
    
    public int CalculateFollowUpDamage(Unit attacker, Unit defender)
    {
        InitializeCombatants(attacker, defender);
        int damage = ApplyExtraDamage(CalculateBaseDamage(), attacker.ExtraDamageStat.Value );
        int newDamage = ApplyDamagePercentageReduction(damage, defender.DamagePercentageReductionStat.Value*defender.DamagePercentageReductionStat.FollowUpAttackValue);
        return ApplyDamageAbsoluteReduction(newDamage, defender.DamageAbsoluteReductionStat.Value);
    }

    public int CalculateDamageFirstAttack(Unit attacker, Unit defender)
    {
        InitializeCombatants(attacker, defender);
        int damage = ApplyExtraDamage(CalculateBaseDamage(), attacker.ExtraDamageStat.Value + attacker.ExtraDamageStat.FirstAttackValue);
        int newDamage = ApplyDamagePercentageReduction(damage, defender.DamagePercentageReductionStat.Value * defender.DamagePercentageReductionStat.FirstAttackValue);
        return ApplyDamageAbsoluteReduction(newDamage, defender.DamageAbsoluteReductionStat.Value + defender.DamageAbsoluteReductionStat.FirstAttackValue);
    }

    private void InitializeCombatants(Unit attacker, Unit defender)
    {
        _attacker = attacker;
        _defender = defender;
        DetermineAdvantageFactor();
    }

    public int CalculateBaseDamage()
    {
        int defensePoints = DetermineDefensePoints();
        int attackPoints = (int)Math.Truncate(_attacker.Attack.Value * _advantageFactor);
        return Math.Max(attackPoints - defensePoints, 0);
    }

    private int ApplyDamagePercentageReduction(int damage, double reductionFactor)
    {
        double newDamage = damage * reductionFactor;
        newDamage = Math.Round(newDamage, 9);
        return Convert.ToInt32(Math.Floor(newDamage));
    }
    private int ApplyDamageAbsoluteReduction(int damage, int reductionValue)
    {
        return Math.Max(damage - reductionValue, 0);
    }
    private int ApplyExtraDamage(int damage, int extraDamage)
    {
        return damage + extraDamage;
    }
    private int DetermineDefensePoints()
    {
        return _attacker.Weapon switch
        {
            "Magic" => _defender.Resistance.Value,
            _ => _defender.Defense.Value
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
