namespace Fire_Emblem;

public class DamagePercentageReductionStat 
{
    public double Value { get; set; }
    public double FirstAttackValue { get; set; }
    public double FollowUpAttackValue { get; set; }

    public DamagePercentageReductionStat(double value, double firstAttackValue, double followUpAttackValue)
    {
        Value = value;
        FirstAttackValue = firstAttackValue;
        FollowUpAttackValue = followUpAttackValue;
    }

}