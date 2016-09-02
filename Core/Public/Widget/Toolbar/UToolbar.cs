using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class UToolbar : UControl
{
    #region Enum

    /// <summary>
    /// 
    /// </summary>
    public enum Alignment
    {
        Left,
        Right
    }

    #endregion

    #region Data

    /// <summary>
    /// 
    /// </summary>
    private List<UToolbarItem> _leftItems = new List<UToolbarItem>();

    /// <summary>
    /// 
    /// </summary>
    private List<UToolbarItem> _rightItems = new List<UToolbarItem>();

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        if (_leftItems.Count == 0 && _rightItems.Count == 0)
            return;

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
        {
            for (int i = 0; i < _leftItems.Count; i++)
            {
                _leftItems[i].OnGUI();
            }

            GUILayout.FlexibleSpace();

            for (int i = 0; i < _rightItems.Count; i++)
            {
                _rightItems[i].OnGUI();
            }

        }
        EditorGUILayout.EndHorizontal();
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public UToolbarButton AddButton(string caption, Alignment alignment = Alignment.Left)
    {
        UToolbarButton button = new UToolbarButton(caption, alignment);
        AddItem(button);

        return button;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public UToolbarMenu AddMenu(string caption, Alignment alignment = Alignment.Left)
    {
        UToolbarMenu menu = new UToolbarMenu(caption, alignment);
        AddItem(menu);

        return menu;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public UToolbarSearchField AddSearchFiled(Alignment alignment = Alignment.Right)
    {
        UToolbarSearchField filed = new UToolbarSearchField(alignment);
        AddItem(filed);

        return filed;
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <param name="alignment"></param>
    private void AddItem(UToolbarItem item)
    {
        if (item.Alignment == Alignment.Left)
        {
            _leftItems.Add(item);
        }
        else
        {
            _rightItems.Add(item);
        }
    }

    #endregion
}
