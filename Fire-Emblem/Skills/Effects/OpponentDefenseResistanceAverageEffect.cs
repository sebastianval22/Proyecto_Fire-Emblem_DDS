namespace Fire_Emblem.Skills.Effects;

public class OpponentDefenseResistanceAverageEffect : Effect
{
    public override void Apply(Unit unit)
    {

    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        
        var averageDefenseResistance = (rival.Defense + rival.Resistance) / 2.0;


        int defenseEffect = Convert.ToInt32(Math.Floor(averageDefenseResistance - rival.Defense));
        int resistanceEffect = Convert.ToInt32(Math.Floor(averageDefenseResistance- rival.Resistance));
        
        if (defenseEffect> 0)
        {
            rival.ActiveSkillsEffects["DefenseBonus"] += defenseEffect;
        }
        else
        {
            rival.ActiveSkillsEffects["DefensePenalty"] += defenseEffect;
        }

        if (resistanceEffect > 0)
        {
            rival.ActiveSkillsEffects["ResistanceBonus"] += resistanceEffect;
        }
        else
        {
            rival.ActiveSkillsEffects["ResistancePenalty"] += resistanceEffect;
        }
    }
}