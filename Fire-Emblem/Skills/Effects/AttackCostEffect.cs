namespace Fire_Emblem.Skills.Effects;

public class AttackCostEffect : Effect, ICostEffect
{
    public int Cost { get; protected set; }
    public AttackCostEffect(int cost)
    {
        Cost = cost;
    }

    public override void Apply(Unit unit)
    {
        unit.Attack.Penalty -= Cost;
    }
}
