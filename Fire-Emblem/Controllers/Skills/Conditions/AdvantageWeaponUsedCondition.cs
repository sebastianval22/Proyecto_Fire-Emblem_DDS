using Fire_Emblem.Controllers.AdvantageWeapons;
using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Conditions;

public class AdvantageWeaponUsedCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        IWeaponAdvantage advantage = unit.Weapon switch
        {
            "Sword" => new SwordAdvantage(),
            "Lance" => new LanceAdvantage(),
            "Axe" => new AxeAdvantage(),
            _ => null
        };
        float advantageFactor = advantage?.DetermineAdvantageFactor(rival) ?? 1;
        return advantageFactor > 1;
    }
}