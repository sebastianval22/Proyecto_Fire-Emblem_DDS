namespace Fire_Emblem.Skills.Effects;

public class NeutralizeResistancePenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.ResistancePenaltyNeutralized = true;
    }
    
}
