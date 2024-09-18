namespace Fire_Emblem.Skills.Effects;

public class NeutralizeAttackPenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.AttackPenaltyNeutralized = true;
    }
}