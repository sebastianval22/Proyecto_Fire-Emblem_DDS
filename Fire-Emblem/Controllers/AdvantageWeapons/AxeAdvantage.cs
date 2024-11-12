using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.AdvantageWeapons;

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