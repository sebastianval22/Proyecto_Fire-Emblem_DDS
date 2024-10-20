using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.BonusEffects;

public class FirstAttackBonusEffect : AttackBonusEffect
{
    private readonly float _bonusPercentage;
    private readonly UnitController _unitController = new UnitController();

    public FirstAttackBonusEffect(float bonusPercentage): base(0)
    {
        _bonusPercentage = bonusPercentage;
    }

    public override void Apply(Unit unit)
    {
        _unitController.SaveAttributes(unit);
        Bonus = Convert.ToInt32(Math.Floor(unit.Attack.Value * (this._bonusPercentage/100)));
        unit.Attack.FirstAttackBonus += Bonus;
    }
    
}