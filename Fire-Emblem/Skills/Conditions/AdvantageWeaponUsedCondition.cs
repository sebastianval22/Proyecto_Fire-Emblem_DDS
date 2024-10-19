using Fire_Emblem.AdvantageWeapons;
using Fire_Emblem.Controllers;


namespace Fire_Emblem.Skills.Conditions;

public class AdvantageWeaponUsedCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        IWeaponAdvantage advantage = unit.Weapon switch
        {
            "Sword" => new SwordAdvantage(),
            "Lance" => new LanceAdvantage(),
            "Axe" => new AxeAdvantage(),
            _ => null
        };
        float advantageFactor = advantage?.DetermineAdvantageFactor(rival) ?? 1;
        Console.WriteLine($"{unit.Name} tiene ventaja con respecto a {rival.Name}: {advantageFactor}");
        return advantageFactor > 1;
    }
}