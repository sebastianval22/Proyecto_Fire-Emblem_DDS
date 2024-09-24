namespace Fire_Emblem.Skills.Effects;

public class SpeedPenaltyEffect :  Effect, IPenaltyEffect
{
    public int Penalty { get; protected set; }
    public SpeedPenaltyEffect(int penalty)
    {
        Penalty = penalty;
    }

    public override void Apply(Unit rival)
    {
        rival.Speed.Penalty -= Penalty;
    }
}