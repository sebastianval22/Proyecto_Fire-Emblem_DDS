using Fire_Emblem.Views;
using Fire_Emblem.AdvantageWeapons;

namespace Fire_Emblem.Controllers;

public  class DamageController
{
    private Unit _attacker;
    private Unit _defender; 
    private float _advantageFactor;
    
    
    public int CalculateFollowUpDamage(Unit attacker, Unit defender)
    {
        InitializeCombatants(attacker, defender);
        int damage = ApplyExtraDamage(CalculateBaseDamage(), attacker.DamageEffectStat.ExtraDamageValue + attacker.DamageEffectStat.ExtraDamageFollowUpAttackValue);
        int newDamage = ApplyDamagePercentageReduction(damage, defender.DamageEffectStat.DamagePercentageReductionValue*defender.DamageEffectStat.DamagePercentageReductionFollowUpAttackValue);
        return ApplyDamageAbsoluteReduction(newDamage, defender.DamageEffectStat.DamageAbsoluteReductionValue);
    }

    public int CalculateDamageFirstAttack(Unit attacker, Unit defender)
    {
        InitializeCombatants(attacker, defender);
        int damage = ApplyExtraDamage(CalculateBaseDamage(), attacker.DamageEffectStat.ExtraDamageValue + attacker.DamageEffectStat.ExtraDamageFirstAttackValue);
        int newDamage = ApplyDamagePercentageReduction(damage, defender.DamageEffectStat.DamagePercentageReductionValue * defender.DamageEffectStat.DamagePercentageReductionFirstAttackValue);
        return ApplyDamageAbsoluteReduction(newDamage, defender.DamageEffectStat.DamageAbsoluteReductionValue + defender.DamageEffectStat.DamageAbsoluteReductionFirstAttackValue);
    }
    public int CalculateDamageFirstAttackWithoutReduction(Unit attacker, Unit defender)
    {
        InitializeCombatants(attacker, defender);
        return ApplyExtraDamage(CalculateBaseDamage(), attacker.DamageEffectStat.ExtraDamageValue + attacker.DamageEffectStat.ExtraDamageFirstAttackValue);
    }

    public void InitializeCombatants(Unit attacker, Unit defender)
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

    private static  int ApplyDamagePercentageReduction(int damage, double reductionFactor)
    {
        double newDamage = damage * reductionFactor;
        newDamage = Math.Round(newDamage, 9);
        return Convert.ToInt32(Math.Floor(newDamage));
    }
    private static int ApplyDamageAbsoluteReduction(int damage, int reductionValue)
    {
        return Math.Max(damage - reductionValue, 0);
    }
    private static int ApplyExtraDamage(int damage, int extraDamage)
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
        InitializeCombatants(attacker, defender);
        DamageView.ShowAdvantageMessage(_attacker, _defender, _advantageFactor);

    }
}
