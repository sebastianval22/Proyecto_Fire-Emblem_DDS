namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class NeutralizeDefenseBonusEffect: Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.Defense.BonusNeutralized = true;
    }
}