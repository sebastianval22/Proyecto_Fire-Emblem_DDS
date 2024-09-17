using Fire_Emblem.Skills.Conditions;

namespace Fire_Emblem.Skills.Effects;

public class NeutralizeAttackBonusEffect : Effect, INeutralizeBonus
{
    public override void Apply(Unit rival)
    {
       rival.AttackBonusNeutralized = true;
    }
    
}