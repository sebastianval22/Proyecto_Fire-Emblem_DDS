namespace Fire_Emblem.Skills.Effects;

public class NeutralizeResistanceBonusEffect : Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.Resistance.BonusNeutralized = true;
    }
}