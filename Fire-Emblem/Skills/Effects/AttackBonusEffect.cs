namespace Fire_Emblem.Skills.Effects;

public class AttackBonusEffect : Effect, IBonusEffect
{
    public int Bonus { get; protected set; }
    public AttackBonusEffect(int bonus)
    {
        Bonus = bonus;
    }


    public override void Apply(Unit unit)
    {
        
    }
}