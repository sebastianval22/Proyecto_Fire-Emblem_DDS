namespace Fire_Emblem.Skills.Conditions;

public class AttackAndOpponentResistanceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        return unit.Attack.Value - rival.Resistance.Value > 0;
    }
}