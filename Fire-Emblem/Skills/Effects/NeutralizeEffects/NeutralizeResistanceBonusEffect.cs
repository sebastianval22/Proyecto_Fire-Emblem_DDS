namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class NeutralizeResistanceBonusEffect : Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.Resistance.BonusNeutralized = true;
    }
}