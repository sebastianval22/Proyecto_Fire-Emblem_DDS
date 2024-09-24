namespace Fire_Emblem.Skills.Effects;

public class DefenseBonusEffect : Effect, IBonusEffect
{
    public int Bonus { get; }

    public DefenseBonusEffect(int bonus)
    {
        Bonus = bonus;
    }
    

    public override void Apply(Unit unit)
    {
        unit.Defense.Bonus += Bonus;
    }
}