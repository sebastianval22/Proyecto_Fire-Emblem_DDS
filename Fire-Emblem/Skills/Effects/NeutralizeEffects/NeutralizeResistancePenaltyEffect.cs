namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class NeutralizeResistancePenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.Resistance.PenaltyNeutralized = true;
    }
    
}
