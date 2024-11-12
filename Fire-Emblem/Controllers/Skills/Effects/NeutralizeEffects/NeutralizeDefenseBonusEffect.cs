using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;

public class NeutralizeDefenseBonusEffect: Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.Defense.BonusNeutralized = true;
    }
}