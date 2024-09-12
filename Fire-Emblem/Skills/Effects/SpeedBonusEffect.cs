namespace Fire_Emblem.Skills.Effects;

public class SpeedBonusEffect : Effect
{
    private readonly int _bonus;

    public SpeedBonusEffect(int bonus)
    {
        _bonus = bonus;
    }

    public override void Apply(Unit unit)
    {
        unit.Speed += _bonus;
        ShowEffect($"{unit.Name} obtiene Spd+{_bonus}");
    } 
}