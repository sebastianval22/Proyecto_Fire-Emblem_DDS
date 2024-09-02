namespace Fire_Emblem.Skills.Effects;

public class AttackBonusEffect : Effect
{
    private readonly int _bonus;

    public AttackBonusEffect(int bonus)
    {
        _bonus = bonus;
    }

    public override void Apply(Unit unit)
    {
        unit.Attack += _bonus;
    } 
}