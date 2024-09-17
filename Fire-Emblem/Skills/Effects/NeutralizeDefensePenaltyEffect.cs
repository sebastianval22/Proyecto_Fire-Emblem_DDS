namespace Fire_Emblem.Skills.Effects;

public class NeutralizeDefensePenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.DefensePenaltyNeutralized = true;
    }
    
}