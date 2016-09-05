﻿using UnityEngine;
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
        /// <summary>
        /// 
        /// </summary>
        Left,

        /// <summary>
        /// 
        /// </summary>
        Right
    }

    #endregion

    #region Data

    /// <summary>
    /// 
    /// </summary>
    private List<UWidget> _leftItems = new List<UWidget>();

    /// <summary>
    /// 
    /// </summary>
    private List<UWidget> _rightItems = new List<UWidget>();

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
        UToolbarButton button = new UToolbarButton(caption);
        AddItem(button, alignment);

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
        UToolbarMenu menu = new UToolbarMenu(caption);
        AddItem(menu, alignment);

        return menu;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enumValue"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public UToolbarEnumPopup AddEnumPopup(System.Enum enumValue, Alignment alignment = Alignment.Left)
    {
        UToolbarEnumPopup enumPopup = new UToolbarEnumPopup(enumValue);
        AddItem(enumPopup, alignment);

        return enumPopup;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="enumValue"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public UToolbarEnumPopup AddEnumPopup(string caption, System.Enum enumValue, Alignment alignment = Alignment.Left)
    {
        UToolbarEnumPopup enumPopup = new UToolbarEnumPopup(caption, enumValue);
        AddItem(enumPopup, alignment);

        return enumPopup;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public UToolbarSearchField AddSearchFiled(Alignment alignment = Alignment.Right)
    {
        UToolbarSearchField filed = new UToolbarSearchField();
        AddItem(filed, alignment);

        return filed;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public UToolbarSearchField AddSearchFiled(string caption, Alignment alignment = Alignment.Right)
    {
        UToolbarSearchField filed = new UToolbarSearchField(caption);
        AddItem(filed, alignment);

        return filed;
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <param name="alignment"></param>
    private void AddItem(UWidget item, Alignment alignment = Alignment.Left)
    {
        if (alignment == Alignment.Left)
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
