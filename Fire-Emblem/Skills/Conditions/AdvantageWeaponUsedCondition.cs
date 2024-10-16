using Fire_Emblem.AdvantageWeapons;

namespace Fire_Emblem.Skills.Conditions;

public class AdvantageWeaponUsedCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
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