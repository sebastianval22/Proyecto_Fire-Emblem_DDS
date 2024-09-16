namespace Fire_Emblem.Skills.Effects;

public class DefensePenaltyEffect : Effect, IPenaltyEffect
{
    public int Penalty { get; protected set; }
    public DefensePenaltyEffect(int penalty)
    {
        Penalty = penalty;
    }

    public override void Apply(Unit unit)
    {
        
    }
}
