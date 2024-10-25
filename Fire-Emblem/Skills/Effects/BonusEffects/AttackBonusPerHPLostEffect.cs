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
        int maxHP = unit.MaxHP;
        int currentHP = unit.CurrentHP;
        int bonusPerHP = _additionalAttackBonusPerHP["Bonus"];
        int perHP = _additionalAttackBonusPerHP["Per HP"];
        int additionalBonus = (maxHP - currentHP) / (bonusPerHP * perHP);
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