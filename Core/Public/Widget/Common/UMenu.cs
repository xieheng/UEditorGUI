using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class UMenu : UWidget
{
#region Data

    /// <summary>
    /// 
    /// </summary>
    private List<UMenuSub> _menus = new List<UMenuSub>();

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UMenu(string caption)
    {
        _autoSize = false;
        _caption = caption;
        _style = GUI.skin.FindStyle("DropDownButton");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="style"></param>
    protected UMenu(string caption, GUIStyle style)
    {
        _autoSize = false;
        _caption = caption;
        _style = style;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        if (!_visible)
            return;

        bool clicked = false;
        Rect rect = GUILayoutUtility.GetRect(new GUIContent(_caption), _style, GUILayout.ExpandWidth(false));

        GUI.color = _color;
        {
            clicked = GUI.Button(rect, _caption, _style);
        }
        GUI.color = Color.white;

        if (clicked)
        {
            GenericMenu menu = new GenericMenu();

            for (int i = 0; i < _menus.Count; i++)
            {
                UMenuSub item = _menus[i];

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
        _menus.Add(menu);

        return menu;
    }

    /// <summary>
    /// 
    /// </summary>
    public void AddSeparator()
    {
        UMenuSeparator separator = new UMenuSeparator();
        _menus.Add(separator);
    }

    #endregion
}
