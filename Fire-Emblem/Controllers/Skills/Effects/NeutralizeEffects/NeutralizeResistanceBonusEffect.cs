using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;

public class NeutralizeResistanceBonusEffect : Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.Resistance.BonusNeutralized = true;
    }
}