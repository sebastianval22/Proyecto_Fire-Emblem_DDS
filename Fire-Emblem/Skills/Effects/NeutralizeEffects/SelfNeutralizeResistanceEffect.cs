namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class SelfNeutralizeResistanceEffect : Effect, ISelfNeutralizeBonus
{
    public override void Apply(Unit unit)
    {
        unit.Resistance.BonusNeutralized = true;
    }
}
