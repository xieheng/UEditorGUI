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

        //treeview
        {
            UTreeView treeView = new UTreeView();
            AddWidget(treeView);

            UTreeViewItem item0 = treeView.Add("treeview item 1");
            UTreeViewItem child00 = item0.Add("treeview item 1.1");
            child00.Add("treeview item 1.1.1");
            UTreeViewItem child01 = item0.Add("treeview item 1.2");
            child00.Add("treeview item 1.2.1");

            UTreeViewItem item1 = treeView.Add("treeview item 2");
            item1.Add("treeview item 2.1");
            item1.Add("treeview item 2.2");

            UTreeViewItem item2 = treeView.Add("treeview item 3");
            item2.Add("treeview item 3.1");
            item2.Add("treeview item 3.2");

            UTreeViewItem item3 = treeView.Add("treeview item 4");
            item3.Add("treeview item 4.1");
            item3.Add("treeview item 4.2");

            UTreeViewItem item4 = treeView.Add("treeview item 5");
            item4.Add("treeview item 5.1");
            item4.Add("treeview item 5.2");

            UTreeViewItem item5 = treeView.Add("treeview item 6");
            item5.Add("treeview item 6.1");
            item5.Add("treeview item 6.2");

            UTreeViewItem item6 = treeView.Add("treeview item 7");
            item6.Add("treeview item 7.1");
            item6.Add("treeview item 7.2");

            treeView.Add("treeview item 8");
            treeView.Add("treeview item 9");
            treeView.Add("treeview item 10");
        }

        //listview
        {
            UListView listView = new UListView();
            AddWidget(listView);

            listView.Add("listview item 1");
            listView.Add("listview item 2");
            listView.Add("listview item 3");
            listView.Add("listview item 4");
            listView.Add("listview item 5");
            listView.Add("listview item 6");
            listView.Add("listview item 7");
            listView.Add("listview item 8");
            listView.Add("listview item 9");
            listView.Add("listview item 10");
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
