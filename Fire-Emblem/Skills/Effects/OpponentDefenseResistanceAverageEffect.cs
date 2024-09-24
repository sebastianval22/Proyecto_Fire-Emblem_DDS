namespace Fire_Emblem.Skills.Effects;

public class OpponentDefenseResistanceAverageEffect : Effect
{
    public override void Apply(Unit unit)
    {

    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        
        var averageDefenseResistance = (rival.Defense.Value + rival.Resistance.Value) / 2.0;


        int defenseEffect = Convert.ToInt32(Math.Floor(averageDefenseResistance - rival.Defense.Value));
        int resistanceEffect = Convert.ToInt32(Math.Floor(averageDefenseResistance- rival.Resistance.Value));
        
        if (defenseEffect> 0)
        {
            rival.Defense.Bonus += defenseEffect;
        }
        else
        {
            rival.Defense.Penalty += defenseEffect;
        }

        if (resistanceEffect > 0)
        {
            rival.Resistance.Bonus += resistanceEffect;
        }
        else
        {
            rival.Resistance.Penalty += resistanceEffect;
        }
    }
}