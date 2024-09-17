namespace Fire_Emblem.Skills.Effects;

public class NeutralizeBonusEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        if (unit == roundFight.attackingUnit)
        {
            roundFight.defendingUnit.BonusesHaveBeenNeutralized = true;
        }
        else
        {
            roundFight.attackingUnit.BonusesHaveBeenNeutralized = true;
        }
    }
}