namespace Fire_Emblem.Skills.Conditions;

public class OpponentGenderCondition : Condition
{
    private readonly string _gender;

    public OpponentGenderCondition(string gender)
    {
        _gender = gender;
    }

    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        if (unit == roundFight.AttackingUnit)
        {
            return roundFight.DefendingUnit.Gender == _gender;
        }
        else
        {
            return roundFight.AttackingUnit.Gender == _gender;
        }
    }
}