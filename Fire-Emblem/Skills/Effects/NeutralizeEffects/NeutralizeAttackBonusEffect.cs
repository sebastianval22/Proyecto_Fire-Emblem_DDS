namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class NeutralizeAttackBonusEffect : Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
       rival.Attack.BonusNeutralized = true;
    }
}