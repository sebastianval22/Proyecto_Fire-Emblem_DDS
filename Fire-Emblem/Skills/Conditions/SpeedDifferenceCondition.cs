namespace Fire_Emblem.Skills.Conditions;

public class SpeedDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Console.WriteLine("ENTROOOOOOOOOO");
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        Console.WriteLine($"Speed unidad {unit.Speed.Value} nombre {unit.Name} Speed rival {rival.Speed.Value} nombre {rival.Name}");
        return unit.Speed.Value - rival.Speed.Value > 0;
    }
}