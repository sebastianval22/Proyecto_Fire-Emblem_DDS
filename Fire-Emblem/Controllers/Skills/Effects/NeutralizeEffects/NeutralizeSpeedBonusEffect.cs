using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;

public class NeutralizeSpeedBonusEffect: Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.Speed.BonusNeutralized = true;
    }
}