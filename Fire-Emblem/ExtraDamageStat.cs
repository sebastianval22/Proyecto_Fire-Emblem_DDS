namespace Fire_Emblem;

public class ExtraDamageStat
{
    public int Value { get; set; }
    public int FirstAttackValue { get; set; }
    public int FollowUpAttackValue { get; set; }
    public ExtraDamageStat(int value, int firstAttackValue, int followUpAttackValue)
    {
        Value = value;
        FirstAttackValue = firstAttackValue;
        FollowUpAttackValue = followUpAttackValue;
    }

}