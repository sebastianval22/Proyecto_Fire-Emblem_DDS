using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.AdvantageWeapons;

public class SwordAdvantage : IWeaponAdvantage
{
    public float DetermineAdvantageFactor(Unit defender) =>
        defender.Weapon switch
        {
            "Lance" => 0.8f,
            "Axe" => 1.2f,
            _ => 1.0f
        };
}