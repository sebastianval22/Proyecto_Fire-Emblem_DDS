namespace Fire_Emblem.Skills.Effects;

public class NeutralizeDefenseBonusEffect: Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.DefenseBonusNeutralized = true;
    }
}