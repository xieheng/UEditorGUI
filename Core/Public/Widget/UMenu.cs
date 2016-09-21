using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UEditorGUI.Internal.Menu;

public class UMenu : UCaptionWidget
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
        : base(caption)
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="style"></param>
    protected UMenu(string caption, GUIStyle style)
        : base(caption)
    {
        this.style = style;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    protected override void UpdateGUI()
    {
        this.style = (style == GUIStyle.none) ? GUI.skin.FindStyle("DropDownButton") : style;
        Rect rect = GUILayoutUtility.GetRect(new GUIContent(caption), style, GUILayout.ExpandWidth(false));

        if (GUI.Button(rect, caption, style))
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

    /// <summary>
    /// 
    /// </summary>
    protected override void ActiveToolbarGuiStyle()
    {
        this.style = EditorStyles.toolbarDropDown;
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
