using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class UToolbarMenu : UWidget
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
    public UToolbarMenu(string caption)
    {
        _autoSize = false;
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