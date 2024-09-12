namespace Fire_Emblem.Skills.Effects;

public class ResistanceBonusEffect : Effect
{
    private readonly int _bonus;

    public ResistanceBonusEffect(int bonus)
    {
        _bonus = bonus;
    }

    public override void Apply(Unit unit)
    {
        unit.Resistence += _bonus;
        ShowEffect($"{unit.Name} obtiene Res+{_bonus}");
    }
}