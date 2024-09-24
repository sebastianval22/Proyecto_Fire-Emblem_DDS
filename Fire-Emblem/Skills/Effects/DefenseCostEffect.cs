namespace Fire_Emblem.Skills.Effects;

public class DefenseCostEffect : Effect, ICostEffect
{
    public int Cost { get; protected set; }
    public DefenseCostEffect(int cost)
    {
        Cost = cost;
    }

    public override void Apply(Unit unit)
    {
        unit.Defense.Penalty -= Cost;
    }
}