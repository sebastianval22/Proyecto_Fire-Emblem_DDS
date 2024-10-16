namespace Fire_Emblem;

public class ExtraDamageStat
{
    public int Value { get; set; }
    public int FirstAttackValue { get; set; }
    public ExtraDamageStat(int value, int firstAttackValue)
    {
        Value = value;
        FirstAttackValue = firstAttackValue;
    }

}