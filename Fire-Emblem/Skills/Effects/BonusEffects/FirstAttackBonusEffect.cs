namespace Fire_Emblem.Skills.Effects.BonusEffects;

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
        Bonus = Convert.ToInt32(Math.Floor(unit.Attack.Value * (this._bonusPercentage/100)));
        unit.Attack.FirstAttackBonus += Bonus;
    }
    
}