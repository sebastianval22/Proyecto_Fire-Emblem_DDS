using Fire_Emblem_View;

namespace Fire_Emblem.Skills.Effects;

public static class EffectLogger
{
    private static View _view;

    public static void Initialize(View view)
    {
        _view = view;
    }

    public static void ShowEffect(string message)
    {
        _view?.WriteLine(message);
    }
}