using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Conditions;

public class ResistanceDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        var resistanceDifference = unit.Resistance.Value - rival.Resistance.Value;
        return resistanceDifference > 0;
    }
}