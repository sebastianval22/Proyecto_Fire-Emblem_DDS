using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.AdvantageWeapons;

public interface IWeaponAdvantage
{
    float DetermineAdvantageFactor(Unit defender);
}