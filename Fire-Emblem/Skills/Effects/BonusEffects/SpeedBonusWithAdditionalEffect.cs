namespace Fire_Emblem.Skills.Effects.BonusEffects;

public class SpeedBonusWithAdditionalEffect : SpeedBonusEffect
{
    
    private readonly Dictionary<string, int> _additionalBonusPerSpeed;
    private readonly int _baseBonus;

    public SpeedBonusWithAdditionalEffect(int baseBonus, Dictionary<string, int> additionalBonusPerSpeed): base(baseBonus)
    {
        _additionalBonusPerSpeed = additionalBonusPerSpeed;
        _baseBonus = baseBonus;
    }

    public override void Apply(Unit unit)
    {
        int speedValue = unit.Speed.Value;
        int bonusPerSpeed = _additionalBonusPerSpeed["Bonus"];
        int perSpeed = _additionalBonusPerSpeed["Per Speed"];
        int additionalBonus = speedValue / (bonusPerSpeed * perSpeed);
        Bonus = _baseBonus + additionalBonus;
        unit.Speed.Bonus += Bonus;
    }
}