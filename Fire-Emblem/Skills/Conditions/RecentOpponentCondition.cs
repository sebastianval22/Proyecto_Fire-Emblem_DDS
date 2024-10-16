namespace Fire_Emblem.Skills.Conditions;

public class RecentOpponentCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        if (unit == roundFight.AttackingUnit)
        {
            return unit.RecentOpponent == roundFight.DefendingUnit;
        }
        else
        {
            return unit.RecentOpponent == roundFight.AttackingUnit;
        }
    }
}