namespace Fire_Emblem.Skills.Effects;

public class SpeedBonusEffect : Effect, IBonusEffect
{
    public int Bonus { get; protected set;}

    public SpeedBonusEffect(int bonus)
    {
        Bonus = bonus;
    }



    public override void Apply(Unit unit)
    {

    }
}