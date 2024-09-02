namespace Fire_Emblem.AdvantageWeapons;

public interface IWeaponAdvantage
{
    float DetermineAdvantageFactor(Unit defender);
}