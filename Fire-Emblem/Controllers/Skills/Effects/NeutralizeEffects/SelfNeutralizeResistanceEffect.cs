using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;

public class SelfNeutralizeResistanceEffect : Effect, ISelfNeutralizeBonus
{
    public override void Apply(Unit unit)
    {
        unit.Resistance.BonusNeutralized = true;
    }
}
