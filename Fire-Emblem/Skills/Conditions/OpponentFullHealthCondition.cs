namespace Fire_Emblem.Skills.Conditions;

public class OpponentFullHealthCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        return rival.CurrentHP == rival.MaxHP;
    }
}