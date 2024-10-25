namespace Fire_Emblem.Skills.Effects.BonusEffects;

public class SpeedBonusPerHPLostEffect : SpeedBonusEffect
{
    
    private readonly Dictionary<string, int> _additionalSpeedBonusPerHP;
    private readonly int _baseBonus;
    private readonly int _max;
    
    public SpeedBonusPerHPLostEffect(int baseBonus, Dictionary<string, int> additionalSpeedBonusPerHP, int max) : base(baseBonus)
    {
        _additionalSpeedBonusPerHP = additionalSpeedBonusPerHP;
        _baseBonus = baseBonus;
        _max = max;
    }

    public override void Apply(Unit unit)
    {
        int maxHP = unit.MaxHP;
        int currentHP = unit.CurrentHP;
        int bonusPerHP = _additionalSpeedBonusPerHP["Bonus"];
        int perHP = _additionalSpeedBonusPerHP["Per HP"];
        int additionalBonus = (maxHP - currentHP) / (bonusPerHP * perHP);
        if (_max == 0)
        {
            Bonus = _baseBonus + additionalBonus;
            
        }
        else
        {
            Bonus = int.Min(_baseBonus + additionalBonus, _max);
        }
        unit.Speed.Bonus += Bonus;
    }
}