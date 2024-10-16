namespace Fire_Emblem.Skills.Effects;

public class OpponentDefenseResistanceAverageEffect : Effect
{
    public override void Apply(Unit unit)
    {

    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        
        var averageDefenseResistance = (rival.Defense.Value + rival.Resistance.Value) / 2.0;

        ApplyEffect(rival.Defense, averageDefenseResistance);
        ApplyEffect(rival.Resistance, averageDefenseResistance);
    }

    private void ApplyEffect(Stat stat, double averageValue)
    {
        int effectValue = Convert.ToInt32(Math.Floor(averageValue - stat.Value));
        
        if (effectValue > 0)
        {
            stat.Bonus += effectValue;
        }
        else
        {
            stat.Penalty += effectValue;
        }
    }
}