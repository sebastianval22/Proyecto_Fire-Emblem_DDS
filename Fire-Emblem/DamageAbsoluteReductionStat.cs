namespace Fire_Emblem;

public class DamageAbsoluteReductionStat
{
    public int Value { get; set; }
    public int FirstAttackValue { get; set; }
    public DamageAbsoluteReductionStat(int value, int firstAttackValue)
    {
        Value = value;
        FirstAttackValue = firstAttackValue;
    }
}