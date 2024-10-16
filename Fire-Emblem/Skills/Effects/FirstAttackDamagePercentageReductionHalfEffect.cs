namespace Fire_Emblem.Skills.Effects;

public class FirstAttackDamagePercentageReductionHalfEffect : Effect, IDamageEffect
{
    public override void Apply(Unit unit)
    {
        unit.DamagePercentageReductionStat.FirstAttackValue *= 0.5;
    }
    
}