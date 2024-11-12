using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;

public class SelfNeutralizeDefenseBonusEffect : Effect, ISelfNeutralizeBonus
{
    public override void Apply(Unit unit)
    {
        unit.Defense.BonusNeutralized = true;
    }
}