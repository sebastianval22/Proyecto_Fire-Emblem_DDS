namespace Fire_Emblem.Skills.Effects;

public class Max15HPBonusEffect : Effect
{
    public override void Apply(Unit unit)
    {
        unit.CurrentHP = unit.MaxHP + 15;
    }
}