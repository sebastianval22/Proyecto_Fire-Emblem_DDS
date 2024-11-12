using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.AdvantageWeapons;

public class LanceAdvantage : IWeaponAdvantage
{
    public float DetermineAdvantageFactor(Unit defender) =>
        defender.Weapon switch
        {
            "Axe" => 0.8f,
            "Sword" => 1.2f,
            _ => 1.0f
        };
}