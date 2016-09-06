using UnityEngine;
using UnityEditor;

/// <summary>
/// A demo of UWindow
/// </summary>
public class WindowDemo : UWindow
{
    #region Static

    /// <summary>
    /// 
    /// </summary>
    [MenuItem("Window/Demo")]
    public static void Init()
    {
        ShowWindow<WindowDemo>();
    }

    #endregion

    #region Enum

    /// <summary>
    /// 
    /// </summary>
    enum WeekDay
    {
        Monday,
        Tuesday,
    }

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    protected WindowDemo()
    {
        //toolbar
        {
            // button
            {
                UButton button = Toolbar.AddButton("Button");
                button.OnClicked += OnButtonClickedHandler;
            }

            //toggle button
            {
                UToggleButton toggleButton = Toolbar.AddToggleButton("Toggle");
                toggleButton.OnToggleChanged += new UToggleChangedEventHandler(OnToggleChangedHandler);
            }

            //menu
            {
                UMenu menu = Toolbar.AddMenu("Menu");

                UMenuButton a = menu.AddButton("A");
                a.OnClicked += OnMenuButtonAClickedHandler;

                UMenuButton b = menu.AddButton("B");
                b.IsEnabled = false;
                b.OnClicked += OnMenuButtonBClickedHandler;

                menu.AddSeparator();

                UMenuButton c = menu.AddButton("C");
                c.OnClicked += OnMenuButtonCClickedHandler;
            }

            //enum popup
            {
                UEnumPopup enumPopup = Toolbar.AddEnumPopup(WeekDay.Monday);
                enumPopup.OnValueChanged += OnEnumValueChangedHandler;
            }

            //search field
            {
                USearchField searchFiled = Toolbar.AddSearchFiled(UToolbar.Alignment.Right);
                searchFiled.OnTextChanged += OnSerachTextChangedHander;
            }
        }
    }

    #endregion

    #region Handler

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private void OnButtonClickedHandler(UEventArgs args)
    {
        Debug.Log("Button is clicked");
        UInspector.Active<InspectorDemoObject>("Button");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private void OnMenuButtonAClickedHandler(UEventArgs args)
    {
        Debug.Log("Menu A is clicked");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private void OnMenuButtonBClickedHandler(UEventArgs args)
    {
        Debug.Log("Menu B is clicked");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private void OnMenuButtonCClickedHandler(UEventArgs args)
    {
        Debug.Log("Menu C is clicked");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private void OnEnumValueChangedHandler(UEnumEventArgs args)
    {
        Debug.Log("Enum vlaue changed: " + args.Value.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private void OnSerachTextChangedHander(UTextEventArgs args)
    {
        Debug.Log("Now you are search by text: " + args.Text);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    void OnToggleChangedHandler(UToggleEventArgs args)
    {
        Debug.Log("Toggle state changed: " + args.IsToggled);
    }

    #endregion
}
