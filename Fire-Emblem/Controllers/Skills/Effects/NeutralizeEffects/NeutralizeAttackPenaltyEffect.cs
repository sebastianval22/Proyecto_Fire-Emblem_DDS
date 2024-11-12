using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;
    
public class NeutralizeAttackPenaltyEffect : Effect, INeutralizePenalty
{
    public override void Apply(Unit unit)
    {
        unit.Attack.PenaltyNeutralized = true;
    }
}