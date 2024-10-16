namespace Fire_Emblem.Skills.Conditions;

public class ResistanceDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        var resistanceDifference = unit.Resistance.Value - rival.Resistance.Value;
        return resistanceDifference > 0;
    }
}