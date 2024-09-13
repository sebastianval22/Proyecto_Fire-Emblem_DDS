namespace Fire_Emblem.Skills.Conditions;

public class RecentOpponentCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        if (unit == roundFight.attackingUnit)
        {
            return unit.RecentOpponent == roundFight.defendingUnit;
        }
        else
        {
            return unit.RecentOpponent == roundFight.attackingUnit;
        }
    }
}