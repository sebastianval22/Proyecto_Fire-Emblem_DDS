namespace Fire_Emblem.Skills.Effects;

public class FirstAttackBonusEffect : AttackBonusEffect
{
    private readonly float _bonusPercentage;


    public FirstAttackBonusEffect(float bonusPercentage): base(0)
    {
        _bonusPercentage = bonusPercentage;
    }

    public override void Apply(Unit unit)
    {
        unit.SaveAttributes();
        Bonus = Convert.ToInt32(Math.Floor(unit.Attack * (this._bonusPercentage/100)));
    }
    
}