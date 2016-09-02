using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

#region UToolbarItem

/// <summary>
/// 
/// </summary>
public abstract class UToolbarItem : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private UToolbar.Alignment _alignment = UToolbar.Alignment.Left;
    
    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="alignment"></param>
    protected UToolbarItem(UToolbar.Alignment alignment)
    {
        _alignment = alignment;
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public UToolbar.Alignment Alignment
    {
        set { _alignment = value; }
        get { return _alignment; }
    }

    #endregion
}

#endregion

#region UToolbarButton

/// <summary>
/// 
/// </summary>
public class UToolbarButton : UToolbarItem
{
    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UEventHandler OnClicked;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UToolbarButton(string caption, UToolbar.Alignment alignment = UToolbar.Alignment.Left)
        : base(alignment)
    {
        _caption = caption;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        GUI.color = _color;
        {
            if (GUILayout.Button(_caption, EditorStyles.toolbarButton))
            {
                OnClickedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    private void OnClickedHandler()
    {
        if (OnClicked != null)
        {
            UEventArgs args = new UEventArgs();
            OnClicked(args);
        }
    }

    #endregion
}

#endregion

#region UToolbarMenu

/// <summary>
/// 
/// </summary>
public class UToolbarMenu : UToolbarItem
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private List<UMenuItem> _items = new List<UMenuItem>();

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UToolbarMenu(string caption, UToolbar.Alignment alignment = UToolbar.Alignment.Left)
        : base(alignment)
    {
        _caption = caption;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        bool clicked = false;
        Rect rect = GUILayoutUtility.GetRect(new GUIContent(_caption), EditorStyles.toolbarDropDown, GUILayout.ExpandWidth(false));

        GUI.color = _color;
        {
            clicked = GUI.Button(rect, _caption, EditorStyles.toolbarDropDown);
        }
        GUI.color = Color.white;

        if (clicked)
        {
            GenericMenu menu = new GenericMenu();

            for (int i = 0; i < _items.Count; i++)
            {
                UMenuItem item = _items[i];

                item.SetParent(menu);
                item.OnGUI();
            }

            menu.DropDown(rect);
        }
    }

    #endregion

    #region Public 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public UMenuButton AddButton(string text)
    {
        UMenuButton menu = new UMenuButton(text);
        _items.Add(menu);

        return menu;
    }

    /// <summary>
    /// 
    /// </summary>
    public void AddSeparator()
    {
        UMenuSeparator separator = new UMenuSeparator();
        _items.Add(separator);
    }

    #endregion
}

#endregion

#region UToolbarSearchField

/// <summary>
/// 
/// </summary>
public class UToolbarSearchField : UToolbarItem
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private string _text = string.Empty;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="alignment"></param>
    public UToolbarSearchField(UToolbar.Alignment alignment = UToolbar.Alignment.Right)
        :base(alignment)
    {

    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        _text = GUILayout.TextField(_text, GUI.skin.FindStyle("ToolbarSeachTextField"), GUILayout.MinWidth(120));

        if (string.IsNullOrEmpty(_text))
        {
            GUILayout.Label(string.Empty, GUI.skin.FindStyle("ToolbarSeachCancelButtonEmpty"));
        }
        else
        {
            if (GUILayout.Button(string.Empty, GUI.skin.FindStyle("ToolbarSeachCancelButton")))
            {
                _text = string.Empty;
                GUI.FocusControl(null);
            }
        }
    }

    #endregion
}

#endregion