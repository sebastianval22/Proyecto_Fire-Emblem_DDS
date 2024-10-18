using Fire_Emblem;

namespace Fire_Emblem.Skills.Effects;

public class DamageDivineRecreationEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        if (unit == roundFight.AttackingUnit)
        {
            unit.DamagePercentageReductionStat.FirstAttackValue *= 0.7;

        }
    }
}