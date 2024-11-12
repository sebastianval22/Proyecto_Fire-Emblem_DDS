using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;

public class NeutralizeSpeedPenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.Speed.PenaltyNeutralized = true;
    }
}