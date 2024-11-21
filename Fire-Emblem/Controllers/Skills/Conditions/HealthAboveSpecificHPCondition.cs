using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class HealthAboveSpecificHPCondition : Condition
{
    private readonly int _specificHP;
    
    public HealthAboveSpecificHPCondition(int specificHP)
    {
        _specificHP = specificHP;
    }
    
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        return unit.CurrentHP >= _specificHP;
    }
}