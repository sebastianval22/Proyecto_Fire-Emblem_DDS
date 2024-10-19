namespace Fire_Emblem.Views;

public static class AttackView
{
    public static void ShowAttack(Unit attackingUnit, Unit defendingUnit, int damageAttack)
    {
        BaseView.ShowMessage($"{attackingUnit.Name} ataca a {defendingUnit.Name} con {damageAttack} de daño");
    }
}