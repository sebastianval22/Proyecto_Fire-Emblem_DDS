namespace Fire_Emblem.Skills.Effects;

public class SelfNeutralizeResistanceEffect : Effect, ISelfNeutralizeBonus
{
    public override void Apply(Unit unit)
    {
        unit.Resistance.BonusNeutralized = true;
    }
}
