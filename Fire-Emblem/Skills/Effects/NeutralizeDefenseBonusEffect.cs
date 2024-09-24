namespace Fire_Emblem.Skills.Effects;

public class NeutralizeDefenseBonusEffect: Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.Defense.BonusNeutralized = true;
    }
}