using Fire_Emblem_View;

namespace Fire_Emblem.Views;

public abstract class BaseView
{
    private static View _view;

    public static void Initialize(View view)
    {
        _view = view;
    }

    public static void ShowMessage(string message)
    {
        _view.WriteLine(message);
    }
    public static string ReadLine()
    {
        return _view.ReadLine();
    }
}