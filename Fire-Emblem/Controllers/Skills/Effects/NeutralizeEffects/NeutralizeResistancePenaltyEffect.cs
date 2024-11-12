using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;

public class NeutralizeResistancePenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.Resistance.PenaltyNeutralized = true;
    }
}
