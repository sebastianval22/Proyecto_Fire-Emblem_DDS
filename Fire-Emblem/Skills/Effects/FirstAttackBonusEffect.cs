namespace Fire_Emblem.Skills.Effects;

public class FirstAttackBonusEffect : Effect
{
    private readonly float _bonusPercentage;
    private int Bonus;

    public FirstAttackBonusEffect(float bonusPercentage)
    {
        _bonusPercentage = bonusPercentage;
    }

    public override void Apply(Unit unit)
    {
        unit.SaveAttributes();
        Bonus = Convert.ToInt32(Math.Floor(unit.Attack * (this._bonusPercentage/100)));
        unit.Attack += Bonus;
        ShowEffect($"{unit.Name} obtiene Atk+{Bonus} en su primer ataque");
    }
    
}