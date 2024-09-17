namespace Fire_Emblem.Skills.Effects;

public class NeutralizeSpeedBonusEffect: Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.SpeedBonusNeutralized = true;
    }

}