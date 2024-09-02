namespace Fire_Emblem.AdvantageWeapons;

public class AxeAdvantage : IWeaponAdvantage
{
    public float DetermineAdvantageFactor(Unit defender) =>
        defender.Weapon switch
        {
            "Sword" => 0.8f,
            "Lance" => 1.2f,
            _ => 1.0f
        };
}