namespace Fire_Emblem.Skills.Effects;

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
        int additionalBonus = (unit.MaxHP - unit.CurrentHP) / (_additionalSpeedBonusPerHP["Bonus"] * _additionalSpeedBonusPerHP["Per HP"]);
        if (_max == 0)
        {
            Bonus = _baseBonus + additionalBonus;
            
        }
        else
        {
            Bonus = int.Min(_baseBonus + additionalBonus, _max);
        }
        
    }
}