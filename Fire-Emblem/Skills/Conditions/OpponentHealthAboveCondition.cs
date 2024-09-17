namespace Fire_Emblem.Skills.Conditions;

public class OpponentHealthAboveCondition : Condition
{
    private readonly double _thresholdPercentage;

    public OpponentHealthAboveCondition(double thresholdPercentage)
    {
        _thresholdPercentage = thresholdPercentage;

    }
    
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        double thresholdHP = rival.MaxHP * (_thresholdPercentage / 100);
        int truncatedThresholdHP = Convert.ToInt32(Math.Floor(thresholdHP));
        return rival.CurrentHP >= truncatedThresholdHP;
    }
}