using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class OpponentGenderCondition : Condition
{
    private readonly string _gender;

    public OpponentGenderCondition(string gender)
    {
        _gender = gender;
    }

    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        if (unit == roundFightController.AttackingUnit)
        {
            return roundFightController.DefendingUnit.Gender == _gender;
        }
        else
        {
            return roundFightController.AttackingUnit.Gender == _gender;
        }
    }
}