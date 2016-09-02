using UnityEngine;
using UnityEditor;

public class WindowDemo : UWindow
{
    #region Static

    [MenuItem("Window/Demo")]
    public static void Init()
    {
        ShowWindow<WindowDemo>();
    }

    #endregion

    #region Construction

    protected WindowDemo()
    {
        UToolbarButton button = Toolbar.AddButton("Button");
        button.OnClicked += OnButtonClickedHandler;

        UToolbarMenu menu = Toolbar.AddMenu("Menu");

        UMenuButton a = menu.AddButton("A");
        a.OnClicked += OnMenuButtonAClickedHandler;

        UMenuButton b = menu.AddButton("B");
        b.IsEnabled = false;
        b.OnClicked += OnMenuButtonBClickedHandler;

        menu.AddSeparator();

        UMenuButton c = menu.AddButton("C");
        c.OnClicked += OnMenuButtonCClickedHandler;

        UToolbarSearchField searchFiled = Toolbar.AddSearchFiled();
    }

    #endregion

    #region Handler

    private void OnButtonClickedHandler(UEventArgs args)
    {
        Debug.Log("Button is clicked");
    }

    private void OnMenuButtonAClickedHandler(UEventArgs args)
    {
        Debug.Log("Menu A is clicked");
    }

    private void OnMenuButtonBClickedHandler(UEventArgs args)
    {
        Debug.Log("Menu B is clicked");
    }

    private void OnMenuButtonCClickedHandler(UEventArgs args)
    {
        Debug.Log("Menu C is clicked");
    }

    #endregion
}
