namespace Fire_Emblem;

public class DamagePercentageReductionStat 
{
    public double Value { get; set; }
    public double FirstAttackValue { get; set; }

    public DamagePercentageReductionStat(double value, double firstAttackValue)
    {
        Value = value;
        FirstAttackValue = firstAttackValue;
    }

}