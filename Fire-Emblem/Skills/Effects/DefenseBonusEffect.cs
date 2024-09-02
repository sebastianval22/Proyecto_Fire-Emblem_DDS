namespace Fire_Emblem.Skills.Effects;

public class DefenseBonusEffect : Effect
{
    private readonly int _bonus;

    public DefenseBonusEffect(int bonus)
    {
        _bonus = bonus;
    }

    public override void Apply(Unit unit)
    {
        unit.Defence += _bonus;
    }
}