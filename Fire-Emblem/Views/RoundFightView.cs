namespace Fire_Emblem.Views;

public static class RoundFightView
{
    public static void ShowAttackerInabilityToFollowUp(string unitName)
    {
        BaseView.ShowMessage($"{unitName} no puede hacer un follow up");
    }
    public static void ShowInabilityToFollowUp()
    {
        BaseView.ShowMessage("Ninguna unidad puede hacer un follow up");
    }
}