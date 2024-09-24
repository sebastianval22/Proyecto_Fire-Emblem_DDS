namespace Fire_Emblem.Skills.Effects;

public class NeutralizeSpeedPenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.Speed.PenaltyNeutralized = true;
    }
}