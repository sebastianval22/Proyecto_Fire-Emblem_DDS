namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class NeutralizeDefensePenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.Defense.PenaltyNeutralized = true;
    }
}