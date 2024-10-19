namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class NeutralizeSpeedPenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.Speed.PenaltyNeutralized = true;
    }
}