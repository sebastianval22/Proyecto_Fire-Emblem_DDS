
namespace Fire_Emblem.Views;

public  static class DamageView 
{
    public static void ShowAdvantageMessage(Unit attacker, Unit defender, double advantageFactor)
    {
        string message = advantageFactor switch
        {
            > 1 => $"{attacker.Name} ({attacker.Weapon}) tiene ventaja con respecto a {defender.Name} ({defender.Weapon})",
            < 1 => $"{defender.Name} ({defender.Weapon}) tiene ventaja con respecto a {attacker.Name} ({attacker.Weapon})",
            _ => "Ninguna unidad tiene ventaja con respecto a la otra"
        };    
        BaseView.ShowMessage(message);
    }
}