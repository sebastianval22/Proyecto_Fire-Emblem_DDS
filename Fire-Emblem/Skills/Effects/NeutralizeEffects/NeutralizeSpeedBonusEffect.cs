namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class NeutralizeSpeedBonusEffect: Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
        rival.Speed.BonusNeutralized = true;
    }

}