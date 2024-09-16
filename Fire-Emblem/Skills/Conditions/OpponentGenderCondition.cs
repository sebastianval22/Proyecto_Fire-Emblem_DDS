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
        if (unit == roundFight.attackingUnit)
        {
            return roundFight.defendingUnit.Gender == _gender;
        }
        else
        {
            return roundFight.attackingUnit.Gender == _gender;
        }
    }
}