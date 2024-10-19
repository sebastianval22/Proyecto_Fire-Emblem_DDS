namespace Fire_Emblem.Skills.Effects.BonusEffects;

public class AttackBonusPerHPLostEffect : AttackBonusEffect
{
    private readonly Dictionary<string, int> _additionalAttackBonusPerHP;
    private readonly int _baseBonus;
    private readonly int _max;
    
    public AttackBonusPerHPLostEffect(int baseBonus, Dictionary<string, int> additionalAttackBonusPerHP, int max) : base(baseBonus)
    {
        _additionalAttackBonusPerHP = additionalAttackBonusPerHP;
        _baseBonus = baseBonus;
        _max = max;
    }

    public override void Apply(Unit unit)
    {
        int additionalBonus = (unit.MaxHP - unit.CurrentHP) / (_additionalAttackBonusPerHP["Bonus"] * _additionalAttackBonusPerHP["Per HP"]);
        if (_max == 0)
        {
            Bonus = _baseBonus + additionalBonus;
            
        }
        else
        {
            Bonus = int.Min(_baseBonus + additionalBonus, _max);
        }
        unit.Attack.Bonus += Bonus;
    }
}