using UnityEngine;
using UnityEditor;
using UEditorGUI;

/// <summary>
/// A demo of UWindow
/// </summary>
public class WindowDemo : UWindow
{
    #region Static

    /// <summary>
    /// 
    /// </summary>
    [MenuItem("Window/UEditorGUI Demo")]
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
            UToolbar toolbar = new UToolbar();
            // button
            {
                UButton button = new UButton("Button");
                button.OnClicked += OnButtonClickedHandler;

                toolbar.AddWidget(button);
            }

            //toggle button
            {
                UToggleButton toggleButton = new UToggleButton("Toggle");
                toggleButton.OnToggleChanged += new UToggleChangedEventHandler(OnToggleChangedHandler);

                toolbar.AddWidget(toggleButton);
            }

            //menu
            {
                UMenu menu = new UMenu("Menu");

                UMenuButton a = new UMenuButton("A");
                a.OnClicked += OnMenuButtonAClickedHandler;

                UMenuButton b = new UMenuButton("B");
                b.enabled = false;
                b.OnClicked += OnMenuButtonBClickedHandler;

                UMenuSeparator s = new UMenuSeparator();

                UMenuButton c = new UMenuButton("C");
                c.OnClicked += OnMenuButtonCClickedHandler;

                menu.AddItem(a);
                menu.AddItem(b);
                menu.AddItem(s);
                menu.AddItem(c);

                toolbar.AddWidget(menu);
            }

            //enum popup
            {
                UEnumPopup enumPopup = new UEnumPopup(WeekDay.Monday);
                enumPopup.OnValueChanged += OnEnumValueChangedHandler;

                toolbar.AddWidget(enumPopup);
            }

            //search field
            {
                USearchField searchFiled = new USearchField();
                searchFiled.OnTextChanged += OnSerachTextChangedHander;

                toolbar.AddWidget(searchFiled, UToolbar.Alignment.Right);
            }

            AddWidget(toolbar);
        }

        //listview
        {
            UListView listView = new UListView();
            AddWidget(listView);

            listView.Add("1");
            listView.Add("2");
            listView.Add("3");
            listView.Add("4");
            listView.Add("5");
            listView.Add("6");
        }

        //treeview
        {
            UTreeView treeView = new UTreeView();
            AddWidget(treeView);

            UTreeViewItem item0 = treeView.Add("0");
            UTreeViewItem child00 = item0.Add("0.0");
            child00.Add("0.0.0");
            UTreeViewItem child01 = item0.Add("0.1");
            child00.Add("0.0.1");

            UTreeViewItem item1 = treeView.Add("1");
            item1.Add("1.0");
            item1.Add("1.1");

            UTreeViewItem item2 = treeView.Add("2");
            item2.Add("2.0");
            item2.Add("2.1");

            UTreeViewItem item3 = treeView.Add("3");
            item3.Add("3.0");
            item3.Add("3.1");

            UTreeViewItem item4 = treeView.Add("4");
            item4.Add("4.0");
            item4.Add("4.1");

            UTreeViewItem item5 = treeView.Add("5");
            item5.Add("5.0");
            item5.Add("5.1");

            UTreeViewItem item6 = treeView.Add("6");
            item6.Add("6.0");
            item6.Add("6.1");

            treeView.Add("7");
            treeView.Add("8");
            treeView.Add("9");
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
        Debug.Log("Enum vlaue changed: " + args.value.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private void OnSerachTextChangedHander(UTextEventArgs args)
    {
        Debug.Log("Now you are search by text: " + args.text);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    void OnToggleChangedHandler(UToggleEventArgs args)
    {
        Debug.Log("Toggle state changed: " + args.toggled);
    }

    #endregion
}
