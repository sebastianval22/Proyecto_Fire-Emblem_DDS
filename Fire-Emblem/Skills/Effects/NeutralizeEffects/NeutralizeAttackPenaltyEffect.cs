namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;
    
public class NeutralizeAttackPenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.Attack.PenaltyNeutralized = true;
    }
}